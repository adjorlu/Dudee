using UnityEngine;
using System.Collections;

public class JobManagementGUI : MonoBehaviour {

	private Citizen _currentCitizen;

	public void Enable(Citizen citizen){
		_currentCitizen = citizen;
		this.enabled = true;
	}

	private void OnGUI(){

		GUI.Box(new Rect(Screen.width/2,75,200,20), "Jobs in the Village");
		int i=0;
		foreach(GameObject job in JobsMaster.jobsInTheVillage){
			if(GUI.Button(new Rect(Screen.width/2,100+(i*25),200,20), job.name)){
				_currentCitizen.job = job.GetComponent<Job>();
			}
			i++;
		}
		GUI.Box(new Rect(Screen.width/2 + 205,75,200,20), "Jobs outside the Village");
		i=0;
		foreach(GameObject job in JobsMaster.jobsOutsideTheVillage){
			if(GUI.Button(new Rect(Screen.width/2 + 205,100+(i*25),200,20), job.name)){
				_currentCitizen.job = job.GetComponent<Job>();
			}
			i++;
		}
	}
}
