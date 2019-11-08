using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRot : MonoBehaviour
{
	private RectTransform m_rect;
	private float m_speed;
	// Start is called before the first frame update
	void Start()
	{
		m_rect = GetComponent<RectTransform>();
		m_speed = Random.Range(.1f, 4f);
	}

	// Update is called once per frame
	void Update()
	{
		m_rect.Rotate(Vector3.up * m_speed);
	}
}