using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEvent : MonoBehaviour {

	//存储小精灵预制体
	public GameObject Pet;
	//存储精灵球预制体
	public GameObject Ball;
	//存储食物预制体
	public GameObject Food;

	// Use this for initialization
	void Start () {
		int _randomEvent = Random.Range(0, 3);
		if (_randomEvent == 0) {
			InsPet();
		} else if (_randomEvent == 1) {
			InsBall();
		} else {
			InsFood();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //生成小精灵
	private void InsPet() {
		Instantiate(Pet, transform.position, transform.rotation);
	}

	//生成精灵球
	private void InsBall() {
		GameObject _ball = Instantiate(Ball, transform.position + new Vector3(0, 5f, 0), transform.rotation);
		//设置精灵球角度
		_ball.transform.localEulerAngles = new Vector3(-30f, 0, 0);
	}

	//生成食物
	private void InsFood() {
		Instantiate(Food, transform.position + new Vector3(0, 5f, 0), transform.rotation);
	}
}
