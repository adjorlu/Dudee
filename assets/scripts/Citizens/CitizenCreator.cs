using UnityEngine;
using System.Collections;

public class CitizenCreator : MonoBehaviour {

	private static GameObject _citizenPrefab;
	private static int _citizenPositionX = 2; 

	public static GameObject CreateCitizen(int startAge=0, Gender gender=Gender.random){
		GameObject citizenObject = Instantiate(CitizenPrefab(), new Vector3(_citizenPositionX, 8, 0), Quaternion.identity) as GameObject;
		_citizenPositionX++; 
		Citizen citizen = citizenObject.GetComponent<Citizen>();

		bool isMale;
		if (gender == Gender.male) {
			isMale = true;
		} 
		else if (gender == Gender.female) {
			isMale = false;
		}
		else {
			isMale = Random.value > 0.5f;
		}
		citizen.name = citizenObject.name = NameProvider.GetRandomName(isMale);
		citizen.lastName = NameProvider.getRandomLastName(); 

		citizen.isMale = isMale;
		if(isMale==false){
			citizenObject.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("AnimationControllers/Citizen_AnimationController_Female") as RuntimeAnimatorController;
		}
		citizen.age = startAge;
        citizen.knowledge = Random.Range(0, 30);

		return citizenObject;
	}

	private static GameObject CitizenPrefab(){
		if(_citizenPrefab==null){
			_citizenPrefab = Resources.Load("Prefabs/Citizen") as GameObject;
		}
		return _citizenPrefab;
	}

	public enum Gender{
		male,
		female,
		random,
	}
}
