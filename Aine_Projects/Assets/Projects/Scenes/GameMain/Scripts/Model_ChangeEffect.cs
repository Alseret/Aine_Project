using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_ChangeEffect : MonoBehaviour
{
	[System.Serializable]
	private enum MODEL_TYPE
	{
		Normal,
		Red,
		Blue,
		Pink,
	}
	[System.Serializable]
	private struct MODEL_PART
	{
		public MODEL_TYPE type;
		public SkinnedMeshRenderer[] body; 
		public SkinnedMeshRenderer[] hair;
		public SkinnedMeshRenderer[] cloth;
		public SkinnedMeshRenderer[] cloth1;
		public SkinnedMeshRenderer[] headphone;
		public SkinnedMeshRenderer[] eye;
	}
	[System.Serializable]
	private struct MODEL_MAT
	{
		public MODEL_TYPE type;
		public Material[] mat;
	}
	[SerializeField] private MODEL_TYPE m_type;
	[SerializeField] private MODEL_MAT[] m_mat;
	[SerializeField] private MODEL_PART[] m_part;
	[SerializeField] private Material[] m_clothNormalMat;
	[SerializeField] private Material[] m_clothRedMat;
	[SerializeField] private Material[] m_clothBlueMat;
	[SerializeField] private Material[] m_clothPinkMat;

	// Start is called before the first frame update
	private void Start()
	{
		
	}

	// Update is called once per frame
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
			StartCoroutine(ChangeEffect(0));
		if (Input.GetKeyDown(KeyCode.Alpha2))
			StartCoroutine(ChangeEffect(1));
		if (Input.GetKeyDown(KeyCode.Alpha3))
			StartCoroutine(ChangeEffect(2));
		if (Input.GetKeyDown(KeyCode.Alpha4))
			StartCoroutine(ChangeEffect(3));
	}
	private void ChangeMaterial(int num)
	{
		for (int i = 0; i < m_part[num].body.Length; i++)
			m_part[num].body[i].material = m_mat[num].mat[0];
		for (int i = 0; i < m_part[num].hair.Length; i++)
			m_part[num].hair[i].material = m_mat[num].mat[1];
		for (int i = 0; i < m_part[num].cloth.Length; i++)
			m_part[num].cloth[i].material = m_mat[num].mat[2];
		m_part[num].headphone[0].material = m_mat[num].mat[3];
		m_part[num].eye[0].material = m_mat[num].mat[4];

		for (int i = 0; i < m_part[num].cloth.Length; i++)
			m_part[num].cloth[i].material.SetColor("_Emissive_Color", Color.black);
		for (int i = 0; i < m_part[num].hair.Length; i++)
			m_part[num].hair[i].material.SetColor("_Color", Color.black);

		switch (num)
		{
			case 0:
				m_part[3].cloth[9].materials = m_clothNormalMat;
				break;
			case 1:
				m_part[3].cloth[9].materials = m_clothRedMat;
				break;
			case 2:
				m_part[3].cloth[9].materials = m_clothBlueMat;
				break;
			case 3:
				m_part[3].cloth[9].materials = m_clothPinkMat;
				break;
		}
	}
	[SerializeField] private float m_changeTime;
	public IEnumerator ChangeEffect(int num)
	{
		StartCoroutine( MaterialLight(num));
		yield return new WaitForSeconds(m_changeTime);
		ChangeMaterial(num);
	}
	[SerializeField] private Color m_color;
	[SerializeField] private float m_addColor;
	private IEnumerator MaterialLight(int num)
	{
		for (int i = 0; i < m_part[num].cloth.Length; i++)
			m_part[num].cloth[i].material.SetColor("_Emissive_Color", Color.white * 5f);
		for (int i = 0; i < m_part[num].hair.Length; i++)
			m_part[num].hair[i].material.SetColor("_Color", Color.white);
		yield return null;
	}
	private void Material_Light(int num)
	{

		for (int i = 0; i < m_part[num].cloth.Length; i++)
			m_part[num].cloth[i].material.SetColor("_Emissive_Color", m_color);
		for (int i = 0; i < m_part[num].hair.Length; i++)
			m_part[num].hair[i].material.SetColor("_Color", m_color);
		m_color.r += m_addColor * Time.deltaTime;
		m_color.g += m_addColor * Time.deltaTime;
		m_color.b += m_addColor * Time.deltaTime;
		Debug.Log("Color");
		if (m_color.r <= 1f) Material_Light(num);
	}
}