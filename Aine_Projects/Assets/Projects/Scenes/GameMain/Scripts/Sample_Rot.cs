using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample_Rot : MonoBehaviour
{
	[SerializeField] private Vector3 m_rot;
	private RectTransform m_rect;

	// Start is called before the first frame update
	void Start()
	{
		m_rect = GetComponent<RectTransform>();
	}

	// Update is called once per frame
	void Update()
	{
		m_rect.Rotate(m_rot);
		//transform.Rotate(m_rot);
	}
}