using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARInsPet : MonoBehaviour {

	//存储小精灵预制体
	private GameObject[] pets;
	//存储位置
	public Transform[] traPos;
	//
	public Transform CameraTra;

	// Use this for initialization
	void Start () {
		pets = Resources.LoadAll<GameObject>("Pets");
		InsPet();
		checkDis();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//生成小精灵
	public void InsPet() {
		//从预制位置的数量中随机一个序号
		int _index = Random.Range(0, traPos.Length);
		//得到随机位置
		Transform _tra = traPos[_index];
		//在随机位置生成小精灵
		GameObject _pet =  Instantiate(pets[StaticData.CatchingPetIndex], _tra.position, _tra.rotation);
		//把生成小精灵预制体缩放到0.5倍
		_pet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
		//小精灵看向摄像机
		_pet.transform.LookAt(new Vector3(CameraTra.position.x, CameraTra.position.y, CameraTra.position.z));
	}

	//检查生成小精灵的预置点到摄像机的距离
	private void checkDis() {
		foreach (Transform pos in traPos)
		{
			float _dis = Vector3.Distance(pos.position, CameraTra.position);
			Debug.Log(_dis);
		}
	}
}
