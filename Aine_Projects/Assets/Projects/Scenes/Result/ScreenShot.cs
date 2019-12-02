using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenShot : MonoBehaviour
{
	[SerializeField] private Texture2D m_tex;
	[SerializeField] public List<Sprite> m_sprite;

	// Start is called before the first frame update
	void Start()
	{
		//m_target = GameObject.Find("Result_Capture").GetComponent<Image>();
		m_sprite = new List<Sprite>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.B))
			StartCoroutine(imageShot());
	}

	public IEnumerator imageShot()
	{
		yield return new WaitForEndOfFrame();
		string name = DateTime.Now.ToString("HH:mm:ss") + ".jpg";
		m_tex = new Texture2D((int)Screen.width, (int)Screen.height, TextureFormat.RGB24, false);
		m_tex.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height), 0, 0);
		m_tex.Apply();
		m_sprite.Add(Sprite.Create(m_tex, new Rect(0f, 0f, m_tex.width, m_tex.height), new Vector2(.5f, .5f), 1f));

		yield return null;
	}
}