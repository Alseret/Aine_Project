using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{
	[SerializeField] private bool m_play;
	[SerializeField] private AudioClip m_sound;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if(m_play)
		{
			GetComponent<AudioSource>().Play();
			m_play = false;
		}
	}
}