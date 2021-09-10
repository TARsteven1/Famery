using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_Shop : MonoBehaviour
{
    private Text Txtname;
    private Text Txtcount;
    private Text Txtcost;
    private Button Buildbtn;

    public UnityAction BuildOnClickAction;

    private ShopConfItem confItem;

    private int currCount;

    public int CurrCount { get { return currCount; } }
    public int MaxCount {  get {return confItem.count; } }
    public int BuildCostGold { get { return confItem.cost; } }

    public GameObject Prefab { get { return confItem.prefab; } }

    public bool CanBuild
    {
        get
        {
            if (BuildCostGold <= PlayerCtrller.Instance.GoldCount&& currCount < MaxCount)
            {
                return true;
            }
            
            return false;
        }
    }


    void Start()
    {

    }
    // Use this for initialization
    public void Init(ShopConfItem confItem,UnityAction Buildbtnclick)
    {
        Txtname = transform.Find("Name").GetComponent<Text>();
        Txtcount = transform.Find("Count").GetComponent<Text>();
        Txtcost = transform.Find("Cost").GetComponent<Text>();
        Buildbtn = transform.Find("Button").GetComponent<Button>();
        //prefab = Resources.Load<GameObject>("Bldg_Shop");
        this.confItem = confItem;
        Buildbtn.onClick.AddListener(BuildOnClick);

        currCount = 0;
        Txtname.text = confItem.Name;
        Txtcount.text = currCount + "/" + confItem.count.ToString();
        Txtcost.text = confItem.cost.ToString();
        BuildOnClickAction = Buildbtnclick;

    }

    private void BuildOnClick()
    {
        if (!CanBuild)
        {
            return;
        }

        PlayerCtrller.Instance.Build(this);
        //关闭面板
        BuildOnClickAction();
       // BuildingPanel.Instance.SetActive(false);

    }
    /// <summary>
    /// 更新建造数据，建造后的反馈
    /// </summary>
    public void UpdateBuildData()
    {
        //建造位占用+1
        currCount += 1;
        Txtcount.text = currCount + "/" + confItem.count.ToString();
       


    }

    // Update is called once per frame

}
