using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HomeMaster : MonoBehaviour {
	
	public static List<Home> _homes = new List<Home>();

	public static void AddHouse(Home home)
    {
        _homes.Add(home);
    }

	public static List<Home> GetUnoccupied(){
		List<Home> unoccupiedHouses = new List<Home> ();
		foreach (Home home in _homes) {
			if(home._owners.Count == 0){
				unoccupiedHouses.Add( home );
			}
		}
		return unoccupiedHouses;
	}

}
