using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllFov : MonoBehaviour
{
	[SerializeField] private Camera[] m_cam;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		for (int i = 0; i < m_cam.Length; i++)
		{
			m_cam[i].fieldOfView = GetComponent<Camera>().fieldOfView;
		}
	}
}