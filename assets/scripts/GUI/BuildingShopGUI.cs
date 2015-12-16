using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingShopGUI : MonoBehaviour, iMenuButton
{

    private List<ShopItem> _purchasableBuildings = new List<ShopItem>();
    private ShopItem _currentSelectedItem;


    public static int _numberBeds; 
    public void Open()
    {
        UpdateAvailableBuildings();
        this.enabled = true;
    }

    private void UpdateAvailableBuildings()
    {
        _purchasableBuildings.Clear();
        foreach (GameObject buildingObj in BuildingMaster.purchableBuildings)
        {
            _purchasableBuildings.Add(new ShopItem(buildingObj, buildingObj.name));
            
        }
    }

    private void OnGUI()
    {
        int i = 0;
        foreach (ShopItem shopItem in _purchasableBuildings)
        {
            if (GUI.Button(new Rect(100, 210 + (i * 20), 100, 20), shopItem._buildingName))
            {
                if (_currentSelectedItem == shopItem)
                {
                    _currentSelectedItem = null;
                }
                else
                {
                    _currentSelectedItem = shopItem;
                }
            }
            i++;
        }
        if (_currentSelectedItem != null)
        {
            GUI.Box(new Rect(200, 210, 100, 20), _currentSelectedItem._buildingName);
            if (GUI.Button(new Rect(200, 240, 50, 20), "BUY"))
            {
                if(Money._currentMoney >= _currentSelectedItem._buildingPrice) { 
                BuyBuilding(_currentSelectedItem);
                Money.pay(_currentSelectedItem._buildingPrice);
                _numberBeds = _numberBeds +  _currentSelectedItem._bed;
                }
                MainGUI.instance.CloseMenu(this);
            }
            if (GUI.Button(new Rect(250, 240, 50, 20), "CANCEL"))
            {
                _currentSelectedItem = null;
            }
        }
    }

    private void BuyBuilding(ShopItem shopItem)
    {
        GameObject newlyBoughtBuilding = BuildingMaster.CreateBuilding(shopItem._buildingPrefab);
        PlaceBuildingInteraction.instance.Enable(newlyBoughtBuilding);
    }

    public string GetButtonText()
    {
        return "BUILDINGS";
    }

    public void Close()
    {
        _currentSelectedItem = null;
        this.enabled = false;
    }
}

public class ShopItem
{
    public int _buildingPrice; 
    public string _buildingName;
    public int _bed = 0; 
    public GameObject _buildingPrefab;
    public Building home; 

    public ShopItem(GameObject buildingPrefab, string buildingName)
    {

        

        
        _buildingPrice = buildingPrefab.GetComponent<Building>()._cost; 
        _buildingPrefab = buildingPrefab;
        _buildingName = buildingName;


        if (buildingName == "Home") {
            _bed = + buildingPrefab.GetComponent<Home>()._beds;
        }

    }
}
