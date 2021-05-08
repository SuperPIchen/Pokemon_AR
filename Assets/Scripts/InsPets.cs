using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsPets : MonoBehaviour {
	//申请数组变量 存储小精灵预制体
	private GameObject[] Pets;

	void Awake() {
		Pets = Resources.LoadAll<GameObject>("Pets");
	}

	// Use this for initialization
	void Start () {
		InsPet();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void InsPet() {
		int _petIndex = Random.Range(0, Pets.Length);
		//随机一个小精灵序号 随机选择 生成随机小精灵
		Instantiate(Pets[_petIndex], transform.position, transform.rotation);
	}
}
