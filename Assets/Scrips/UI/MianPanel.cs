using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MianPanel : MonoBehaviour {
	private Button Buildbtn;
	private Text Gold;

	// Use this for initialization
	void Start () {
		Buildbtn = transform.Find("BuildingBtn").GetComponent<Button>();
		Gold = transform.Find("Gold/gold").GetComponent<Text>();

		Buildbtn.onClick.AddListener(BuildbtnClick);
		UpdataGoldNum(PlayerCtrller.Instance.GoldCount);
		//PlayerCtrller.Instance.GoldCount;

	}

    private void  BuildbtnClick()
    {
		UIManager.Instance.OpenBuildP();
    }
	//更新金币数量
	public void UpdataGoldNum(int num)
    {
		Gold.text = num.ToString();
	}
    // Update is called once per frame

}
