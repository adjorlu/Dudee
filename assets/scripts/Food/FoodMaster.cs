using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoodMaster : MonoBehaviour
{

    //private static List<GameObject> _ownedBuildings = new List<GameObject>();
    private static List<GameObject> _purchableFood = new List<GameObject>();
    private static Transform _handle;

    public static void SetupDefaultPurchasableFood()
    {

        //CreateBuilding("Neighbour Village", false);

        //_ownedBuildings.Add(CreateBuilding("Neighbour Village", false));
            
        _purchableFood.Add(CreatePurchasableFood("Rice")); 

    }

    /*public static List<GameObject> ownedBuildings{
		get{
			return _ownedBuildings;
		}
	}*/

    public static List<GameObject> purchableFood
    {
        get
        {
            return _purchableFood;
        }
    }


    private static GameObject CreatePurchasableFood(string FoodName)
    {
        return Resources.Load("Prefabs/Food/" + FoodName) as GameObject;
    }




   
}
