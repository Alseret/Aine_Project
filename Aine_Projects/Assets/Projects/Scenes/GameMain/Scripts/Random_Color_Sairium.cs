using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Color_Sairium : MonoBehaviour
{
	[SerializeField] private Color m_color;
	[SerializeField] private Transform[] m_target;
	[SerializeField] private Material m_mat;
	[SerializeField] private float m_emissive;
	[SerializeField] private float[] m_slider;

    // Start is called before the first frame update
    void Start()
    {
		m_slider = new float[3];
		m_target[0].GetComponent<MeshRenderer>().material = m_mat;
		m_target[1].GetComponent<MeshRenderer>().material = m_mat;
		m_color = Color.HSVToRGB(Random.Range(0f, 1f), 1f, 1f);
	}

    // Update is called once per frame
    void Update()
	{
		//m_color = Color.HSVToRGB(m_slider[0], m_slider[1], m_slider[2]);
		m_target[0].GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", m_color * m_emissive);
		m_target[1].GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", m_color * m_emissive);
    }
}
