using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample_Rot : MonoBehaviour
{
	[SerializeField] private Vector3 m_rot;
	private RectTransform m_rect;
	//private Transform m_trans;

	// Start is called before the first frame update
	void Start()
	{
		if(GetComponent<RectTransform>())
			m_rect = GetComponent<RectTransform>();
	}

	// Update is called once per frame
	void Update()
	{
		if (m_rect)
			m_rect.Rotate(m_rot * Time.deltaTime);
		else if (!m_rect)
			transform.Rotate(m_rot * Time.deltaTime);
		//transform.Rotate(m_rot);
	}
}