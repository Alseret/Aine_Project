using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_Manager : MonoBehaviour
{
	[SerializeField] private GameObject m_fadePrefab;
	// Start is called before the first frame update
	private void Start()
	{

	}

	// Update is called once per frame
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
		{
			GameObject work = Instantiate(m_fadePrefab);
			work.GetComponent<Fade_IO>().FadeIn("Stage");
			//SceneManager.LoadScene("Stage");
		}
	}
}