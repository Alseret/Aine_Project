using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutIN_Manager : MonoBehaviour
{
	[SerializeField] private Animator m_anim;
	[SerializeField][Range(0, 9)] public float m_cnt;
	[SerializeField] private Image[] m_gage;

	// Start is called before the first frame update
	void Start()
	{
		m_gage = new Image[10];
		for (int i = 0; i < 10; i++)
		{
			m_gage[i] = transform.GetChild(0).
									GetChild(0).
									GetChild(0).
									GetChild(0).
									GetChild(i).GetComponent<Image>();
		}
		ResetGage();
	}

	// Update is called once per frame
	void Update()
	{
		//if(Input.GetKeyDown(KeyCode.Return))
		//{
		//	m_anim.SetBool("CutIN", true);
		//}
		//m_anim.SetBool("CutIn", m_display);
		//m_anim.Play("CutIN");
		//if (Input.GetKey(KeyCode.Alpha1))
		//	m_anim.Play("CutIN_Open");
		//if (Input.GetKey(KeyCode.Alpha2))
		//	m_anim.Play("CutIN_Open");
	}
	public void PlayAnim(bool flag)
	{
		m_anim.SetBool("CutIn", flag);
	}
	public void ChangeGage()
	{
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			m_cnt--;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			m_cnt++;
		}
		if (m_cnt <= 0f) m_cnt = 0f;
		else if (m_cnt >= 10.5f) m_cnt = 10.5f;
		for (int i = 0; i < 10; i++)
		{
			m_gage[i].enabled = true;
		}
		for (int i = 9; i > (int)m_cnt; i--)
		{
			m_gage[i].enabled = false;
		}
	}
	public void DecrementCnt(float cnt)
	{
		m_cnt -= cnt;
	}
	public void ResetGage()
	{
		m_cnt = 0f;
		for (int i = 0; i < 10; i++)
		{
			m_gage[i].enabled = true;
		}
	}
}