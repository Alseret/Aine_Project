using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_FreeLook : MonoBehaviour
{
	private Cinemachine.CinemachineFreeLook m_free;
	[SerializeField] private float m_speed;
	[SerializeField] private float m_minFov;
	[SerializeField] private float m_maxFov;
	// Start is called before the first frame update
	void Start()
	{
		m_free = GetComponent<Cinemachine.CinemachineFreeLook>();
	}

	// Update is called once per frame
	void Update()
	{
		m_free.m_Lens.FieldOfView += Input.GetAxis("Vertical2") * m_speed;
		if(m_free.m_Lens.FieldOfView < m_minFov) m_free.m_Lens.FieldOfView = m_minFov;
		if(m_free.m_Lens.FieldOfView > m_maxFov) m_free.m_Lens.FieldOfView = m_maxFov;
	}
}