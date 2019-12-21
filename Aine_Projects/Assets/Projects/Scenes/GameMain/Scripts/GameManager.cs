using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MyBox;

public class GameManager : MonoBehaviour
{
	[System.Serializable]
	public enum _ControllType
	{
		Mouse,
		GamePad,
		Auto,
		End,
	}
	[System.Serializable]
	public enum _ACTION_TYPE
	{
		Repeate,
		Order,
		Roll,
		MAX__,
	}
	[System.Serializable]
	public enum _Evaluation
	{
		Excellent,
		Good,
		Nice,
	}

	[System.Serializable]
	public struct _Master
	{
		public _ACTION_TYPE type;
		public int count;
		public _Evaluation eva;
	}
	[SerializeField] public _ControllType m_controll;
	[SerializeField] public GameObject[] m_contObj;
	[SerializeField] public List<_Master> ml_master;
	[SerializeField] public int m_noteCnt;
	[Separator]
	[SerializeField] public float m_SoundTime;
	[SerializeField] [ReadOnly] public float m_playTime;
	[SerializeField] private float m_fastTime;
	[SerializeField] private float m_slowTime;
	[SerializeField] private bool m_fastBool;
	[SerializeField] private bool m_slowBool;
	[Separator]
	[SerializeField] public AudioClip m_clip;
	[SerializeField] public AudioSource m_audio;
	[SerializeField] private GameObject[] m_aineModel;
	[SerializeField] public float m_animTime;

	// Start is called before the first frame update
	private void Awake()
	{
		SceneManager.LoadScene("CutIn", LoadSceneMode.Additive);
	}
	private void Start()
	{
		GameObject idol = Instantiate(m_aineModel[0], GameObject.Find("Aine_Unit").transform);
		idol.name = "Idol";
		idol.GetComponent<Animator>().Play("NOT_Final", 0, .01f);
		ChangeLookModel(idol);
		ChangeControll();
		ml_master = new List<_Master>();
		m_audio.clip = m_clip;
		m_audio.Play();
		if (m_SoundTime == 0f)
			m_SoundTime = m_audio.clip.length;
	}

	// Update is called once per frame
	private void Update()
	{
		m_playTime = m_audio.time;
		GameSpeedController();
		if (Input.GetKeyDown(KeyCode.Return))
		{
			enabled = false;
			SceneManager.LoadScene("Result", LoadSceneMode.Additive);
		}
		if (Input.GetKeyDown(KeyCode.Alpha1))
			ChangeModel(0);
		if (Input.GetKeyDown(KeyCode.Alpha2))
			ChangeModel(1);
		if (Input.GetKeyDown(KeyCode.Alpha3))
			ChangeModel(2);

		
	}
	public void ChangeLookModel(GameObject model)
	{
		GameObject.Find("GamePad").GetComponent<Cinemachine.CinemachineFreeLook>().Follow = model.transform;
		GameObject.Find("GamePad").GetComponent<Cinemachine.CinemachineFreeLook>().LookAt = model.transform.Find("LookAt");
	}
	public void ChangeModel(int num)
	{
		m_animTime = GameObject.Find("Aine_Unit/Idol").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;
		Vector3 pos = GameObject.Find("Aine_Unit/Idol").transform.localPosition;
		Debug.Log(m_animTime);
		Destroy(GameObject.Find("Aine_Unit/Idol"));
		GameObject idol = Instantiate(m_aineModel[num], GameObject.Find("Aine_Unit").transform);
		idol.name = "Idol";
		idol.transform.localPosition = pos;
		idol.GetComponent<Animator>().Play("NOT_Final", 0, m_animTime);
		ChangeLookModel(idol);
	}
	public void ChangeControll()
	{
		switch (m_controll)
		{
			case _ControllType.Mouse:
				Debug.Log("Mouse");
				m_contObj[0].SetActive(true);
				m_contObj[1].SetActive(false);
				break;
			case _ControllType.GamePad:
				Debug.Log("GamePad");
				m_contObj[0].SetActive(false);
				m_contObj[1].SetActive(true);
				break;
			case _ControllType.Auto:
				Debug.Log("Auto");
				m_contObj[0].SetActive(false);
				m_contObj[1].SetActive(false);
				break;
			case _ControllType.End:
				Debug.Log("End");
				m_contObj[0].SetActive(false);
				m_contObj[1].SetActive(false);
				m_contObj[2].SetActive(true);
				break;
		}
	}
	public void AddMaster(_ACTION_TYPE type, int cnt, _Evaluation eva)
	{
		_Master work;
		work.type = type;
		work.count = cnt;
		work.eva = eva;
		ml_master.Add(work);
	}

	private void GameSpeedController()
	{
		if (m_fastBool)
		{
			m_audio.pitch = Time.timeScale = m_fastTime;
			return;
		}
		else if (m_slowBool)
		{
			m_audio.pitch = Time.timeScale = m_slowTime;
			return;
		}
		if (!FastSpeed() && !SlowSpeed())
			m_audio.pitch = Time.timeScale = 1f;
		else if (FastSpeed() && SlowSpeed())
			m_audio.pitch = Time.timeScale = 0f;
		else if (FastSpeed())
			m_audio.pitch = Time.timeScale = m_fastTime;
		else if (SlowSpeed())
			m_audio.pitch = Time.timeScale = m_slowTime;
	}
	private bool FastSpeed()
	{
		if (Input.GetKey(KeyCode.T) || Input.GetKey("joystick button 5"))
			return true;
		return false;
	}
	private bool SlowSpeed()
	{
		if (Input.GetKey(KeyCode.Y) || Input.GetKey("joystick button 4"))
			return true;
		return false;
	}
	public void EndMusic()
	{
		//if (!(m_audio.time == 0f && !m_audio.isPlaying)) return;
		StartCoroutine(GameObject.Find("Cam").GetComponent<ScreenShot>().imageShot());
		enabled = false;
		SceneManager.LoadScene("Result", LoadSceneMode.Additive);
	}
}