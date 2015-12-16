using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	private void Awake(){
		SetupGame();
	}

	private void SetupGame(){
		GameObject.FindWithTag ("World").GetComponent<WorldCreator> ().CreateRandomWorld ();
		BuildingMaster.SetupDefaultPurchasableBuildings();
        FoodMaster.SetupDefaultPurchasableFood();
		JobsMaster.SetupDefaultJobs();
		CitizenMaster.Init();
		this.GetComponent<Clock>().StartClock();
	}
}
