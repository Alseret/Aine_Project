using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aspect : MonoBehaviour
{
	[SerializeField] private Sprite m_sprite;
	[SerializeField] private Vector2 m_size;

	// Start is called before the first frame update
	void Start()
	{
		m_size = new Vector2(m_sprite.texture.width, m_sprite.texture.height);
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}