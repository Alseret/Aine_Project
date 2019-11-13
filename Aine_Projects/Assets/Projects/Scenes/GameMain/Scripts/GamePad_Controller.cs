using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePad_Controller : MonoBehaviour
{
	[SerializeField] private float m_vertical;
	[SerializeField] private float m_horizontal;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		m_vertical = Input.GetAxis("Vertical");
		m_horizontal = Input.GetAxis("Horizontal");
	}
}