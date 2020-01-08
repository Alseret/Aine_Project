using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade_IO : MonoBehaviour
{
	[SerializeField] private Image m_panel;
	[SerializeField] private Image m_icon;
	[SerializeField] private float m_alpha;
	[SerializeField] private bool m_fadeIn;
	[SerializeField] private bool m_fadeOut;
	[SerializeField] private float m_add;
	private string m_next;

	// Start is called before the first frame update
	void Start()
	{
		DontDestroyOnLoad(this.gameObject);
		m_fadeIn = true;
		m_fadeOut = false;
		m_panel.color = new Color(0f, 0f, 0f, 0f);
		m_icon.color = new Color(1f, 1f, 1f, 0f);
	}

	// Update is called once per frame
	void Update()
	{
		if(m_fadeIn)
		{
			if(m_alpha <= 2f)
				m_alpha += m_add;
			else
			{
				SceneManager.LoadScene(m_next);
				m_fadeIn = false;
				m_fadeOut = true;
			}
			m_panel.color = new Color(0f, 0f, 0f, m_alpha);
			m_icon.color = new Color(1f, 1f, 1f, m_alpha);
		}
		else if (m_fadeOut)
		{
			if (m_alpha >= 0f)
				m_alpha -= m_add;
			else
			{
				m_fadeIn = false;
				m_fadeOut = false;
				Destroy(gameObject);
			}
			m_panel.color = new Color(0f, 0f, 0f, m_alpha);
			m_icon.color = new Color(1f, 1f, 1f, m_alpha);
		}
	}
	public void FadeIn(string name)
	{
		m_next = name;
		//SceneManager.LoadScene(name);
	}
}