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
}