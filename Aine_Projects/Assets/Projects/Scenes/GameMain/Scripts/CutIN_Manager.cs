using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutIN_Manager : MonoBehaviour
{
	[SerializeField] private Animator m_anim;

	// Start is called before the first frame update
	void Start()
	{
		
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
}