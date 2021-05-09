using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARShootBall : MonoBehaviour {

	//设置给小球向前的力的大小
	public float FwdForce = 200f;
	//设置一个夹角的参考值
	public Vector3 StanTra = new Vector3(0, 1f, 0);

	//判断手指是否触碰到了精灵球的位置
	private bool blTouched = false;
	//判断精灵球是否发射
	private bool blShooted = false;
	//手指滑动起始点和终点
	private Vector3 startPosition;
	private Vector3 endPosition;
	//记录滑动的距离
	private float disFlick;
	//记录滑动的偏移向量
	private Vector3 offset;
	//记录滑动时间
	private int timeFlick;
	//记录滑动速度
	private float speedFlick;
	//记录主摄像机
	private Camera camera;
	

	// Use this for initialization
	void Start () {
		//赋值为主摄像机
		camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if (blTouched) { //如果按在小球上，允许计算手指滑动
		    //计算滑动距离
			slip();
		}
	}

	//重置参数
	private void resetVari() {
		//起始和终点位置设置为手指按下的位置
		startPosition = Input.mousePosition;
		endPosition = Input.mousePosition;
	}
	//鼠标（手指）按下
	void OnMouseDown() {
		if (blShooted == false) { //精灵球尚未发射
			blTouched = true; //允许检测手指滑动
		}
	}

	//计算手指的滑动
	private void slip() {
		timeFlick += 25;//时间每帧增加25
		if (Input.GetMouseButtonDown(0)) {//当手指按下的时候
			resetVari();//重置参数
		}

		if (Input.GetMouseButton(0)) {//当手指一直按在屏幕上的时候
		    //把手指的终点位置变量赋值刷新为手指所处的位置
			endPosition = Input.mousePosition;
			//获取手指在世界坐标上的偏移向量
			offset = camera.transform.rotation * (endPosition - startPosition);
			//计算手指滑动的距离
			disFlick = Vector3.Distance(startPosition, endPosition);
		}

		if (Input.GetMouseButtonUp(0)) { //当手指抬起时
			//计算滑动的距离
			speedFlick = disFlick / timeFlick;
			//手指是否触碰到精灵球设置为否
			blTouched = false;
			//时间记录归零
			timeFlick = 0;
			//如果手指移动距离大于20且方向为向上滑动，则运行发射
			if (disFlick > 20 && endPosition.y - startPosition.y >0) {
				//发射精灵球
				shootBall();
			}
		}

	}

	//发射精灵球
	private void shootBall() {
		//给精灵增加刚体组件
		transform.gameObject.AddComponent<Rigidbody>();
		//用局部变量获取刚体组件
		Rigidbody _rigBall = transform.GetComponent<Rigidbody>();
		//给精灵球一个初始速度，这个速度等于方向（单位向量）乘以速度
		_rigBall.velocity = offset.normalized * speedFlick; 
		//给精灵球一个向着屏幕前方的力
		_rigBall.AddForce(camera.transform.forward * FwdForce);
		//让精灵球旋转起来
		_rigBall.AddTorque(transform.right);
		//设置精灵球的阻力
		_rigBall.drag = 0.5f;
		blShooted = true;
		//让这个发射出去的精灵球脱离父级物体
		transform.parent = null;
		//发射后减少精灵球数量
		StaticData.BallNum--;
		ARUI_Mgr.Instance.UpdateUIBallNum();

		//生成新的球
		StartCoroutine(LateInsBall());
	}

	IEnumerator LateInsBall() {
		yield return new WaitForSeconds(0.2f);
		//延迟生成新的精灵球
		ARBallCtr.Instance.InsNewBall();
	}
}
