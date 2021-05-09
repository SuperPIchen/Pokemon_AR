using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData {
	//精灵球的全局变量
	public static int BallNum = 10;
	//当前正要捕捉的小精灵序号
	public static int CatchingPetIndex;

	//申请列表存储捕捉到的小精灵类
	public static List<PetSave> PetList = new List<PetSave>();

	public static void AddPet(PetSave petSave) {
		PetList.Add(petSave);
	}

	public static string GetType(int index) {
		if (index == 0) {
			return "小熊";
		} else if (index == 1) {
			return "小牛";
		} else if (index == 2) {
			return "小兔";
		} else if (index == 3) {
			return "小鸡";
		} else if (index == 4) {
			return "老虎";
		} else if (index == 5) {
			return "猴子";
		} else if (index == 6) {
			return "Kitty";
		} else if (index == 7) {
			return "狮子";
		} else if (index == 8) {
			return "企鹅";
		} else if (index == 9) {
			return "小狗";
		} else if (index == 10) {
			return "犀牛";
		}
		return "无";
	}
}
