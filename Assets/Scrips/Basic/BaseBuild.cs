using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBuild : MonoBehaviour {

	protected bool isPlaceing = true;

	public abstract float Size { get;  }

	public  bool CanCreat { get; set; } 
	/// <summary>
	/// 在放置的时候初始化
	/// </summary>
	public virtual void InitOnPlace()
    {
		isPlaceing = false;
		//OnPlaceOver();
	}

	//protected virtual void OnPlaceOver()
	//{使用doteew插件实现建筑动画，因版本过低无法使用那个插件
	
	//}


		// Use this for initialization
		private void OnTriggerEnter(Collider other)
	{
		if (isPlaceing) {
			if (other.tag != "Ground")
			{
				CanCreat = false;
			}
			else
			{
				CanCreat = true;
			}
		}
		

	}
	private void OnTriggerExit(Collider other)
	{
		if (isPlaceing)
		{
			CanCreat = true;
		}
	}
}
