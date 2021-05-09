using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreInsPet : MonoBehaviour {
	//储存宠物栏中小精灵的生成点
	public Transform[] Pos;
	//储存所有的小精灵预制体
	private GameObject[] pets;
	//在仓库中展示出来的小精灵
	private GameObject[] petsShow = new GameObject[3];


	void Awake() {
		pets = Resources.LoadAll<GameObject>("Pets");
	}

	// Use this for initialization
	void Start () {
		InsPet();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void InsPet() {
		//通过全局类中存储的已经捕捉小精灵的数量来判断已经捕捉到了多少小精灵
		int _petNum = StaticData.PetList.Count;
		if (_petNum > 0) {
			for (int i = 0; i < 3; i++) {
				if (_petNum -1 < i) {
					return;
				}
				//从全局类中获取到对于序号的小精灵属性类
				PetSave _petInfo = StaticData.PetList[i];
				//通过小精灵属性中的预制体集合序号生成对应的小精灵预模型
				Instantiate(pets[_petInfo.PetIndex], Pos[i].position, Pos[i].rotation);

				//获取到这个小精灵的命名
				string _petNm = _petInfo.PetName;

				//刷新名字名字和种类
				StoreUIMgr.Instance.UpdatePetNm(i, _petNm);
				StoreUIMgr.Instance.UpdatePetType(i, StaticData.GetType(_petInfo.PetIndex));
			}
		}
		
	}
}
