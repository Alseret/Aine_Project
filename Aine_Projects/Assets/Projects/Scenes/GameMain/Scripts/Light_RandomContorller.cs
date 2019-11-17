using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_RandomContorller : MonoBehaviour
{
	[SerializeField] private float m_randTime;
	[SerializeField] private float m_rotTime;
	private Vector3 m_rot;
	private float m_rotY;
	private float m_rotZ;

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(ChangeRot());
	}

	// Update is called once per frame
	void Update()
	{
		//m_rotY = Mathf.MoveTowards(m_rotY, transform.localEulerAngles.y, m_rotTime);
		//m_rotZ = Mathf.MoveTowards(m_rotZ, transform.localEulerAngles.z, m_rotTime);
		transform.localEulerAngles = Vector3.MoveTowards(transform.localEulerAngles, m_rot, m_rotTime);
	}
	private IEnumerator ChangeRot()
	{
		yield return new WaitForSeconds(m_randTime);
		m_rot.y = Random.Range(-86f, 86f);
		m_rot.z = Random.Range(-9f, 56f);
		StartCoroutine(ChangeRot());

	}
}