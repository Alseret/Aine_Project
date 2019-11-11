using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_FindMesh : MonoBehaviour
{
	[SerializeField] private List<SkinnedMeshRenderer> ml_mesh;
	[SerializeField] private List<Transform> ml_trans;
	private Transform m_findTrans;

	// Start is called before the first frame update
	void Start()
	{
		ml_trans = GetAll(transform);

		ml_mesh = new List<SkinnedMeshRenderer>();
		foreach (Transform obj in ml_trans)
		{
			if (obj.GetComponent<SkinnedMeshRenderer>())
			{
				ml_mesh.Add(obj.GetComponent<SkinnedMeshRenderer>());
			}
		}
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