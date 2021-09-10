using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PanelBase : MonoBehaviour {
	

	private Button Closebtn;
	private BuildShopConf buildShopConf;

	private GameObject prefab_UI_BuildShopItem;
	private Transform parent_ShopItem;
	public abstract string Confname { get; }
	// Use this for initialization
	
	void Start()
	{
		prefab_UI_BuildShopItem = Resources.Load<GameObject>("UI/BuildShopItem");
		parent_ShopItem = transform.Find("Bg/Group");
		buildShopConf = Resources.Load<BuildShopConf>("Conf/"+Confname);
		Closebtn = transform.Find("Bg/Closebtn").GetComponent<Button>();
		Closebtn.onClick.AddListener(ClosebtnClick);
		ClosebtnClick();

		for (int i = 0; i < buildShopConf.ShopConfItems.Length; i++)
		{
			UI_Shop item = GameObject.Instantiate(prefab_UI_BuildShopItem, parent_ShopItem).GetComponent<UI_Shop>();
			item.Init(buildShopConf.ShopConfItems[i], ClosebtnClick);

		}
	}

	private void ClosebtnClick()
	{
		UIManager.Instance.Currpanel = null;
		SetActive(false);
		
	}
	public void SetActive(bool isActive)
	{
        if (isActive==true)
        {
            if (UIManager.Instance.CanClickPanel)
            {
				UIManager.Instance.Currpanel = this;
				gameObject.SetActive(isActive);

			}
		}else
        {
			gameObject.SetActive(isActive);

		}
	}
}
