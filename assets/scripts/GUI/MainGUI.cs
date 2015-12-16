using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainGUI : MonoBehaviour {
	
	private List<iMenuButton> _menuButtons = new List<iMenuButton>();
	private int _currentOpenMenuId=-1;
	private static MainGUI _instance;

	private void Awake(){
		_instance = this;
		_menuButtons.Add(this.GetComponent<CitizenManagementGUI>());
		_menuButtons.Add(this.GetComponent<BuildingShopGUI>());
        _menuButtons.Add(this.GetComponent<FoodShopGUI>());
       
	}

	private void OnGUI(){
		int i=0;
		foreach(iMenuButton menuButton in _menuButtons){
			string buttonText = menuButton.GetButtonText();
			if(i==_currentOpenMenuId){
				buttonText = "["+buttonText+"]";
			}
			if(GUI.Button(new Rect((i*110),Screen.height-105,100,100), buttonText)){
                
				if(_currentOpenMenuId==i){
					_menuButtons[_currentOpenMenuId].Close();
					_currentOpenMenuId = -1;
				}
				else{
					if(_currentOpenMenuId!=-1){
						_menuButtons[_currentOpenMenuId].Close();
					}

              
					_currentOpenMenuId = i;
					_menuButtons[i].Open();
				}
			}
			i++;
		}
	}

	public void CloseMenu(iMenuButton menuToBeClosed){
		menuToBeClosed.Close();
		_currentOpenMenuId = -1;
	}

	public static MainGUI instance{
		get{
			return _instance;
		}
	}

}
