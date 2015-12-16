using UnityEngine;
using System.Collections;

public class ResourcesGUI : MonoBehaviour {

	private void OnGUI(){
		GUI.Box (new Rect(205,0, 200,20), "Money: " + Money.currentMoney.ToString ()); 
		GUI.Box (new Rect(410,0, 200,20), "Food: " + FoodStorage.currentStock.ToString ()+"/"+FoodStorage.capacity.ToString()); 
		GUI.Box (new Rect(615,0, 200,20), "Water: " + WaterStorage.currentStock.ToString ()+"/"+WaterStorage.capacity.ToString()); 

		//GUI.Box(new Rect(Screen.width - 150, 0, 150, 20), "total income: " + _totalIncome.ToString());
		GUI.Box(new Rect(205,22, 200,20), "Children: " + CitizenMaster.amountOfChildren);
		GUI.Box(new Rect(410,22, 200,20), "Men: " + CitizenMaster.amountOfMales);
		GUI.Box(new Rect(615,22, 200,20), "Women: " + CitizenMaster.amountOfFemales);

		if(CitizenMaster.amountOfCitizens > BedsMaster.beds){
			GUI.color = Color.red;
		}
		GUI.Box(new Rect(205,44, 200,20), "Beds: " + BedsMaster.beds + " / " + CitizenMaster.amountOfCitizens);
		GUI.color = Color.white;
	}
}
