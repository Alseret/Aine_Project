using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_Manager : MonoBehaviour
{
	// Start is called before the first frame update
	private void Start()
	{

	}

	// Update is called once per frame
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
		{
			SceneManager.LoadScene("Stage");
		}
	}
}