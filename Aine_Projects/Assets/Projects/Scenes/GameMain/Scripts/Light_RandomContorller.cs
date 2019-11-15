using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_RandomContorller : MonoBehaviour
{
	[SerializeField] private float m_randTime;
	[SerializeField] private float m_rotTime;
	private float m_rotY;
	private float m_rotZ;

	// Start is called before the first frame update
	void Start()
	{
		Debug.Log("AAA!");
		StartCoroutine(ChangeRot());
	}

	// Update is called once per frame
	void Update()
	{
		m_rotY = Mathf.MoveTowards(m_rotY, transform.localEulerAngles.y, m_rotTime);
		m_rotZ = Mathf.MoveTowards(m_rotZ, transform.localEulerAngles.y, m_rotTime);
		transform.localEulerAngles = new Vector3(0f, m_rotY, m_rotZ);
	}
	private IEnumerator ChangeRot()
	{
		yield return new WaitForSeconds(m_randTime);
		Debug.Log("HEY!!");
		m_rotY = Random.Range(-86f, 86f);
		m_rotZ = Random.Range(-9f, 56f);
		StartCoroutine(ChangeRot());

	}
}