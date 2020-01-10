using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Controller : MonoBehaviour
{
	[System.Serializable]
	public enum Anim
	{
		SAKO01_Final,
		SIMO01_Final,
		NOT01_Final,
		NONE,
	}
	[SerializeField] private Animator m_anim;
	[SerializeField] private float m_animeSpeed;
	[SerializeField] private Anim m_num;

	// Start is called before the first frame update
	void Start()
	{
		m_anim = GetComponent<Animator>();
		m_animeSpeed = m_anim.GetCurrentAnimatorStateInfo(0).speed;
		switch (m_num)
		{
			case Anim.SAKO01_Final:
				m_anim.Play("SAKO_Final", 0, .01f);
				break;
			case Anim.SIMO01_Final:
				m_anim.Play("SIMO_Final", 0, .01f);
				break;
			case Anim.NOT01_Final:
				m_anim.Play("NOT_Final", 0, .01f);
				//m_anim.CrossFade("NOT_Final", 0, 0, .1f);
				break;
			case Anim.NONE:
				//m_anim.CrossFade("NOT_Final", 0, 0, .1f);
				break;
		}
	}

	// Update is called once per frame
	void Update()
	{
	}
	public void AnimSpeed(float speed, float multiply)
	{
		m_anim.speed = m_animeSpeed * (speed * multiply);
	}
}