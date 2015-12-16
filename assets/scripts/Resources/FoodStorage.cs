using UnityEngine;
using System.Collections;

public class FoodStorage : MonoBehaviour {

	private static int _capacity = 100;
	private static int _currentStock;

	public static int TryTakeAmount(int amount){
		if(amount > _currentStock){
			int _amountToReturn = _currentStock;
			_currentStock=0;
			return _amountToReturn;
		}
		else{
			_currentStock -= amount;
			return amount;
		}
	}

	public static void AddTo(int amount){
		_currentStock += amount;
		if(_currentStock > _capacity){
			_currentStock = _capacity;
		}
	}

	public static int currentStock{
		get{
			return _currentStock;
		}
	}

	public static int capacity{
		get{
			return _capacity;
		}
	}

}
