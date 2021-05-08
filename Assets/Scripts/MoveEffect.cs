using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEffect : MonoBehaviour {

	//起始的弧度
	private float radian = 0;
	//弧度的变化
	private float perRad = 0.03f;
	//存储位移的偏移量
	private float add = 0;
	//存储物体生成时的起始坐标
	private Vector3 posOri;

	// Use this for initialization
	void Start () {
		//把物体刚生成时候的坐标记录下来
		posOri = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//弧度不断的增加
		radian += perRad;
		//得出偏移值
		add = Mathf.Sin(radian);
		//让物体浮动起来
		transform.position = posOri + new Vector3(0, add, 0);
		//以世界坐标的Y轴为旋转依据，在Y轴上进行旋转
		transform.Rotate(0, Time.deltaTime * 25f, 0, Space.World);
	}
}
