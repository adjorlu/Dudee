using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Job : MonoBehaviour {




    public int _effektOnKnowledge;
    public int _cost; 
	public int _salary;
	public int _effectOnHappiness;
	public GameObject _building;

	virtual public void DoJob(Citizen citizen){
		//override in subclasses...
	}
}
