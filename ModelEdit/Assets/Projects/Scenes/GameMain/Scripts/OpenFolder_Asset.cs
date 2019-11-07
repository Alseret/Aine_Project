using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFolder_Asset : MonoBehaviour
{
	AssetBundle assetBunndleA;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.H))
		{
			string AppPath = Application.dataPath;
			assetBunndleA = AssetBundle.LoadFromFile(AppPath.Replace("/Assets", "") + "/test.png");
			Debug.Log(AppPath.Replace("/Assets", "") + "/test.png");
		}
		if (Input.GetKeyDown(KeyCode.G))
		{
			if(assetBunndleA != null)
			{
				assetBunndleA.Unload(false);
			}
		}
	}
}