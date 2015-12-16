using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {

	public int _year = 2015;
	public int _hour = 0;
	private int _timeInterval = 1;
	public static int _newBornYear = 0; 
	
	public void StartClock(){
		Invoke ("UpdateTime", _timeInterval);
	}
	
	private void UpdateTime(){
		_hour++;
		_hour = _hour%24;
		if(_hour==0){
			OnNewDay();
		}
		Invoke ("UpdateTime", _timeInterval);
	}
	
	private void OnNewDay(){
		CitizenMaster.UpdateCitizens();
		_year += 1;
		_newBornYear += 1; 
		
		if(_newBornYear ==4)
		{
			_newBornYear = 0; 
		}		
	}
	
	private void OnGUI(){
		GUI.Box(new Rect(0,0, 200,20), _hour.ToString()+":00");
		GUI.Box(new Rect(0, 22, 200, 20), "Year: " + _year);
	}

}
