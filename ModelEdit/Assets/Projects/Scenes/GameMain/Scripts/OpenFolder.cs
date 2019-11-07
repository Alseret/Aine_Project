using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.IO;

public class OpenFolder : MonoBehaviour
{
	[SerializeField] private Text m_text;
	[SerializeField] private Image m_img;
	[SerializeField] private Texture m_texture;
	[SerializeField] private Texture2D m_tex2D;
	[SerializeField] private Texture2D m_defTexture;
	[SerializeField] private Material m_mat;
	[SerializeField] private bool m_bool;
	[SerializeField] private Text m_checkFile;


	// Start is called before the first frame update
	void Start()
    {

    }

	string path = "AAAA";
	// Update is called once per frame
	void Update()
	{

		//if (Input.GetKeyDown(KeyCode.R) && !Input.GetKey(KeyCode.LeftShift))
		//{
		//	DeleteTexture("test");
		//	CopyTexture("test");
		//}
		if (Input.GetKeyDown(KeyCode.R) && Input.GetKey(KeyCode.LeftShift))
		{
			m_tex2D = m_defTexture;
			m_img.sprite = Sprite.Create(m_defTexture, new Rect(0f, 0f, m_defTexture.width, m_defTexture.height), Vector2.zero);
			m_mat.mainTexture = m_defTexture;
		}
		if (Input.GetKeyDown(KeyCode.Return))
		{
			//Texture readBinary = null;
			DeleteTexture("test");
			path = CopyTexture("test");
			//CopyTexture("test");
			//Texture readBinary = ReadTexture(path); ;
			////readBinary = ReadTexture(path);
			//m_text.text = "Path : " + path;

			//if (readBinary != null)
			{
				//Debug.Log("Create!");
				StartCoroutine(SpriteUp());
				//m_checkFile.text = "Read_1";
				//m_mat.mainTexture = readBinary;
				//m_checkFile.text = "Read_2";
				//m_img.sprite =
				//	Sprite.Create(ToTexture2D(readBinary), new Rect(0f, 0f, readBinary.width, readBinary.height), Vector2.zero);
				//m_checkFile.text = "Read_3";

			}
			//else
			//	m_text.text = "Null";
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (System.IO.File.Exists(path))
			{
				m_bool = true;
				m_checkFile.text = "true";
			}
			else
			{
				m_bool = false;
				m_checkFile.text = "false";
			}
		}
	}
	IEnumerator SpriteUp()
	{
		yield return new WaitForSeconds(2f);
		Texture readBinary = ReadTexture(path); ;
		//readBinary = ReadTexture(path);
		m_text.text = "Path : " + path;
		yield return new WaitForSeconds(1f);
		m_checkFile.text = "Read_1";
		m_img.sprite =
			Sprite.Create(ToTexture2D(readBinary), new Rect(0f, 0f, readBinary.width, readBinary.height), Vector2.zero);
		yield return new WaitForSeconds(1f);
		m_checkFile.text = "Read_2";
		m_mat.mainTexture = readBinary;
		yield return new WaitForSeconds(1f);
		m_checkFile.text = "Read_3";
	}

	private void DeleteTexture(string path)
	{
		string AppPath = Application.dataPath;
#if UNITY_EDITOR       // Editor
		AppPath = AppPath.Replace("/Assets", "") + "/" + path;
		//m_text.text = AppPath + "_copy.png";
#elif UNITY_STANDALONE   // Exe
		AppPath =  AppPath.Replace("/ModelEdit_Data", "") + "/" + path;
		//m_text.text = AppPath + "_copy.png";
#endif
		if (System.IO.File.Exists(AppPath + "_copy.png"))
		{
			Debug.Log("Delete!");
			//m_text.text = "Copy";
			File.Delete(AppPath + "_copy.png");
			//return;
		}
	}
	string CopyTexture(string path)
	{
		string AppPath = Application.dataPath;

#if UNITY_EDITOR       // Editor
		AppPath = AppPath.Replace("/Assets", "") + "/" + path;
		//m_text.text = AppPath + "_copy.png";
#elif UNITY_STANDALONE   // Exe
		AppPath =  AppPath.Replace("/ModelEdit_Data", "") + "/" + path;
		//m_text.text = AppPath + "_copy.png";
#endif
		//if (System.IO.File.Exists(AppPath + "_copy.png"))
		//{
		//	Debug.Log("Delete!");
		//	//m_text.text = "Copy";
		//	File.Delete(AppPath + "_copy.png");
		//	//return;
		//}
		File.Copy(AppPath + ".png", AppPath + "_copy.png");
		return AppPath + "_copy.png";
	}

	byte[] m_data;
	Texture ReadTexture(string path)
	{
		ReadFiles(path);
		byte[] readBinary = m_data;

		Texture2D texture = new Texture2D(1,1);
		texture.LoadImage(readBinary);

		return texture;
	}
	void ReadFiles(string path)
	{
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryReader bin = new BinaryReader(fileStream);
		m_data = bin.ReadBytes((int)bin.BaseStream.Length);
	}

	async void ReadFile(string path)
	{
		//m_text.text = "Null";
		//FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

		////m_text.text = path;
		//BinaryReader bin = new BinaryReader(fileStream);

		//byte[] values = bin.ReadBytes((int)bin.BaseStream.Length);

		//byte[] values;
		m_data = null;
		using (var fs = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read))
		{
			m_data = new byte[fs.Length];

			await fs.ReadAsync(m_data, 0, (int)fs.Length);
		}
	}

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
