using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fixed_Rot : MonoBehaviour
{
	[SerializeField] private Vector3 m_fixedRot;
	private RectTransform m_rect;

	// Start is called before the first frame update
	private void Start()
	{
		if (GetComponent<RectTransform>())
			m_rect = GetComponent<RectTransform>();
	}

	// Update is called once per frame
	private void LateUpdate()
	{
		if (m_rect)
			m_rect.eulerAngles = m_fixedRot;
		else if (!m_rect)
			transform.eulerAngles = m_fixedRot;
	}
}