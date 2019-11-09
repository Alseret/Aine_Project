using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyBox;

public class Action_Nav : MonoBehaviour
{
	[System.Serializable]
	public struct ActionPoint
	{
		public GameManager._ACTION_TYPE m_actionType;
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
		m_slider.maxValue = m_manager.m_SoundTime;
		//FastMusic(Input.GetKey(KeyCode.T));
		Action_SliderNav();
		PlayAction();
	}

	private void Action_SliderNav()
	{
		m_slider.value = m_manager.m_playTime;
	}

	private void Generate_Nav()
	{
		foreach (ActionPoint action in ml_action)
		{
			GameObject rect;
			rect = Instantiate(m_rectPrefab, GameObject.Find("Icon").transform);
			rect.GetComponent<RectTransform>().anchoredPosition = new Vector3((750f / m_manager.m_SoundTime) * action.time, 15f, 0f);
		}
	}
	private void PlayAction()
	{
		foreach (ActionPoint action in ml_action)
		{
			if(((int)m_manager.m_playTime == (int)action.time) && (action.used == false))
			{
				ActionPoint work = ml_action.Find(n => (int)n.time == (int)m_manager.m_playTime);
				work.used = true;
				ml_action[ml_action.FindIndex(n => (int)n.time == (int)m_manager.m_playTime)] = work;
				Debug.Log("ACTION");
				switch(action.m_actionType)
				{
					case GameManager._ACTION_TYPE.Repeate:
						m_type.repeate.m_actionRepeat = true;
						break;
				}
				break;
			}
		}
	}
}