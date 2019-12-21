using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Mouse : MonoBehaviour
{
	[SerializeField] private SkinnedMeshRenderer m_mouse;
	[SerializeField] private float ratio_Close = 85.0f;           //閉じ目ブレンドシェイプ比率
	[SerializeField] private float ratio_HalfClose = 20.0f;       //半閉じ目ブレンドシェイプ比率
	[SerializeField] private float ratio_Open = 0.0f;

	enum Status
	{
		Close,
		HalfClose,
		Open
	}
	private Status m_mouseStatus;

	// Start is called before the first frame update
	private void Start()
	{

	}

	// Update is called once per frame
	private void Update()
	{

	}

	private void SetClose()
	{
		m_mouse.SetBlendShapeWeight(3, ratio_Close);
	}
	private void SetHalfClose()
	{
		m_mouse.SetBlendShapeWeight(3, ratio_HalfClose);
	}
	private void SetOpen()
	{
		m_mouse.SetBlendShapeWeight(3, ratio_Open);
	}
}