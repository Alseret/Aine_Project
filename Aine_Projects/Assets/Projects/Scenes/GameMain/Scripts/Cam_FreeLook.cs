using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_FreeLook : MonoBehaviour
{
	[System.Serializable] 
	public enum InputType
	{
		Mouse,
		GamePad
	}
	[SerializeField] private InputType m_input;
	private Cinemachine.CinemachineFreeLook m_free;
	[SerializeField] private float m_speed;
	[SerializeField] private float m_minFov;
	[SerializeField] private float m_maxFov;
	private float m_zoom;
	// Start is called before the first frame update
	void Start()
	{
		m_free = GetComponent<Cinemachine.CinemachineFreeLook>();
	}

	// Update is called once per frame
	void Update()
	{
		//Debug.Log(Input.GetAxis("Horizontal"));
		switch (m_input)
		{
			case InputType.Mouse:
				m_zoom = Input.GetAxis("Mouse ScrollWheel");
				break;
			case InputType.GamePad:
				m_zoom = Input.GetAxis("Vertical2");
				break;
		}
		//if (Input.GetKey(KeyCode.UpArrow)) m_zoom = 1;
		//else if (Input.GetKey(KeyCode.UpArrow)) m_zoom = -1;
		m_free.m_Lens.FieldOfView += -m_zoom * m_speed;
		if(m_free.m_Lens.FieldOfView < m_minFov) m_free.m_Lens.FieldOfView = m_minFov;
		if(m_free.m_Lens.FieldOfView > m_maxFov) m_free.m_Lens.FieldOfView = m_maxFov;
	}
}