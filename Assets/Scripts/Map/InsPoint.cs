using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsPoint : MonoBehaviour {

	//储存地图角色
	public GameObject Ava;
	//储存事件点预制体
	public GameObject PrePoint;
	//储存距离范围的最小值
	public float MinDis = 50f;
	//储存距离范围的最大值
	public float MaxDis = 200f;
	//储存当前角色的坐标位置
	private Vector3 v3Ava;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//
	public void InsPointFuc() {
		//获取角色当前的坐标位置
		v3Ava = Ava.transform.position;
		//从距离范围中取一个随机距离值
		float _dis = Random.Range(MinDis, MaxDis);
		//从原点为（0,0）的坐标上获取任意一个方向的向量
		Vector2 _pOri = Random.insideUnitCircle;
		//获取到向量的单位向量
		Vector2 _pNor = _pOri.normalized;
		//算出随机点的位置
		Vector3 _v3Point = new Vector3(v3Ava.x + _pNor.x * _dis, 0, v3Ava.z + _pNor.y * _dis);
		//生成预制体
		GameObject _poiMark = Instantiate(PrePoint, _v3Point, transform.rotation);
	}
}
