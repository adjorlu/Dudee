using UnityEngine;
using System.Collections;

public class PlaceBuildingInteraction : MonoBehaviour {
	
	private static PlaceBuildingInteraction _instance;
	private GameObject _building;
	private bool _itsOn = false;

	private void Awake(){
		_instance = this;
	}

	public void Enable(GameObject building){
		_building = building;
		this.enabled = true;
	}

	private void Update(){
		if (_itsOn == false) {
			if (Input.GetMouseButtonUp (0)) {
				_itsOn = true;
			}
		} 
		else {
			if (Input.GetMouseButton (0)) {
				Snap ();
			} 
			else if (Input.GetMouseButtonUp (0)) {
				PlaceBuilding ();
			}
		}
	}

	private void Snap(){
		Vector2 p = GetSnappedMousePositionInWorldSpace ();
		_building.transform.position = p;
	}

	private void PlaceBuilding(){
		Snap ();
		BuildingMaster.OnBuildingPlaced(_building.GetComponent<Building>());
		_itsOn = false;
		this.enabled = false;
	}

	private Vector2 GetSnappedMousePositionInWorldSpace(){
		Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if(p.x<0f){
			p.x = 0;
		}
		else if(p.x>=WorldCreator.WIDTH){
			p.x = WorldCreator.WIDTH-1;
		}
		else{
			p.x = (int)p.x;
		}
		if(p.y<0){
			p.y = 0;
		}
		else if(p.y>=WorldCreator.HEIGHT-1){
			p.y = WorldCreator.HEIGHT-1;
		}
		else{
			p.y = (int) p.y + 1;
		}
		return p;
	}

	public static PlaceBuildingInteraction instance{
		get{
			return _instance;
		}
	}
}
