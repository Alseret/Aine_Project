using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

public class GameManager : MonoBehaviour
{
	[System.Serializable]
	public enum _ACTION_TYPE
	{
		Repeate,
		Order,
		AAA,
	}
	[System.Serializable]
	public enum _Evaluation
	{
		Excellent,
		Good,
		Nice,
	}

	[System.Serializable]
	public struct _Master
	{
		public _ACTION_TYPE type;
		public _Evaluation eva;
	}

	[SerializeField] public List<_Master> ml_master;
	[Separator]
	[SerializeField] public float m_SoundTime;
	[SerializeField] [ReadOnly] public float m_playTime;
	[SerializeField] private float m_fastTime;
	[SerializeField] private float m_slowTime;
	[SerializeField] public	 AudioClip m_clip;
	[SerializeField] public AudioSource m_audio;

	// Start is called before the first frame update
	private void Start()
	{
		ml_master = new List<_Master>();

		m_SoundTime = m_audio.clip.length;
	}

	// Update is called once per frame
	private void Update()
	{
		m_playTime = m_audio.time;
		GameSpeedController();
	}

	public void AddMaster(_ACTION_TYPE type, _Evaluation eva)
	{
		_Master work;
		work.type = type;
		work.eva = eva;
		ml_master.Add(work);
	}

	private void GameSpeedController()
	{
		if (Input.GetKey(KeyCode.T) || Input.GetKey("joystick button 5"))
			m_audio.pitch = Time.timeScale = m_fastTime;
		else if(Input.GetKey(KeyCode.Y) || Input.GetKey("joystick button 4"))
			m_audio.pitch = Time.timeScale = m_slowTime;
		else
			m_audio.pitch = Time.timeScale = 1f;
	}
}