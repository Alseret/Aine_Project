using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class OpenFolder_Copy : MonoBehaviour
{
	[SerializeField] private Text m_path;
	[SerializeField] private Image m_img;
	[SerializeField] private Texture m_texture;
	[SerializeField] private Texture2D m_defTexture;
	[SerializeField] private Material[] m_mat;
	[SerializeField] private Text m_checkFile;
	string path = "AAAA";
	byte[] m_data;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		// 削除
		if (Input.GetKeyDown(KeyCode.Backspace))
			DeleteTexture("test");
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (System.IO.File.Exists(path))
				m_checkFile.text = "true";
			else
				m_checkFile.text = "false";
		}
		if (Input.GetKeyDown(KeyCode.Return))
		{
			StartCoroutine(StateUpdate());
		}
	}
	public void DeffMaterial()
	{
		m_img.sprite = Sprite.Create(m_defTexture, new Rect(0f, 0f, m_defTexture.width, m_defTexture.height), Vector2.zero);
		for (int i = 0; i < m_mat.Length; i++) 
			m_mat[i].mainTexture = m_defTexture;
	}

	IEnumerator StateUpdate()
	{
		// 削除
		DeleteTexture("test");
		yield return new WaitForSeconds(.2f);

		// 複製
		path = CopyTexture("test");
		yield return new WaitForSeconds(.2f);

		// ファイル読み込み
		ReadFile_s(path);
		yield return new WaitForSeconds(.2f);

		// テクスチャ読み込み
		Texture readBinary = ReadTexture(path);
		m_path.text = "Path : " + path;
		m_checkFile.text = "Read_0";
		yield return new WaitForSeconds(.2f);

		m_checkFile.text = "Read_1";
		m_img.sprite =
			Sprite.Create(ToTexture2D(readBinary), new Rect(0f, 0f, readBinary.width, readBinary.height), Vector2.zero);
		yield return new WaitForSeconds(1f);

		m_checkFile.text = "Read_2";
		for (int i = 0; i < m_mat.Length; i++)
			m_mat[i].mainTexture = readBinary;
		//m_mat.mainTexture = readBinary;
		yield return new WaitForSeconds(1f);

		m_checkFile.text = "Read_Comp";
	}

	// texture削除
	private void DeleteTexture(string path)
	{
		string AppPath = Application.dataPath;
#if UNITY_EDITOR       // Editor
		AppPath = AppPath.Replace("/Assets", "") + "/" + path;
#elif UNITY_STANDALONE   // Exe
		AppPath =  AppPath.Replace("/ModelEdit_Data", "") + "/" + path;
#endif
		if (System.IO.File.Exists(AppPath + "_copy.png"))
		{
			Debug.Log("Delete!");
			File.Delete(AppPath + "_copy.png");
		}
	}

	// texture複製
	string CopyTexture(string path)
	{
		string AppPath = Application.dataPath;

#if UNITY_EDITOR       // Editor
		AppPath = AppPath.Replace("/Assets", "") + "/" + path;
#elif UNITY_STANDALONE   // Exe
		AppPath =  AppPath.Replace("/ModelEdit_Data", "") + "/" + path;
#endif
		File.Copy(AppPath + ".png", AppPath + "_copy.png");
		return AppPath + "_copy.png";
	}

	// ファイル読み込み
	void ReadFile(string path)
	{
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryReader bin = new BinaryReader(fileStream);
		m_data = bin.ReadBytes((int)bin.BaseStream.Length);
	}
	async void ReadFile_s(string path)
	{
		m_data = null;
		using (var fs = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read))
		{
			m_data = new byte[fs.Length];

			await fs.ReadAsync(m_data, 0, (int)fs.Length);
		}
	}

	// テクスチャ読み込み
	Texture ReadTexture(string path)
	{
		byte[] readBinary = m_data;

		Texture2D texture = new Texture2D(1, 1);
		if(texture.LoadImage(readBinary))
		{
			Debug.Log("Texture Load");
		}

		return texture;
	}



	// 変換
	Texture2D ToTexture2D(Texture _texture)
	{
		var sw = _texture.width;
		var sh = _texture.height;
		var format = TextureFormat.RGBA32;
		var result = new Texture2D(sw, sh, format, false);
		var currentRT = RenderTexture.active;
		var rt = new RenderTexture(sw, sh, 32);
		Graphics.Blit(_texture, rt);
		RenderTexture.active = rt;
		var source = new Rect(0, 0, rt.width, rt.height);
		result.ReadPixels(source, 0, 0);
		result.Apply();
		RenderTexture.active = currentRT;
		return result;
	}
}