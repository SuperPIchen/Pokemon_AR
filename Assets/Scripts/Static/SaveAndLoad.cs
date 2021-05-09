using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveAndLoad {

	//保存游戏数据
	public static void Save() {
		//保存精灵球数量
		ES3.Save<int>("BallNum", StaticData.BallNum);
		//保存已捕捉的小精灵数量
		ES3.Save<int>("PetNum", StaticData.PetList.Count);
		//保存每一个已捕捉的小精灵的信息
		for (int i = 0; i < StaticData.PetList.Count; i++) {
			ES3.Save<string>("PetNum" + i.ToString(), StaticData.PetList[i].PetName);
			ES3.Save<int>("PetIndex" + i.ToString(), StaticData.PetList[i].PetIndex);
		}
	}

	//读取游戏数据
	public static void Load() {
		if (ES3.KeyExists("BallNum") && ES3.KeyExists("PetNum")) {
			//把读取的信息存入全局变量
			StaticData.BallNum = ES3.Load<int>("BallNum");
			int _petNum = ES3.Load<int>("PetNum");
			//获取每一个已捕捉小精灵的信息
			for (int i = 0; i < _petNum; i++) {
				string _petName = ES3.Load<string>("PetNum" + i.ToString());
				int _petIndex = ES3.Load<int>("PetIndex" + i.ToString());

				StaticData.AddPet(new PetSave(_petName, _petIndex));
			}
		}
	}
	

}
