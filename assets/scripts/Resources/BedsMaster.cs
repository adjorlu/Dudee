using UnityEngine;
using System.Collections;

public class BedsMaster : MonoBehaviour {

	private static int _beds = 0;

	public static void AddBeds(int amount){
		_beds += amount;
		print (_beds);
	}

	public static int beds{
		get{
			return _beds;
		}
	}
}
