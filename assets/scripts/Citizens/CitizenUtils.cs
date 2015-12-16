using UnityEngine;
using System.Collections;

public class CitizenUtils : MonoBehaviour {

	public static bool IsAllowedToWork(Citizen citizen){
		if(citizen.isMale){
			if(citizen.age >= Politics._workAgeMale){
				return true;
			}
		}
		else{
			if(citizen.age >= Politics._workAgeFemale){
				return true;
			}
		}
		return false;
	}
}
