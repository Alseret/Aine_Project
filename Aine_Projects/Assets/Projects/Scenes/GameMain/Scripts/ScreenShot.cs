using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScreenShot : MonoBehaviour
{
	[SerializeField] private Texture2D m_tex;
	[SerializeField] private Sprite m_sprite;
	[SerializeField] private Image m_target;

	// Start is called before the first frame update
	void Start()
	{
		//Directory.CreateDirectory(@"Assets/Resources/ScreenShot");
		m_target = GameObject.Find("Result_Capture").GetComponent<Image>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.B))
			StartCoroutine(imageShot());
		if (Input.GetKeyDown(KeyCode.N))
		{
			m_target.sprite = 
				Sprite.Create(m_tex, new Rect(0f, 0f, m_tex.width, m_tex.height), Vector2.zero, 1f);
		}
	}

	private IEnumerator imageShot()
	{
		yield return new WaitForEndOfFrame();
		string name = DateTime.Now.ToString("HH:mm:ss") + ".jpg";
		m_tex = new Texture2D((int)Screen.width, (int)Screen.height, TextureFormat.RGB24, false);
		m_tex.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height), 0, 0);
		m_tex.Apply();

		//Directory.CreateDirectory(@"Assets/Resources/ScreenShot");
		//string image_path = "Assets/Resources/ScreenShot/" + name;
		//byte[] pngdata = m_tex.EncodeToPNG();
		//File.WriteAllBytes(image_path, pngdata);

		m_sprite = Sprite.Create(m_tex, new Rect(0f, 0f, m_tex.width, m_tex.height), new Vector2(.5f, .5f), 1f);
		yield return null;
	}
//	~ScreenShot()
//	{
//		//ScreenShotフォルダごとディスク上から削除
//		Directory.Delete(@"Assets/Resources/ScreenShot", true);
//	}
}