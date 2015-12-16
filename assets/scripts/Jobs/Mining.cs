using UnityEngine;
using System.Collections;

public class Mining : Job {
    public int _Salary = 5; 
	override public void DoJob(Citizen citizen){
        Money.AddTo(_salary);

	}
}
