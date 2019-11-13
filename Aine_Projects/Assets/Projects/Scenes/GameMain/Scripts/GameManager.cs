using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

public class GameManager : MonoBehaviour
{
	[System.Serializable]
	public enum _ControllType
	{
		Mouse,
		GamePad
	}
	[System.Serializable]
	public enum _ACTION_TYPE
	{
		Repeate,
		Order,
		Timing,
		MAX__,
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
		public int count;
		public _Evaluation eva;
	}
	[SerializeField] public _ControllType m_controll;
	[SerializeField] private GameObject[] m_contObj;
	[SerializeField] public List<_Master> ml_master;
	[Separator]
	[SerializeField] public float m_SoundTime;
	[SerializeField] [ReadOnly] public float m_playTime;
	[SerializeField] private float m_fastTime;
	[SerializeField] private float m_slowTime;
	[SerializeField] public AudioClip m_clip;
	[SerializeField] public AudioSource m_audio;

	// Start is called before the first frame update
	private void Start()
	{
		ChangeControll();
		ml_master = new List<_Master>();
		m_audio.clip = m_clip;
		m_audio.Play();
		m_SoundTime = m_audio.clip.length;
	}

	// Update is called once per frame
	private void Update()
	{
		m_playTime = m_audio.time;
		GameSpeedController();
	}
	public void ChangeControll()
	{
		switch (m_controll)
		{
			case _ControllType.Mouse:
				m_contObj[0].SetActive(true);
				m_contObj[1].SetActive(false);
				break;
			case _ControllType.GamePad:
				m_contObj[0].SetActive(false);
				m_contObj[1].SetActive(true);
				break;
		}
	}
	public void AddMaster(_ACTION_TYPE type, int cnt, _Evaluation eva)
	{
		_Master work;
		work.type = type;
		work.count = cnt;
		work.eva = eva;
		ml_master.Add(work);
	}

	private void GameSpeedController()
	{
		if (!FastSpeed() && !SlowSpeed())
			m_audio.pitch = Time.timeScale = 1f;
		else if (FastSpeed() && SlowSpeed())
			m_audio.pitch = Time.timeScale = 0f;
		else if (FastSpeed())
			m_audio.pitch = Time.timeScale = m_fastTime;
		else if (SlowSpeed())
			m_audio.pitch = Time.timeScale = m_slowTime;
	}
	private bool FastSpeed()
	{
		if (Input.GetKey(KeyCode.T) || Input.GetKey("joystick button 5"))
			return true;
		return false;
	}
	private bool SlowSpeed()
	{
		if (Input.GetKey(KeyCode.Y) || Input.GetKey("joystick button 4"))
			return true;
		return false;
	}
}