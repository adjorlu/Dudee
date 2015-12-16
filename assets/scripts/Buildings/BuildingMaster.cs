using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingMaster : MonoBehaviour {

	//private static List<GameObject> _ownedBuildings = new List<GameObject>();
	public static List<GameObject> _purchableBuildings = new List<GameObject>();

    private static List<GameObject> _homes = new List<GameObject>(); 

	private static Transform _handle;
    public int _numberOfBeds;

	public static void SetupDefaultPurchasableBuildings(){
    
		CreateBuilding("Neighbour Village", false);

		CreateBuilding("Home", true);
		GameObject home2 = CreateBuilding("Home", true);
		home2.transform.position = new Vector3 (3, 0);
		GameObject home3 = CreateBuilding("Home", true);
		home3.transform.position = new Vector3 (6, 0);
        
		//_ownedBuildings.Add(CreateBuilding("Neighbour Village", false));
        _purchableBuildings.Add(CreatePurchasableBuilding("Home"));
        _purchableBuildings.Add(CreatePurchasableBuilding("School"));
        //_purchableBuildings.Add(CreatePurchasableBuilding("Mine"));


    }
	
	/*public static List<GameObject> ownedBuildings{
		get{
			return _ownedBuildings;
		}
	}*/

	public static List<GameObject> purchableBuildings{
		get{
			return _purchableBuildings;
		}
	}
	
	private static GameObject CreatePurchasableBuilding(string buildingName){
		return Resources.Load("Prefabs/Buildings/"+buildingName) as GameObject;
	}

	private static GameObject CreateBuilding(string buildingName, bool isInTheVillage){
		GameObject buildingPrefab = Resources.Load("Prefabs/Buildings/"+buildingName) as GameObject;
		return CreateBuilding(buildingPrefab, isInTheVillage);
	}

	public static GameObject CreateBuilding(GameObject buildingPrefab, bool isInTheVillage=true){
		GameObject newBuilding = Instantiate(buildingPrefab) as GameObject;
		newBuilding.name = newBuilding.name.Replace("(Clone)", "");
		newBuilding.transform.parent = GetHandle();

       // newBuilding.GetComponent<Home>()._beds; 
       
		if(isInTheVillage==false){
			OnBuildingPlaced(newBuilding.GetComponent<Building>(), false);
		}
        
		return newBuilding;
	}

	public static void OnBuildingPlaced(Building building, bool isInTheVillage=true){
		foreach(GameObject job in building._jobs){
			JobsMaster.CreateJob(job, isInTheVillage);
		}
	}

  

	private static Transform GetHandle(){
		if(_handle==null){
			_handle = GameObject.Find ("Buildings").transform;
		}
		return _handle;
	}

    
}
