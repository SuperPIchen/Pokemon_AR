using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARInsPet : MonoBehaviour {

	//存储小精灵预制体
	private GameObject[] pets;
	//存储位置
	public Transform[] traPos;

	// Use this for initialization
	void Start () {
		pets = Resources.LoadAll<GameObject>("Pets");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//生成小精灵
	public void IntPet() {
		//从预制位置的数量中随机一个序号
		int _index = Random.Range(0, traPos.Length);
		//得到随机位置
		Transform _tra = traPos[_index];
		//在随机位置生成小精灵
		Instantiate(pets[0], _tra.position, _tra.rotation);
	}
}
