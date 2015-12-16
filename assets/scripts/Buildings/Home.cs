using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Home : Building {


    public List<Citizen> _owners = new List<Citizen>();
    public int _beds = 2;
	private int _prevNr = 0;
	public int _homeNr;
	public bool _filled = false; 

    

	private void Awake(){
		BedsMaster.AddBeds(_beds);
		HomeMaster.AddHouse (this);
	}

	public void MakeCitizenMoveIn(Citizen citizen){
		_owners.Add (citizen);
		citizen.house = this;
	}

	private void OnDestroy(){
		BedsMaster.AddBeds(-_beds);
	}

	private void setHomeNr() {
	
		_homeNr = _prevNr + 1; 


	}
}
