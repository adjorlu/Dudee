using UnityEngine;
using System.Collections;

public class WaterCarrier : Job {

	public int _waterPerTurn = 10;

	override public void DoJob(Citizen citizen)
    {
		WaterStorage.AddTo(_waterPerTurn);
	}
}
