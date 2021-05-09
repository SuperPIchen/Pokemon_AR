using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ARUI_Mgr : MonoBehaviour {
	//存储精灵球数量的Text组件
	public Text Tx_BallNum;
	//捕捉成功的面板
	public GameObject PnCatched;
	//给小精灵起名字的Text组件
	public Text InputPetName;



	public static ARUI_Mgr Instance;

	void Awake() {
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Btn_GoMapScn() {
		SceneManager.LoadScene("Map_Scn");
	}
	//刷新精灵球UI数量的函数
	public void UpdateUIBallNum() {
		//把精灵球数量的全局数据显示在UI中
		Tx_BallNum.text = StaticData.BallNum.ToString();
	}
	//显示小精灵捕捉成功的面板
	public void Show_PnCatched() {
		PnCatched.SetActive(true);
	}

	//捕捉到后面板确认按钮
	public void Btn_Yes() {
		//从输入框中获取玩家给小精灵取的名字
		string _name = InputPetName.text;

		StaticData.AddPet(new PetSave(_name, StaticData.CatchingPetIndex));

		SceneManager.LoadScene("Store_Scn");
	}
	//放生按钮
	public void Btn_GiveUp() {
		SceneManager.LoadScene("Map_Scn");
	}
	
	public void Btn_GoStore() {
		SceneManager.LoadScene("Store_Scn");
	}
}
