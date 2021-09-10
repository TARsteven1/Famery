using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop_Sunflower : BaseBuild
{
    //public  float Size2 =10;

    //  public override float Size => 10;
   
    public override float Size { get { return 10; }  }
    [SerializeField]
    private GameObject[] lvPrefabs;
    private GameObject model;

    private int lv= -1;
    public int Level
    {
        get { return lv; }
        set
        {
            //传进来的值跟现在不同
            if (lv!=value)
            {
                lv = value;
                //修改模型
                //TODO待用对象池
                if (model!= null) Destroy(model);
                model = GameObject.Instantiate(lvPrefabs[Level],transform,false);
            };
        }
    }
    void Start()
    {
        Level = 0;
        // OnPlaceOver();
        Invoke("UpGrade", 3);
        Invoke("UpGrade", 5);
    }
    //如果重写这个函数，克隆体会多执行一次upgrade，无解
    //protected override void OnPlaceOver()
    //{
    //    Invoke("UpGrade", 3);
    //    //Invoke("UpGrade", 20);
    //}


    private void UpGrade() {
       
        Level++;

    }
}
