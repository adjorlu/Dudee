using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NameProvider : MonoBehaviour {

	private static List<string> _maleNames = new List<string>{"Ali", "Rune", "Daniel", "Hassan", "Bob"};
	private static List<string> _femaleNames = new List<string>{"Anne", "Lotte", "Anne-lotte", "Benedikte"};

	private static List<string> _lastNames = new List<string> {"Adjorlu", "Andersen", "Nielsen", "Lykkegaard", "Rosgaard", "Abdull", "Walhalla", "Dudelsen", "Nissen"};

	public static string GetRandomName(bool isMale){
		if(isMale){
			int randomNumber = Random.Range(0, _maleNames.Count);
			return _maleNames[randomNumber];
		}
		else{
			int randomNumber = Random.Range(0, _femaleNames.Count);
			return _femaleNames[randomNumber];
		}
	}

	public static string getRandomLastName () {
		int randomNumber = Random.Range(0, _lastNames.Count); 
		return _lastNames [randomNumber]; 


	}
}
