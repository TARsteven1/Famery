using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ShopConfItem
{
    public string Name;
    public int count;
    public int cost;
    public GameObject prefab;


}

[CreateAssetMenu(fileName ="Conf",menuName = "Config/ShopConf")]
public class BuildShopConf : ScriptableObject {

    public ShopConfItem[] ShopConfItems;

}
