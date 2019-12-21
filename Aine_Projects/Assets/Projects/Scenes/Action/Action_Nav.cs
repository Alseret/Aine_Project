using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
	[SerializeField] private Sprite[] m_icons;
	[SerializeField] private Slider m_slider;
	private GameManager m_manager;
	private Debug_ m_debug;
	[SerializeField] public List<ActionPoint> ml_action;
	private AudioSource m_audio;
	[SerializeField] private GameObject m_rectPrefab;
	private float m_volume;
	private float m_endTime;

	// Start is called before the first frame update
	private void Start()
	{
		m_manager = GetComponent<GameManager>();
		m_debug = GameObject.Find("Debug__").GetComponent<Debug_>();
		m_audio = GetComponent<AudioSource>();
		m_volume = m_audio.volume;
		Generate_Nav();
	}

	// Update is called once per frame
	private void Update()
	{
		m_slider.maxValue = m_manager.m_SoundTime;
		Action_SliderNav();
		if (m_debug.m_action)
			PlayAction();
		SoundEnd();
		if(Input.GetKeyDown(KeyCode.N))
		{
			Debug.Log("AnimTime : " + GameObject.Find("Idol").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime);
			Debug.Log("playTime : " + m_manager.m_playTime);
		}
	}

	private void Action_SliderNav()
	{
		m_slider.value = m_manager.m_playTime;
	}
	private bool m_endFlag;
	private void SoundEnd()
	{
		if(m_manager.m_SoundTime < m_manager.m_playTime + 5f && !m_manager.m_contObj[2].activeSelf)
		{
			m_manager.m_controll = GameManager._ControllType.End;
			m_manager.ChangeControll();
		}
		if ((m_manager.m_SoundTime < m_manager.m_playTime) && m_audio.volume > 0f)
		{
			m_audio.volume = m_manager.m_audio.volume - .003f;
		}
		if(m_manager.m_SoundTime + 3f < m_manager.m_playTime)
		{
			enabled = false;
			GameObject.Find("Idol").GetComponent<Animator>().enabled = false;
			m_manager.EndMusic();
		}
	}

	private void Generate_Nav()
	{
		foreach (ActionPoint action in ml_action)
		{
			GameObject rect;
			rect = Instantiate(m_rectPrefab, GameObject.Find("Icon").transform);
			rect.GetComponent<Image>().sprite = m_icons[(int)action.m_actionType];
			rect.GetComponent<RectTransform>().sizeDelta = new Vector2(m_icons[(int)action.m_actionType].texture.width, m_icons[(int)action.m_actionType].texture.height);
			rect.transform.localScale = Vector3.one * .3f;
			rect.GetComponent<RectTransform>().anchoredPosition = new Vector3((750f / m_manager.m_SoundTime) * action.time, 15f, 0f);
		}
	}
	private void PlayAction()
	{
		foreach (ActionPoint action in ml_action)
		{
			if (((int)m_manager.m_playTime == (int)action.time) && (action.used == false))
			{
				ActionPoint work = ml_action.Find(n => (int)n.time == (int)m_manager.m_playTime);
				work.used = true;
				ml_action[ml_action.FindIndex(n => (int)n.time == (int)m_manager.m_playTime)] = work;
				Debug.Log("ACTION : " + action.m_actionType);
				switch (action.m_actionType)
				{
					case GameManager._ACTION_TYPE.Repeate:
						SceneManager.LoadScene("Action_Repeat", LoadSceneMode.Additive);
						break;
					case GameManager._ACTION_TYPE.Order:
						SceneManager.LoadScene("Action_Order", LoadSceneMode.Additive);
						break;
					case GameManager._ACTION_TYPE.Roll:
						SceneManager.LoadScene("Action_Roll", LoadSceneMode.Additive);
						break;
				}
				break;
			}
		}
	}
}