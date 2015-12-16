using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JobsMaster : MonoBehaviour {

	private static List<GameObject> _jobsInTheVillage = new List<GameObject>();
	private static List<GameObject> _jobsOutsideTheVillage = new List<GameObject>();
	private static Transform _handle;

	public static void SetupDefaultJobs(){
		GameObject neighbourVillage = GameObject.Find ("Neighbour Village");

		//_jobsOutsideTheVillage.Add(CreateJob("Mining", neighbourVillage));
		//_jobsOutsideTheVillage.Add(CreateJob("Water Carrier", neighbourVillage));
	}

	public static List<GameObject> jobsInTheVillage{
		get{
			return _jobsInTheVillage;
		}
	}

	public static List<GameObject> jobsOutsideTheVillage{
		get{
			return _jobsOutsideTheVillage;
		}
	}

	public static void CreateJob(GameObject building, bool jobIsInTheVillage=true){
		string jobName = building.name;
		GameObject newJob = Instantiate(Resources.Load("Prefabs/Jobs/"+jobName)) as GameObject;
		newJob.name = newJob.name.Replace("(Clone)", "");
		newJob.transform.parent = GetHandle();
		newJob.GetComponent<Job>()._building = building;
		if(jobIsInTheVillage){
			_jobsInTheVillage.Add(newJob);
		}
		else{
			_jobsOutsideTheVillage.Add(newJob);
		}
	}

	private static Transform GetHandle(){
		if(_handle==null){
			_handle = GameObject.Find ("Jobs").transform;
		}
		return _handle;
	}

}
