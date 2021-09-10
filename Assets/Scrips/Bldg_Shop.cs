using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bldg_Shop : BaseBuild
{
    //   public  float Size1 = 10;
    //  public override float Size => 10;
    //private float size=13;
    public override float Size { get { return 13; }  }

   
    private void OnMouseDown()
    {
        if (!isPlaceing && UIManager.Instance.CanClickPanel)
        {
            ShoppingPanel.Instance.SetActive(true);
        }
    }



}
