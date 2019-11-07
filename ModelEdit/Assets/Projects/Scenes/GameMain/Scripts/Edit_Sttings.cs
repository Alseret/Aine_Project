using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ToonyColorsPro.Demo;

public class Edit_Sttings : MonoBehaviour
{
	[Header("Material")]
	[SerializeField] GameObject m_materialPanel;
	[SerializeField] TCP2_Demo_Camera m_demo;
	private bool m_isUsed;
	[Header("Deffault")]
	[SerializeField] private OpenFolder_Copy m_def;
	[Header("Animation")]
	[SerializeField] private Toggle m_animPlay;
	[SerializeField] private Text m_animText;
	[SerializeField] private Animator[] m_animator;
	[Header("Reset")]
	[SerializeField] private Button m_resetB;
	[SerializeField] private Transform m_pivot;

	// Start is called before the first frame update
	private void Awake()
	{
		m_def = GetComponent<OpenFolder_Copy>();
		m_isUsed = false;
	}

	// Update is called once per frame
	private void Update()
	{

	}
	public void LoadTexture()
	{
		m_def.DeffMaterial();
	}
	public void MaterialColor()
	{
		m_isUsed = !m_isUsed;
		m_materialPanel.SetActive(m_isUsed);
		m_demo.enabled = !m_isUsed;
	}
	public void NextMotion()
	{
		StartCoroutine(nextMotion());
	}
	IEnumerator nextMotion()
	{
		m_animator[0].SetBool("Next", true);
		m_animator[1].SetBool("Next", true);
		yield return null;
		m_animator[0].SetBool("Next", false);
		m_animator[1].SetBool("Next", false);
	}
	// モーション
	public void PlayMotion(bool play)
	{
		switch (m_animPlay.isOn)
		{
			case true:
				m_animText.text = "Play";
				m_animator[0].speed = 1f;
				m_animator[1].speed = 1f;
				break;
			case false:
				m_animText.text = "Stop";
				m_animator[0].speed = 0f;
				m_animator[1].speed = 0f;
				break;
		}
	}
	// リセット
	public void AllReset()
	{
		Camera.main.transform.position = new Vector3(0f, 1.5f, -2.5f);
		Camera.main.transform.eulerAngles = Vector3.zero;
		m_pivot.position = Vector3.zero;
	}
}