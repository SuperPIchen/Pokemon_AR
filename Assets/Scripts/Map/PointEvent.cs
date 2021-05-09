using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEvent : MonoBehaviour {

	//存储小精灵预制体
	public GameObject[] Pets;
	//存储精灵球预制体
	public GameObject[] Balls;
	//存储食物预制体
	public GameObject[] Foods;

	void Awake() {
		Balls = Resources.LoadAll<GameObject>("Balls");
		Foods = Resources.LoadAll<GameObject>("Foods");
		Pets = Resources.LoadAll<GameObject>("Pets");
	}

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
		int _petIndex = Random.Range(0, Pets.Length);
		//随机一个小精灵序号 随机选择 生成随机小精灵
		GameObject _pet = Instantiate(Pets[_petIndex], transform.position, transform.rotation);
		//把小精灵序号传递给小精灵身上挂载的脚本
		_pet.GetComponent<Pet_Find>().Pet_Index = _petIndex;
	}

	//生成精灵球
	private void InsBall() {
		int _ballIndex = Random.Range(0, Balls.Length);
		GameObject _ball = Instantiate(Balls[_ballIndex], transform.position + new Vector3(0, 5f, 0), transform.rotation);
		//设置精灵球角度
		_ball.transform.localEulerAngles = new Vector3(-30f, 0, 0);
		//增加碰撞器组件
		_ball.AddComponent<SphereCollider>();
		//勾选isTrigger
		_ball.GetComponent<SphereCollider>().isTrigger = true;
		//设置碰撞器的大小
		_ball.GetComponent<SphereCollider>().radius = 0.011f;
		//设置刚体
		_ball.AddComponent<Rigidbody>();
		//冻结刚体上的所有物体变换效果
		_ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

		//增加脚本
		_ball.AddComponent<MoveEffect>();
		_ball.AddComponent<Ball_Find>();
	}

	//生成食物
	private void InsFood() {
		int _foodIndex = Random.Range(0, Foods.Length);
		GameObject _food = Instantiate(Foods[_foodIndex], transform.position + new Vector3(0, 5f, 0), transform.rotation);
		//增加碰撞器组件
		_food.AddComponent<BoxCollider>();
		//勾选isTrigger
		_food.GetComponent<BoxCollider>().isTrigger = true;
		//设置碰撞器的位置
		_food.GetComponent<BoxCollider>().center = new Vector3(0, 0, 0);
		//设置碰撞器的大小
		_food.GetComponent<BoxCollider>().size = new Vector3(0.33f, 0.30f, 0.33f);
		//设置刚体
		_food.AddComponent<Rigidbody>();
		//冻结刚体上的所有物体变换效果
		_food.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

		//增加脚本
		_food.AddComponent<MoveEffect>();
		_food.AddComponent<Food_Find>();
	}
}
