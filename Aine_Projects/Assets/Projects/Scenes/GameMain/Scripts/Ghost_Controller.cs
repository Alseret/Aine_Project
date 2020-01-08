using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(1)]
public class Ghost_Controller : MonoBehaviour
{
	//private Animator m_idol;
	[SerializeField] private GameObject m_ghostPrefab;
	[SerializeField] private float m_destroyTime;
	[SerializeField] float time;
	[SerializeField] private Animation[] m_animCtrl;

	// Start is called before the first frame update
	private void Start()
	{
		//m_idol = GameObject.Find("Idol").GetComponent<Animator>();
	}

	// Update is called once per frame
	private void Update()
	{
		//time = m_idol.GetCurrentAnimatorStateInfo(0).normalizedTime;
	}
	public void GenerateGhost(GameManager._Evaluation eva)
	{
		//string name = null;
		//switch (eva)
		//{
		//	case GameManager._Evaluation.Excellent:
		//		name = "Dance1";
		//		break;
		//	case GameManager._Evaluation.Good:
		//		name = "Dance2";
		//		break;
		//	case GameManager._Evaluation.Nice:
		//		name = "Dance3";
		//		break;
		//}

		GameObject work;
		work = Instantiate(m_ghostPrefab, new Vector3(-1.2f, 0f, 1.2f), Quaternion.Euler(Vector3.up * 180f), GameObject.Find("Aine_Unit").transform);
		work.GetComponent<Animator>().Play("SIM_Final" , 0, GameObject.Find("Idol").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime);
		Destroy(work, m_destroyTime);
	}
}