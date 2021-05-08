using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UI_Mgr_02 : MonoBehaviour {

	//存储显示精灵球数量的Text组件
	public Text Tx_BallNum;
	//存储显示食物数量的Text组件
	public Text Tx_FoodNum;

	//捕捉成功面板
	public GameObject Im_Catch;

	public static UI_Mgr_02 Instance;

	public void Awake() {
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddBallNum() {
		//将从组件中获取的字符串转化为数字
		int _num = Int32.Parse(Tx_BallNum.text);
		_num++;
		//把增加后的数字转化为字符串显示在Text组件上
		Tx_BallNum.text = _num.ToString();
	}

	public void AddFoodNum() {
		//将从组件中获取的字符串转化为数字
		int _num = Int32.Parse(Tx_FoodNum.text);
		_num++;
		//把增加后的数字转化为字符串显示在Text组件上
		Tx_FoodNum.text = _num.ToString();
	}

	public void SetIn_Catch(bool b1) {
		//通过调用函数时传入的bool类型参数b1来设置面板状态
		Im_Catch.SetActive(b1);
	}
}
