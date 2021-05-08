using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet_Find : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//使小精灵面向用户
		transform.LookAt(GameObject.FindGameObjectWithTag("Avatar").transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		//显示捕捉面板
		if (other.tag == "Avatar") {
			UI_Mgr_02.Instance.SetIn_Catch(true);
			//销毁物体
			Destroy(gameObject);
		}
	}
}
