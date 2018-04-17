using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;		// カメラの追尾対象（プレイヤー）の位置
	public float smoothing = 5f;	// カメラの追尾速度

	Vector3 offset;					// カメラからtargetまでの距離、
									// カメラは常にプレイヤーからoffset分の距離を保つことになる

	void Start ()
	{
		// プレイヤーの初期位置からoffsetを初期化する
		offset = transform.position - target.position;
	}


	void FixedUpdate ()
	{
		// プレイヤーの位置から追尾後のカメラ位置を算出する
		Vector3 targetCamPos = target.position + offset;

		// プレイヤーの位置を元にカメラを移動させる
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
