using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingPanel : PanelBase
{
	public static ShoppingPanel Instance;

    public override string Confname { get { return  "ShopConf"; } }

    void Awake()
    {
		Instance = this;
	}
	
}
