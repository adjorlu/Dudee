using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CitizenManagementGUI : MonoBehaviour, iMenuButton {

	public bool _showMenu = false;
	private Citizen _selectedCitizen;
    

	public void Open(){
		this.enabled = true;
	}

	public void OnGUI(){
       
		ShowCitizens();
     
        if (_selectedCitizen!=null){
			ShowCitizenInfo(_selectedCitizen);
        }
	}

	private void ShowCitizens(){
		List<Citizen> citizens = CitizenMaster.GetCitizens();
		int i=0;
		foreach(Citizen citizen in citizens){
           
			if(GUI.Button(new Rect(5,100+(i*20),100,20), citizen.name) && citizen._showGUI == false){
				Reset();
                resetCitGui(citizen);
                GetComponent<ClickCitizenGUI>().Close(); 
				_selectedCitizen = citizen;
			}
            
            else if (citizen._showGUI == true)
            {
                _showMenu = false; 
                Reset();              
                resetCitGui(citizen);
                                         
                _selectedCitizen = citizen; 
            }
			i++;
		}
	}

	private void ShowCitizenInfo(Citizen citizen){
		GUI.Box(new Rect(Screen.width/2 - 200 ,100, 200,20), "Name: " + citizen.name.ToString() + " " + citizen.lastName.ToString());
		GUI.Box(new Rect(Screen.width/2 - 200, 120, 200,20), "Age: " + citizen.age.ToString());
		ShowJobAssignmentButton(citizen, new Rect(Screen.width / 2 - 200, 140, 200, 20));
		GUI.Box(new Rect(Screen.width / 2 - 200, 160, 200, 20), "Income: " + citizen.income.ToString());
		GUI.Box(new Rect(Screen.width/2 - 200,180,200,20), "Hunger: " + citizen.hunger.ToString());
		GUI.Box(new Rect(Screen.width/2 - 200,200,200,20), "Thurst: " + citizen.thurst.ToString());
        GUI.Box(new Rect(Screen.width / 2 - 200, 220, 200, 20), "Knowledge: " + citizen.knowledge.ToString());
    }

	private void ShowJobAssignmentButton(Citizen citizen, Rect area){
		if(CitizenUtils.IsAllowedToWork(citizen)==false){
			GUI.Box(area, "Too young to work");
			return;
		}
		if(citizen.job!=null){
			if(GUI.Button(area, citizen.job.name)){
				if(this.GetComponent<JobManagementGUI>().enabled){
					Reset();
				}
				else{
					this.GetComponent<JobManagementGUI>().Enable(citizen);
				}
			}
		}
		else{
			if(GUI.Button(area, "Assign Job")){
				if(this.GetComponent<JobManagementGUI>().enabled){
					Reset();
				}
				else{
					this.GetComponent<JobManagementGUI>().Enable(citizen);
				}
			}
		}
	}

	private void Reset(){
		this.GetComponent<JobManagementGUI>().enabled = false;
        //_showMenu = false;       
	}

    public void resetCitGui(Citizen citizen)
    {
        citizen._showGUI = false; 
    }
	
	public string GetButtonText(){
		return "CITIZENS";
	}



	public void Close(){
		Reset();
		_selectedCitizen = null;
		this.enabled = false;
	}
}
