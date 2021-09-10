using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPanel : PanelBase
{
	public static BuildingPanel Instance;

    public override string Confname { get { return "BuildConf"; } }


    void Awake()
    {
        Instance = this;
    }
    // Use this for initialization



}
