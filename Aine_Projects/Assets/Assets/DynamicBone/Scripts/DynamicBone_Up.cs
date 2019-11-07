using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBone_Up : MonoBehaviour
{
	[SerializeField] private List<DynamicBone> ml_bone;
	private List<Transform> ml_trans;
	[SerializeField] private bool m_isBone = true;
	[Header("揺れ(小刻み-大振り)")]
	[SerializeField, Range(0, 1)] private float m_damping;
	private float m_oldDamping;
	[Header("弾性力(ゆっくり-素早く)")]
	[SerializeField, Range(0, 1)] private float m_elasticity;
	private float m_oldElasticity;
	[Header("揺れ幅(大きく-小さく)")]
	[SerializeField, Range(0, 1)] private float m_stiffness;
	private float m_oldStiffness;
	[Header("慣性(小さい-大きい)")]
	[SerializeField, Range(0, 1)] private float m_inert;
	private float m_oldInert;

	// Start is called before the first frame update
	private void Start()
	{
		ml_trans = GetAll(transform);
		ml_bone = new List<DynamicBone>();
		foreach (Transform obj in ml_trans)
		{
			if(obj.GetComponent<DynamicBone>())
			{
				ml_bone.Add(obj.GetComponent<DynamicBone>());
			}
		}

		if (m_damping + m_elasticity + m_stiffness + m_inert == 0f)
		{
			m_damping = ml_bone[0].m_Damping;
			m_elasticity = ml_bone[0].m_Elasticity;
			m_stiffness = ml_bone[0].m_Stiffness;
			m_inert = ml_bone[0].m_Inert;
		}

		// 使用フラグ
		if(!m_isBone)
		{
			foreach(DynamicBone obj in ml_bone)
			{
				obj.enabled = false;
			}
		}
	}

	// Update is called once per frame
	private void Update()
	{
		DampingValue(m_damping);
		ElasticityValue(m_elasticity);
		StiffnessValue(m_stiffness);
		InertValue(m_inert);
	}

	private void DampingValue(float value)
	{
		if (m_oldDamping == value) return;
		foreach (DynamicBone obj in ml_bone)
			obj.m_Damping = value;
		m_oldDamping = value;
	}
	private void ElasticityValue(float value)
	{
		if (m_oldElasticity == value) return;
		foreach (DynamicBone obj in ml_bone)
			obj.m_Damping = value;
		m_oldElasticity = value;
	}
	private void StiffnessValue(float value)
	{
		if (m_oldStiffness == value) return;
		foreach (DynamicBone obj in ml_bone)
			obj.m_Damping = value;
		m_oldStiffness = value;
	}
	private void InertValue(float value)
	{
		if (m_oldInert == value) return;
		foreach (DynamicBone obj in ml_bone)
			obj.m_Damping = value;
		m_oldInert = value;
	}

	public List<Transform> GetAll(Transform obj)
	{
		List<Transform> allChild = new List<Transform>();
		GetChildren(obj, ref allChild);
		return allChild;
	}

	// 子要素検索
	public void GetChildren(Transform obj, ref List<Transform> allChild)
	{
		Transform child = obj.GetComponentInChildren<Transform>();

		if (child.childCount == 0)
			return;

		foreach (Transform ob in child)
		{
			allChild.Add(ob);
			GetChildren(ob, ref allChild);
		}
	}
}