using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Order_Data : MonoBehaviour
{
	[SerializeField] public List<Param> m_list;
	[SerializeField] public List<Param> m_listCopy;

	[System.SerializableAttribute]
	public struct Param
	{
		public string text;
		public List<Char> Moji;
	}

	[System.SerializableAttribute]
	public struct Char
	{
		public int num;
		public string text;
	}
	private void Start()
	{
		for (int i = 0; i < m_list.Count; i++)
		{
			Param work = m_list[i];
			work.text = m_list[i].Moji[0].text + " " +
						m_list[i].Moji[1].text + " " +
						m_list[i].Moji[2].text + " " +
						m_list[i].Moji[3].text;
			m_list[i] = work;
		}
	}
}