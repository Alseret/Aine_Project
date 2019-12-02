using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Result_Controller : MonoBehaviour
{
	[System.Serializable]
	public struct PICTURE_POS
	{
		public Vector2 pos;
		public float rot;
	}
	[SerializeField] private GameObject m_picPrefab;
	[SerializeField] private int m_picCnt;
	//[SerializeField] private Image m_capture;
	[SerializeField] private ScreenShot m_scrShot;
	[SerializeField] private Transform m_target;
	[SerializeField] private GameObject[] m_effects;
	[SerializeField] private TextMeshProUGUI m_text;
	[SerializeField] private int m_cnt;
	[SerializeField] private List<PICTURE_POS> m_pic;

	// Start is called before the first frame update
	void Start()
	{
		m_scrShot = GameObject.Find("Cam").GetComponent<ScreenShot>();
		m_cnt = 0;
		m_picCnt = 0;
		StartCoroutine(GenePicture());
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return) && (m_scrShot.m_sprite.Count > m_picCnt))
		{
			Debug.Log("Sprite : " + m_scrShot.m_sprite.Count);
			Debug.Log("Cnt : " + m_picCnt);
			GameObject work;
			work = Instantiate(m_picPrefab, transform);
			work.transform.GetChild(0).GetComponent<Image>().sprite = m_scrShot.m_sprite[m_picCnt];
			if (m_scrShot.m_sprite.Count - 1 == m_picCnt)
			{
				work.GetComponent<RectTransform>().localPosition = new Vector2(m_pic[m_pic.Count - 1].pos.x - 10f, m_pic[m_pic.Count - 1].pos.y);
				work.GetComponent<RectTransform>().localEulerAngles = new Vector3(0f, 0f, m_pic[m_pic.Count - 1].rot);
				Debug.Log("END");
			}
			else
			{
				work.GetComponent<RectTransform>().localPosition = new Vector2(m_pic[m_picCnt].pos.x - 10f, m_pic[m_picCnt].pos.y);
				work.GetComponent<RectTransform>().localEulerAngles = new Vector3(0f, 0f, m_pic[m_picCnt].rot);
			}
			m_picCnt++;
			//m_capture.sprite = m_scrShot.m_sprite;
			//transform.GetChild(0).GetComponent<Image>().enabled = true;
			//transform.GetChild(0).GetChild(0).GetComponent<Image>().enabled = true;
			//transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = true;
		}
		if (Input.GetKey(KeyCode.P))
		{
			Instantiate(m_effects[Random.Range(0, m_effects.Length)],
						new Vector2(Random.Range(m_target.position.x - 170f, m_target.position.x + 170f),
						m_target.position.y), Quaternion.identity, m_target);
			m_cnt++;
			m_text.text = "♪ : " + m_cnt;
		}
	}

	private IEnumerator GenePicture()
	{
		yield return new WaitForSeconds(.7f);
		GameObject work;
		work = Instantiate(m_picPrefab, transform);
		work.transform.GetChild(0).GetComponent<Image>().sprite = m_scrShot.m_sprite[m_picCnt];
		if (m_scrShot.m_sprite.Count - 1 == m_picCnt)
		{
			work.GetComponent<RectTransform>().localPosition = new Vector2(m_pic[m_pic.Count - 1].pos.x, m_pic[m_pic.Count - 1].pos.y);
			work.GetComponent<RectTransform>().localEulerAngles = new Vector3(0f, 0f, m_pic[m_pic.Count - 1].rot);
			Debug.Log("END");
		}
		else
		{
			work.GetComponent<RectTransform>().localPosition = new Vector2(m_pic[m_picCnt].pos.x, m_pic[m_picCnt].pos.y);
			work.GetComponent<RectTransform>().localEulerAngles = new Vector3(0f, 0f, m_pic[m_picCnt].rot);
		}
		m_picCnt++;
		if (m_scrShot.m_sprite.Count > m_picCnt)
			StartCoroutine(GenePicture());
	}
}