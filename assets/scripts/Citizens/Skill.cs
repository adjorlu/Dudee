using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour {

	private Type _type;
	private int _xp = 0;
	private int _xpRequirementForNextLevel = 5;
	private int _level = 1;

	public Skill(Type type){
		_type = type;
	}

	public void AddXP(int amount){
		_xp += amount;
		if(_xp >= _xpRequirementForNextLevel){
			SetLevel(_level+1);
		}
	}

	private void SetLevel(int newLevel){
		_level = newLevel;
		//TODO: set new _xpRequirementForNextLevel more awesomely...
		_xpRequirementForNextLevel += 15;
	}

	public int level{
		get{
			return _level;
		}
	}

	public Type type{
		get{
			return _type;
		}
	}

	public enum Type{
		hunting,
		cooking,
		charming,
		astroPhysics,
	}

}
