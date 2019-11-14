using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePad_Controller : MonoBehaviour
{
	[SerializeField] private float m_x;
	[SerializeField] private float m_y;
	[SerializeField] private float m_angle;
	[SerializeField] private Transform m_target;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		m_x = Input.GetAxis("Vertical2");
		m_y = Input.GetAxis("Horizontal2");
		if (m_x != 0f || m_y != 0f)
			m_angle = Mathf.Atan2(m_y, -m_x) * Mathf.Rad2Deg;
		if(m_target)
		{
			m_target.eulerAngles = new Vector3(0f, m_angle, 0f);
		}
	}
}