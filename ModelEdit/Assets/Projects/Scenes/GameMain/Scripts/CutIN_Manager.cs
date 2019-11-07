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
		m_anim.SetBool("CutIn",Input.GetKey(KeyCode.Return));
		//m_anim.Play("CutIN");
	}
}