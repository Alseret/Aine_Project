using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_MaterialColor : MonoBehaviour
{
	[System.Serializable]
	public struct _Materil
	{
		public Transform name;
		public Image image;
		public Slider r;
		public Slider g;
		public Slider b;
	}
	[SerializeField] private GameObject m_parentPanel;
	[SerializeField] private _Materil[] m_mat;
	[SerializeField] private Material[] m_mats;

	// Start is called before the first frame update
	void Start()
	{
		for(int i = 0; i < m_parentPanel.transform.childCount; i++)
		{
			m_mat[i].name = m_parentPanel.transform.GetChild(i);
			m_mat[i].r = m_mat[i].name.GetChild(1).GetComponent<Slider>();
			m_mat[i].g = m_mat[i].name.GetChild(2).GetComponent<Slider>();
			m_mat[i].b = m_mat[i].name.GetChild(3).GetComponent<Slider>();
			m_mat[i].image = m_mat[i].name.GetChild(4).GetComponent<Image>();
		}
	}

	// Update is called once per frame
	void Update()
	{
		ChangeColor();
	}
	void ChangeColor()
	{
		for (int i = 0; i < m_mat.Length; i++)
		{
			m_mat[i].image.color = new Color(m_mat[i].r.value, m_mat[i].g.value, m_mat[i].b.value);
			m_mats[i].SetColor("_Emissive_Color", m_mat[i].image.color);
		}
	}
}