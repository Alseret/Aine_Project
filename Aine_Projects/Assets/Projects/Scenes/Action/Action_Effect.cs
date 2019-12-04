using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Action_Effect : MonoBehaviour
{
	[SerializeField] private GameObject[] m_sprites;
	[SerializeField] public int m_cnt;
	[SerializeField] private float m_minForce;
	[SerializeField] private float m_maxForce;
	[SerializeField] private Color m_color;
	[SerializeField] public static int m_popEffe;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void GenerateEffects()
	{
		for (int i = 0; i < m_cnt; i++)
		{
			GameObject work;
			work = Instantiate(m_sprites[Random.Range(0, m_sprites.Length)], transform);
			work.transform.eulerAngles = new Vector3(0f, 0f, Random.Range(0f, 360f));
			work.GetComponent<Image>().color = m_color;
			work.GetComponent<Rigidbody2D>().AddForce(work.transform.up * m_maxForce, ForceMode2D.Impulse);
			Destroy(work, 1f);
			m_popEffe++;
			Debug.Log(m_popEffe);
		}
	}
	public void GenerateEffects(int num)
	{
		for (int i = 0; i < num; i++)
		{
			GameObject work;
			work = Instantiate(m_sprites[Random.Range(0, m_sprites.Length)], transform);
			work.transform.eulerAngles = new Vector3(0f, 0f, Random.Range(0f, 360f));
			work.GetComponent<Image>().color = m_color;
			work.GetComponent<Rigidbody2D>().AddForce(work.transform.up * m_maxForce, ForceMode2D.Impulse);
			Destroy(work, 1f);
			m_popEffe++;
			Debug.Log(m_popEffe);
		}
	}
}