using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoodShopGUI : MonoBehaviour, iMenuButton
{

    private List<FoodShopItem> _purchasableFood = new List<FoodShopItem>();
    private FoodShopItem _currentSelectedItem;
    
    public void Open()
    {
        UpdateAvailableFood();
        this.enabled = true;
    }

    private void UpdateAvailableFood()
    {
        _purchasableFood.Clear();
        foreach (GameObject foodObj in FoodMaster.purchableFood)
        {
            _purchasableFood.Add(new FoodShopItem(foodObj, foodObj.name));
        }
    }

    private void OnGUI()
    {
        int i = 0;
        foreach (FoodShopItem foodShopItem in _purchasableFood)
        {
            if (GUI.Button(new Rect(100, 210 + (i * 20), 100, 20), foodShopItem._foodName))
            {
                if (_currentSelectedItem == foodShopItem)
                {
                    _currentSelectedItem = null;
                }
                else
                {
                    _currentSelectedItem = foodShopItem;
                }
            }
            i++;
        }
        if (_currentSelectedItem != null)
        {
            GUI.Box(new Rect(200, 210, 100, 20), _currentSelectedItem._foodName);
            if (GUI.Button(new Rect(200, 240, 50, 20), "BUY"))
            {
                BuyFood(_currentSelectedItem);
                MainGUI.instance.CloseMenu(this);
            }
            if (GUI.Button(new Rect(250, 240, 50, 20), "CANCEL"))
            {
                _currentSelectedItem = null;
            }
        }
    }

    private void BuyFood(FoodShopItem foodShopItem)
    {
        if(Money._currentMoney >= foodShopItem._foodPrice) { 
        Money.pay(foodShopItem._foodPrice);
        FoodStorage.AddTo(foodShopItem._foodNutrition);
        }
    }

    public string GetButtonText()
    {
        return "FOOD";
    }

    public void Close()
    {
        _currentSelectedItem = null;
        this.enabled = false;
    }
}

public class FoodShopItem
{
    public string _foodName;
    public int _foodPrice;
    public int _foodNutrition;
    public int _foodHappiness; 

    public GameObject _foodPrefab;
    
    public FoodShopItem(GameObject foodPrefab, string foodName)
    {
       
        _foodPrice = foodPrefab.GetComponent<Food>()._cost;
        _foodNutrition = foodPrefab.GetComponent<Food>()._nutrition;
        _foodHappiness = foodPrefab.GetComponent<Food>()._happiness; 

        _foodPrefab = foodPrefab;
        _foodName = foodName;
        
    }
}
