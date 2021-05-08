using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyController : MonoBehaviour {

	//存储动画控制器
	private Animator ator;
	//存储角色的移动类，为了获取角色的移动状态
	private MoveAvatar moveAvatar;

	// Use this for initialization
	void Start () {
		//获取角色的动画控制器组件
		ator = gameObject.GetComponent<Animator>();
		//获取父物体（角色控制器）上的角色移动类
		moveAvatar = transform.parent.GetComponent<MoveAvatar>();
	}
	
	// Update is called once per frame
	void Update () {
		if (moveAvatar.animationState == MoveAvatar.AvatarAnimationState.Idle && !ator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) {
			//如果角色控制器中的角色动画状态是定义的待机状态
			ator.SetTrigger("Idle");
		} else if (moveAvatar.animationState == MoveAvatar.AvatarAnimationState.Walk && !ator.GetCurrentAnimatorStateInfo(0).IsName("Walk")) {
			ator.SetTrigger("Walk");
		} else if (moveAvatar.animationState == MoveAvatar.AvatarAnimationState.Run && !ator.GetCurrentAnimatorStateInfo(0).IsName("Run")) {
			ator.SetTrigger("Run");
		}
	}
}
