using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
	public static UIManager Instance;

    private MianPanel mainpanel;
	private BuildingPanel buildingPanel;
	//private ShoppingPanel shoppingPanel;

	public PanelBase Currpanel =null;
	//可以点击新的面板
	public bool CanClickPanel { get { return Currpanel == null&&PlayerCtrller.Instance.Building; } }


	// Use this for initialization
	private void Awake()
    {
		Instance = this;
    }
	void Start () {
		mainpanel = transform.Find("MianPanel").GetComponent<MianPanel>();
		buildingPanel = transform.Find("BuildingPanel").GetComponent<BuildingPanel>();
		//shoppingPanel = transform.Find("ShoppingPanel").GetComponent<ShoppingPanel>();
	}

    public void OpenBuildP()
    {
		buildingPanel.SetActive(true);
    }
	public void UpdataGoldUI(int num)
    {
		mainpanel.UpdataGoldNum(num);
    }
}
