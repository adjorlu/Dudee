using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CitizenMaster : MonoBehaviour {

	private static int _amountOfCitizensAtStart = 5;

	private static List<Citizen> _citizens = new List<Citizen>();
    public static List<Home> _Homes = new List<Home>(); 

	private static int _amountOfFemales;
	private static int _amountOfMales;
	private static int _amountOfChildren;

   
    
    public static void Init(){

		List<Home> unoccupiedHouses = HomeMaster.GetUnoccupied ();
		CreateFamily (2, 1, unoccupiedHouses [0]);
		CreateFamily (1, 2, unoccupiedHouses [1]);
		CreateFamily (1, 1, unoccupiedHouses [2]);

		UpdateCitizens();
	}

	private static Citizen CreateInitialPerson(int age, CitizenCreator.Gender gender){
		GameObject newCitizen = CitizenCreator.CreateCitizen(age, gender);
		_citizens.Add(newCitizen.GetComponent<Citizen>());
		return newCitizen.GetComponent<Citizen> ();
	}

	private static void CreateFamily(int amountOfChildrenBoys, int amountOfChildrenGirls, Home home){
		//parents
		Citizen dad = CreateInitialPerson (25, CitizenCreator.Gender.male);
		Citizen mom = CreateInitialPerson (25, CitizenCreator.Gender.female);
		MarriageMaster.CreateMarriage(dad, mom);
		home.MakeCitizenMoveIn (dad);
		home.MakeCitizenMoveIn (mom);
		//children
		for (int i=0; i<amountOfChildrenBoys; i++) {
			Citizen boy = CreateInitialPerson (10, CitizenCreator.Gender.male);
			boy.SetParents (mom, dad);
			boy.lastName = dad.lastName;
			mom.AddChild (boy);
			dad.AddChild (boy);
			home.MakeCitizenMoveIn (boy);
		}
		for (int i=0; i<amountOfChildrenGirls; i++) {
			Citizen girl = CreateInitialPerson (8, CitizenCreator.Gender.female);
			girl.SetParents (mom, dad);
			girl.lastName = dad.lastName;
			mom.AddChild (girl);
			dad.AddChild (girl);
			home.MakeCitizenMoveIn(girl);
		}
	}

	public static void UpdateCitizens(){
		_amountOfFemales = 0;
		_amountOfMales = 0;
		_amountOfChildren = 0;
		for(int i=_citizens.Count-1; i>=0; i--){
			UpdateCitizen(_citizens[i]);
		}
		MarriageMaster.UpdateMarriages();
		CheckBabyBirths();
	}

	private static void UpdateCitizen(Citizen citizen){
		//AGE
		citizen.UpdateAgeOfCitizen();
        citizen.UpdateKnowledgeOfCitizen(); 
		if(citizen.hasDied){
			citizen.Die();
			return;
		}
		//EAT
		citizen.UpdateHunger();
		if(citizen.hasDied){
			citizen.Die();
			return;
		}
		else{
			citizen.Eat();
		}
		//DRINK
		citizen.UpdateThurst();
		if(citizen.hasDied){
			citizen.Die();
			return;
		}
		else{
			citizen.Drink();
		}
		//WORK
		if(citizen.job!=null){
			Money.AddTo(citizen.job._salary);
			citizen.job.DoJob(citizen);
		}
		//STATISTICS
		if (citizen.isMale == true && citizen.age > Politics._sexualAgeMale)
		{
			_amountOfMales += 1;
		}
		else if (citizen.age > Politics._sexualAgeFemale)
		{
			_amountOfFemales += 1;
		}
		else{
			_amountOfChildren += 1;
		}
	}

	private static void CheckBabyBirths(){
		List<Citizen> _citizensLeftToBeChecked = new List<Citizen>(_citizens);
		for(int i=_citizensLeftToBeChecked.Count-1; i>=0; i--){
			if(_citizensLeftToBeChecked[i].isMale==false && _citizensLeftToBeChecked[i].marriedTo!=null){
				if(Random.Range(0,10) < 5){
					newBabyIsBorn(_citizensLeftToBeChecked[i], _citizensLeftToBeChecked[i].marriedTo);
					_citizensLeftToBeChecked.RemoveAt(i);
				}
			}
		}
	}

	private static void newBabyIsBorn(Citizen mother, Citizen father)
	{     
		GameObject babyObj = CitizenCreator.CreateCitizen();
		Citizen baby = babyObj.GetComponent<Citizen>();
		baby.SetParents(mother, father);
		baby.lastName = father.lastName;
        baby.knowledge = 0; 
		mother.AddChild(baby);
		father.AddChild(baby);
		mother.house.MakeCitizenMoveIn (baby);
		_citizens.Add(baby);
		_amountOfChildren++;
	}


    public static void ChekForHome(Citizen citizen, Home home)
    {
        if (citizen.house == null)
        {

            for(int s = 0; s < HomeMaster._homes.Count(); s++)
            {
                //if( HomeMaster._homes.)
            }

        }
    }

	public static void CitizenDied(Citizen citizen){
		_citizens.Remove(citizen);
		Destroy(citizen.gameObject);
	}

	public static List<Citizen> GetCitizens(){
		return _citizens;
	}

	public static int amountOfMales{
		get{
			return _amountOfMales;
		}
	}

	public static int amountOfFemales{
		get{
			return _amountOfFemales;
		}
	}

	public static int amountOfChildren{
		get{
			return _amountOfChildren;
		}
	}

	public static int amountOfCitizens{
		get{
			return _citizens.Count;
		}
	}
}
