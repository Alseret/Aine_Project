using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyBox;

public class Action_Nav : MonoBehaviour
{
	[System.Serializable]
	public enum ACTION_TYPE
	{
		Repeat,
	}
	[System.Serializable]
	public struct ActionPoint
	{
		public ACTION_TYPE m_actionType;
		public float time;
		public bool used;
	}
	[System.Serializable]
	public struct ActionType
	{
		public Action_Repeated repeate;
	}
	[SerializeField] private Slider m_slider;
	private GameManager m_manager;
	[SerializeField] private ActionType m_type;
	[SerializeField] public List<ActionPoint> ml_action;
	private AudioSource m_audio;
	[SerializeField] private float m_SoundTime;
	[SerializeField] [ReadOnly] private float m_playTime;
	//[SerializeField] private float m_timeScale;
	[SerializeField] private GameObject m_rectPrefab;

	// Start is called before the first frame update
	void Start()
	{
		m_manager = GetComponent<GameManager>();
		m_audio = GetComponent<AudioSource>();
		// 180 + 55 235
		Generate_Nav();
	}

	// Update is called once per frame
	void Update()
	{
		m_slider.maxValue = m_SoundTime;
		//FastMusic(Input.GetKey(KeyCode.T));
		m_playTime = m_audio.time;
		Action_SliderNav();
		PlayAction();
	}
	//private void FastMusic(bool t)
	//{
	//	if(t)
	//	{
	//		m_audio.pitch = Time.timeScale = m_timeScale;
	//	}
	//	else
	//	{
	//		m_audio.pitch = Time.timeScale = 1f;
	//	}

	//	//m_audio.pitch = m_timeScale *Time.deltaTime;
	//}
	private void Action_SliderNav()
	{
		m_slider.value = m_playTime;
		//foreach (ActionPoint action in ml_action)
		//{
		//	m_slider.value = action.time / m_SoundTime;
		//}
	}
	private void Generate_Nav()
	{
		foreach (ActionPoint action in ml_action)
		{
			GameObject rect;
			rect = Instantiate(m_rectPrefab, GameObject.Find("Icon").transform);
			rect.GetComponent<RectTransform>().anchoredPosition = new Vector3((750f / m_SoundTime) * action.time, 15f, 0f);
		}
	}
	private void PlayAction()
	{
		foreach (ActionPoint action in ml_action)
		{
			if(((int)m_playTime == (int)action.time) && (action.used == false))
			{
				ActionPoint work = ml_action.Find(n => (int)n.time == (int)m_playTime);
				work.used = true;
				ml_action[ml_action.FindIndex(n => (int)n.time == (int)m_playTime)] = work;
				Debug.Log("ACTION");
				switch(action.m_actionType)
				{
					case ACTION_TYPE.Repeat:
						m_type.repeate.m_actionRepeat = true;
						break;
				}
				break;
			}
		}
	}
}