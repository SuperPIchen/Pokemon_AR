using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARBallCtr : MonoBehaviour {

    //存储精灵球预制体
	private GameObject[] balls;

	//存储生成精灵球的位置
	public Transform PosInsBall;

	public static ARBallCtr Instance;

	void Awake() {
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		//加载所有路径在“Resources/Balls”中的预制体
		balls = Resources.LoadAll<GameObject>("Balls");

		//更新精灵球的数量
		ARUI_Mgr.Instance.UpdateUIBallNum();

		InsNewBall();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void InsNewBall() {
		if (StaticData.BallNum > 0) {
			//生成精灵球
			GameObject _ball = Instantiate(balls[0], PosInsBall.position, PosInsBall.rotation);
			//设置精灵球的父级物体保证发射前始终在屏幕的固定位置
			_ball.transform.SetParent(PosInsBall);

			//给精灵球增加球形碰撞器
			_ball.gameObject.AddComponent<SphereCollider>();
			//添加脚本
			_ball.gameObject.AddComponent<ARShootBall>();
			//把精灵球的大小设置为25倍（预制体是250倍，相当于缩小了10倍）
			_ball.transform.localScale = new Vector3(25f, 25f, 25f);
			//更改球形碰撞器的大小，使碰撞器与模型大小保持匹配
			_ball.GetComponent<SphereCollider>().radius = 0.01f;
		}

	}
}
