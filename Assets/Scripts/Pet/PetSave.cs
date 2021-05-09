using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSave : MonoBehaviour {
	//记录小精灵的名字
	private string strName = "未命名宠物";
	//记录小精灵对应的模型在预制体集合中的序号
	private int petIndex = 0;

	//小精灵属性设置
	public string PetName {
		get { return strName; }
		set { strName = value; }
	}
	public int PetIndex {
		get { return petIndex; }
		set { petIndex = value; }
	}

	public PetSave(string name, int index) {
		PetName = name;
		PetIndex = index;
	}
}
