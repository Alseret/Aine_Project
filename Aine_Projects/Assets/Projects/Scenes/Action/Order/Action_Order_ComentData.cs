using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Order_ComentData : ScriptableObject
{
	[System.SerializableAttribute]
	public class Param
	{
		//public Num success;
		//public Text text;
		public int[] num;
		public string[] text;
	}
	[System.SerializableAttribute]
	public struct Num
	{
		public int num1;
		public int num2;
		public int num3;
		public int num4;
	}
	[System.SerializableAttribute]
	public struct Text
	{
		public string text1;
		public string text2;
		public string text3;
		public string text4;
	}
}