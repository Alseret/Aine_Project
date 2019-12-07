using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBone_AutoSetting : MonoBehaviour
{
	[SerializeField] private Transform m_target;
	[SerializeField] private GameObject m_prefab;
	
	[SerializeField] private List<Transform> ml_trans;
	[SerializeField] private List<GameObject> ml_dynamic;
	[SerializeField] private List<Transform> ml_myTrans;


	private void Awake()
	{
		ml_trans = new List<Transform>();
		ml_trans = GetAll(m_target);    // オブジェクト検索
		//for(int i = 0; i < ml_trans.Count; i++)
		//{
		//	GameObject work;
		//	if (i == 0)
		//		work = Instantiate(m_prefab, transform);
		//	else
		//		work = Instantiate(m_prefab, ml_dynamic[i - 1].transform);
		//	work.transform.name = ml_trans[i].name + "_D";
		//	work.GetComponent<DynamicBone>().m_Root = ml_trans[i];
		//	ml_dynamic.Add(work);
		//}
		ml_myTrans = new List<Transform>();
		ml_myTrans = GetAll(transform);
		ml_myTrans[0] = transform;
		for (int i = 0; i < ml_myTrans.Count; i++)
		{
		}
		int dynamicCnt = 0;
		foreach (Transform obj in ml_myTrans)
		{
			obj.GetComponent<DynamicBone>().m_Root = ml_trans[dynamicCnt];
			dynamicCnt++;
		}
	}

	private List<Transform> GetAll(Transform obj)
	{
		List<Transform> allChild = new List<Transform>();
		allChild.Add(m_target);
		GetChildren(obj, ref allChild);
		return allChild;
	}

	// 子要素検索
	private void GetChildren(Transform obj, ref List<Transform> allChild)
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