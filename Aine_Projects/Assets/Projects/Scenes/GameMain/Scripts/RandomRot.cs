using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRot : MonoBehaviour
{
	private RectTransform m_rect;
	private float m_speed;
	[SerializeField] private float m_maxSpeed;
	[SerializeField] private float m_minSpeed;
	// Start is called before the first frame update
	void Start()
	{
		m_rect = GetComponent<RectTransform>();
		m_speed = Random.Range(m_minSpeed, m_maxSpeed);
	}

	// Update is called once per frame
	void Update()
	{
		m_rect.Rotate(Vector3.up * m_speed * Time.deltaTime);
	}
}