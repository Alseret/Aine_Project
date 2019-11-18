using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectionProbe : MonoBehaviour
{
	[SerializeField] private Transform m_cam;
	private ReflectionProbe m_probe;
	//private Transform m_cam;

	// Start is called before the first frame update
	void Start()
	{
		m_probe = GetComponent<ReflectionProbe>();
		//m_cam = Camera.main.transform;
	}

	// Update is called once per frame
	void Update()
	{
		m_probe.transform.position = new Vector3(m_cam.position.x, -m_cam.position.y, m_cam.position.z);
	}
}