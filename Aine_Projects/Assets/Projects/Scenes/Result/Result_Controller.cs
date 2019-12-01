using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Result_Controller : MonoBehaviour
{
	[SerializeField] private Image m_capture;
	[SerializeField] private ScreenShot m_scrShot;
	[SerializeField] private Transform m_target;
	[SerializeField] private GameObject[] m_effects;
	[SerializeField] private TextMeshProUGUI m_text;
	[SerializeField] private int m_cnt;

	// Start is called before the first frame update
	void Start()
	{
		m_scrShot = GameObject.Find("Cam").GetComponent<ScreenShot>();
		m_cnt = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Return))
		{
			m_capture.sprite = m_scrShot.m_sprite;
			transform.GetChild(0).GetComponent<Image>().enabled = true;
			transform.GetChild(0).GetChild(0).GetComponent<Image>().enabled = true;
			transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = true;
		}
		if(Input.GetKey(KeyCode.P))
		{
			Instantiate(m_effects[Random.Range(0, m_effects.Length)],
						new Vector2(Random.Range(m_target.position.x - 170f, m_target.position.x + 170f),
						m_target.position.y), Quaternion.identity, m_target);
			m_cnt++;
			m_text.text = "♪ : " + m_cnt;
		}
	}
}