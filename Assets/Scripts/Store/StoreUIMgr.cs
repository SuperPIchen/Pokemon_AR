using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoreUIMgr : MonoBehaviour {

	//存储显示小精灵名字的Text组件
	public Text[] Tx_PetNm;

	//存储显示小精灵种类的Text组件
	public Text[] Tx_PetType;

	public static StoreUIMgr Instance;

	void Awake() {
		Instance = this;
	}

	public void UpdatePetNm(int index, string strNm) {
		Tx_PetNm[index].text = strNm;
	}

	public void Btn_ToMap() {
		SceneManager.LoadScene("Map_Scn");
	}

		public void UpdatePetType(int index, string strType) {
		Tx_PetType[index].text = strType;
	}
}
