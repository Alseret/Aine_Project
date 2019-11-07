using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[System.Serializable]
	public enum _ActionType
	{
		Repeate,
		AAA,
	}
	[System.Serializable]
	public enum _Evaluation
	{
		Excellent,
		Good,
		Normal,
	}

	[System.Serializable]
	public struct _Master
	{
		public _ActionType type;
		public _Evaluation eva;
	}

	[SerializeField] public List<_Master> m_master;
	[SerializeField] private AudioClip m_clip;
	[SerializeField] private AudioSource m_audio;

	// Start is called before the first frame update
	private void Start()
	{
		m_master = new List<_Master>();
		m_audio.PlayOneShot(m_clip);
	}

	// Update is called once per frame
	private void Update()
	{

	}
}