using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet_Find : MonoBehaviour {

	//存储小精灵的序号
	public int Pet_Index;
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
			//传递小精灵序号
			StaticData.CatchingPetIndex = Pet_Index;
			//销毁物体
			Destroy(gameObject);
		}

		if (other.tag == "Ball") {
			//播放动画
			playCatched();
			
			StartCoroutine(ShowCatchedPn());
		}
	}

	IEnumerator ShowCatchedPn() {
		yield return new WaitForSeconds(2f);
		//显示捕捉成功面板
		ARUI_Mgr.Instance.Show_PnCatched();
		//销毁小精灵
		Destroy(transform.gameObject);
	}

	//播放被捕捉的动画
	private void playCatched() {
		transform.GetComponent<Animator>().SetTrigger("Catched");
	}
}
