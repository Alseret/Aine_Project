using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector_Rot : MonoBehaviour
{
	[SerializeField] private Vector3 m_rot;
	[SerializeField] private bool m_hit;
	[SerializeField] private Transform m_target;
	[SerializeField] private Transform m_light;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		Ray ray = new Ray(transform.position, Vector3.down);
		RaycastHit hit;

		Debug.DrawLine(ray.origin, ray.direction * 100, Color.red);

		m_hit = false;
		if (Physics.Raycast(ray, out hit, 100))
		{
			if(hit.collider.tag == "Plane")
			{
				m_hit = true;
				m_light.position = new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z);
				m_light.eulerAngles = new Vector3(90f, 0f, 0f);
				m_target.position = hit.point;
			}
		}
	}
}