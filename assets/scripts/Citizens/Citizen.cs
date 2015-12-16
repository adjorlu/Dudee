using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Citizen : MonoBehaviour {

	private string _name;
	private string _lastName; 
	private int _age;
	private bool _isMale;
	private int _health;
	private int _hunger;
	private int _foodRequirement = 10;
	private int _thurst;
	private int _waterRequirement = 10;
	private int _happiness;
	private int _knowledge;
	private Job _job;
	public Citizen _marriedTo = null;
    public Home house = null; 
	public Citizen _mother = null;
	public Citizen _father = null;
	public List<Citizen> _children = new List<Citizen>();
	private bool _isDead = false;
	private static Transform _handle;
	private List<Skill> _skills = new List<Skill>();
    public bool _showGUI = false; 

    private void Awake(){
		transform.parent = GetHandle();
        
	}

	public void UpdateAgeOfCitizen(){
		_age++;
		if(_age==30){
			_isDead = true;
		}
	}

    public void UpdateKnowledgeOfCitizen()
    {
        _knowledge++;
    }

	public void UpdateHunger(){
		_hunger += _foodRequirement;
		if(_hunger>=100){
			_isDead = true;
		}
	}

	public void UpdateThurst(){
		_thurst += _waterRequirement;
		if(_thurst>=100){
			_isDead = true;
		}
	}

	public void Eat(){
		int foodAvailableForMe = FoodStorage.TryTakeAmount(_foodRequirement);
		_hunger -= foodAvailableForMe;
	}

	public void Drink(){
		int waterAvailableForMe = WaterStorage.TryTakeAmount(_waterRequirement);
		_thurst -= waterAvailableForMe;
	}

	public void Die(){
		CitizenMaster.CitizenDied(this);
	}

	public string name{
		get{
			return _name;
		}
		set{
			_name = value;
		}
	}

	public string lastName{
		get{
			return _lastName;
		}
		set{
			_lastName = value;
		}
	}

	public int age{
		get{
			return _age;
		}
		set{
			_age = value;
		}
	}

	public bool isMale
	{
		get
		{
			return _isMale;
		}
		set
		{
			_isMale = value;
		}
	}

	public Job job{
		get{
			return _job;
		}
		set{
			_job = value;
		}
	}

    public int knowledge
    {
        get
        {
            return _knowledge;
        }
        set
        {
            _knowledge = value; 
        }
    }
	
	public int income
	{
		get
		{
			if(_job==null){
				return 0;
			}
			else{
				return _job._salary; 
			}
		}
	}

	public int health{
		get{
			return _health;
		}
	}

	public int hunger{
		get{
			return _hunger;
		}
	}

	public int thurst{
		get{
			return _thurst;
		}
	}

	public Citizen marriedTo{
		get{
			return _marriedTo;
		}
		set{
			_marriedTo = value;
		}
	}

    

	public void SetParents(Citizen mother, Citizen father){
		_mother = mother;
		_father = father;
	}

	public void AddChild(Citizen newBornChild){
		_children.Add(newBornChild);
	}

	public bool WantsToLiveWithParents(){
		if (_isMale){
			if(_age >= Politics._wantsToMoveAwayFromHomeAgeMale) {
				return false;
			}
		}
		else if(_age >= Politics._wantsToMoveAwayFromHomeAgeFemale) {
			return false;
		}
		return true;
	}

	public bool hasDied{
		get{
			return _isDead;
		}
	}

	public Skill AddXpToSkill(Skill.Type skillType, int amount){
		foreach(Skill s in _skills){
			if(s.type == skillType){
				s.AddXP(amount);
				return s;
			}
		}
		//the citizen don't have this skill yet (because of the loop above), so we add a new skill of this type to the citizen...
		Skill newSkill = new Skill(skillType);
		newSkill.AddXP(amount);
		_skills.Add(newSkill);
		return newSkill;
	}

	/*public List<Skill> skills{
		get{
			return _skills;
		}
	}*/

	private static Transform GetHandle(){
		if(_handle==null){
			_handle = GameObject.Find ("Citizens").transform;
		}
		return _handle;
	}

  
   void OnMouseDown()
    {
        
        if (_showGUI == false)
        {
            _showGUI = true;
          
        }
       else if(_showGUI == true) { 
            _showGUI = false;
            GetComponent<ClickCitizenGUI>().Close();
        }
    }
}
