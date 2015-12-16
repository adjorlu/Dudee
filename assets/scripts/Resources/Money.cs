using UnityEngine;
using System.Collections;

public class Money : MonoBehaviour {

    public static int _currentMoney = 100; 
	public static int _totalIncome;

	public static void AddTo(int amount){
		_currentMoney += amount;
	}
	
	public static void pay(int amount){
		if(_currentMoney - amount >= 0 ) { 
			_currentMoney -= amount;       
		}
	}
	
	public static int currentMoney{
		get{
			return _currentMoney;
		}
	}
}
