using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Action_Nav : MonoBehaviour
{
	[System.Serializable]
	public struct ActionPoint
	{
		public GameObject m_actionType;
		public float time;
	}
	[SerializeField] private Slider m_slider;
	private GameManager m_manager;
	[SerializeField] public List<ActionPoint> ml_action;
	private AudioSource m_audio;
	[SerializeField] private float m_SoundTime;
	[SerializeField] private float m_playTime;
	[SerializeField] private float m_timeScale;

	// Start is called before the first frame update
	void Start()
	{
		m_manager = GetComponent<GameManager>();
		m_audio = GetComponent<AudioSource>();
		// 180 + 55 235
	}

	// Update is called once per frame
	void Update()
	{
		m_slider.maxValue = m_SoundTime;
		FastMusic(Input.GetKey(KeyCode.T));
		m_playTime = m_audio.time;
		Action_SliderNav();
	}
	private void FastMusic(bool t)
	{
		if(t)
		{
			m_audio.pitch = Time.timeScale = m_timeScale;
		}
		else
		{
			m_audio.pitch = Time.timeScale = 1f;
		}

		//m_audio.pitch = m_timeScale *Time.deltaTime;
	}
	private void Action_SliderNav()
	{
		m_slider.value = m_playTime;
		//foreach (ActionPoint action in ml_action)
		//{
		//	m_slider.value = action.time / m_SoundTime;
		//}
	}
}