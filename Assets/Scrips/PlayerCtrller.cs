using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrller : MonoBehaviour {
	public static PlayerCtrller Instance;
	//空地
	private GameObject prefab_Enpty;
	//临时持有建筑物模型，用于点击建造时的鼠标预览
	private BaseBuild Build_temp;
	private GameObject tempprefab;
	//全部建筑物
	private List<BaseBuild> builds = new List<BaseBuild>();
	//当前是否在建造中
	public bool Building { get { return Build_temp == null; } }

	//金币
	private int Gold;
	public int GoldCount { get { return GoldCount= Gold; } set {
			Gold = value;
			UIManager.Instance.UpdataGoldUI(Gold);
		} }

	// Use this for initialization
	void Awake()
    {
		Instance = this; 
	}
	void Start () {
		prefab_Enpty = Resources.Load<GameObject>("Crop_Enpty");
		Gold = 500;
		//BuildingPanel.Instance.SetActive(false);
		//Build(this,Resources.Load<GameObject>("Crop_Sunflower"), curr_shop.CurrCount);
	}
	
	// Update is called once per frame
	void Update () { 
        if (Build_temp != null) {
            if (Input.GetMouseButtonDown(1))
            {
				Destroy(Build_temp.gameObject);
				Build_temp = null;
				return;

			}
            if (curr_shop.CanBuild)
            {
                BuildForUpdate();

            }
            else
            {
                Destroy(Build_temp.gameObject);
                Build_temp = null;
                return;
            }
        }
	}
	private UI_Shop curr_shop;


    public void Build(UI_Shop UI_shop)
    {

		curr_shop = UI_shop;
		tempprefab = curr_shop.Prefab;
		if (Build_temp != null) {
			Destroy(Build_temp.gameObject);
		}
		Build_temp = GameObject.Instantiate<GameObject>(curr_shop.Prefab).GetComponent<BaseBuild>();
	}
	private void BuildForUpdate()
    {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		//	地面碰撞检测
		if (Physics.Raycast(ray, out hit, int.MaxValue, 1 << LayerMask.NameToLayer("Ground")))
		{
			if (hit.collider != null && hit.collider.gameObject.tag == "Ground")
			{
				BaseBuild build = null;
				//查找附近的土地快
				for (int i = 0; i < builds.Count; i++)
				{
					if (Vector3.Distance(hit.point, builds[i].transform.position) < (builds[i].Size/2)+(Build_temp.Size/2)+2)
					{
						build = builds[i];
						break;
					}
				}
				if (build != null)
				{
					float offsets = build.Size / 2 + Build_temp.Size / 2;
					Vector3 top = build.transform.position + new Vector3(0, 0, offsets);
					Vector3 botton = build.transform.position + new Vector3(0, 0, -offsets);

					Vector3 left = build.transform.position + new Vector3(-offsets, 0, 0);
					Vector3 right = build.transform.position + new Vector3(offsets, 0, 0);
					Vector3[] points = new Vector3[] { top, botton, left, right };
					float dis = 100000;
					Vector3 temppoint = Vector3.zero;

					for (int i = 0; i < points.Length; i++)
					{
						if (Vector3.Distance(hit.point, points[i]) < dis)
						{
							dis = Vector3.Distance(hit.point, points[i]);
							temppoint = points[i];
						}
						Build_temp.transform.position = temppoint;

					}


				}
				else
				{

					//让鼠标后边跟着一个空地跑
					Build_temp.transform.position = hit.point;

				}
			}
			//左键 建造
			if (Input.GetMouseButtonDown(0))
			{
				if (Build_temp.CanCreat)
				{
					BaseBuild temp = GameObject.Instantiate<GameObject>(tempprefab, Build_temp.transform.position, Quaternion.identity, null).GetComponent<BaseBuild>();
					builds.Add(temp);
					//初始化建筑物
					temp.InitOnPlace();
					//更新建造数据
					curr_shop.UpdateBuildData();
					//金币消耗
					Gold -= curr_shop.BuildCostGold;

				}
				else
				{
					Debug.Log("123");
				}


			}
		}
	}
}
