using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Comment_Manager : MonoBehaviour
{
	[SerializeField] private GameObject m_commentPrefab;
	[SerializeField] private List<string> m_commentStr;
	[SerializeField] public int m_displayCnt;

	// Start is called before the first frame update
	private void Start()
	{
		InstanceComment();
	}

	// Update is called once per frame
	private void Update()
	{

	}
	private void InstanceComment()
	{
		for(int i = 0; i < m_displayCnt; i++)
		{
			GameObject work = Instantiate(m_commentPrefab, transform);
			work.transform.localPosition = new Vector3(0f, Random.Range(1f, 7f), 0f);
			work.transform.localEulerAngles = new Vector3(0f, Random.Range(0f, 360f), 0f);
			work.transform.Find("GameObject/Image/Text").GetComponent<TextMeshProUGUI>().text = 
													m_commentStr[Random.Range(0, m_commentStr.Count)];
		}
	}
}