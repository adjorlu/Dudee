using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MarriageMaster : MonoBehaviour {



	public static void UpdateMarriages(){
		List<Citizen> citizens = CitizenMaster.GetCitizens();
		List<Citizen> citizensReadyForMarriage = new List<Citizen>();
		
		foreach(Citizen c in citizens){
			if(IsAllowedToMarry(c)){
				citizensReadyForMarriage.Add(c);
			}
		}
		for(int i=0; i<citizensReadyForMarriage.Count-1; i++){
			for(int j=i+1; j<citizensReadyForMarriage.Count; j++){
				if(citizensReadyForMarriage[j].marriedTo!=null){		//citizensReadyForMarrige[j] could have become married in this loop, so we have to check for that...
					break;
				}
				if(citizensReadyForMarriage[i].isMale != citizensReadyForMarriage[j].isMale){
					if(Random.Range(0,10)<5){
						CreateMarriage(citizensReadyForMarriage[i], citizensReadyForMarriage[j]);
						break;
					}
				}
			}
		}
	}
	
	public static void CreateMarriage(Citizen citizen1, Citizen citizen2){
		citizen1.marriedTo = citizen2;
		citizen2.marriedTo = citizen1;
		if (citizen1.isMale) {
			citizen2.lastName = citizen1.lastName;
		} else {
			citizen1.lastName = citizen2.lastName;
		}
	}

	private static bool IsAllowedToMarry(Citizen citizen){
		if(citizen.marriedTo!=null){
			return false;
		}
		if(citizen.isMale){
			if(citizen.age < Politics._sexualAgeMale){
				return false;
			}
		}
		else{
			if(citizen.age < Politics._sexualAgeFemale){
				return false;
			}
		}
		return true;
	}
}
