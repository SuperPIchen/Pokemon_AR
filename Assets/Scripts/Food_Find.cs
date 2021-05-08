using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_Find : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		//用户碰到精灵球，精灵球数量加1
		if (other.tag == "Avatar") {
			UI_Mgr_02.Instance.AddFoodNum();
			//销毁物体
			Destroy(gameObject);
		}
	}
}
