using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Color_Sairium : MonoBehaviour
{
	[SerializeField] private Color m_color;
	[SerializeField] private Transform[] m_target;
	[SerializeField] private Material m_mat;
	[SerializeField] private float m_emissive;

    // Start is called before the first frame update
    void Start()
    {
		m_target[0].GetComponent<MeshRenderer>().material = m_mat;
		m_target[1].GetComponent<MeshRenderer>().material = m_mat;
	}

    // Update is called once per frame
    void Update()
    {
		m_target[0].GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", m_color * m_emissive);
		m_target[1].GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", m_color * m_emissive);
    }
}
