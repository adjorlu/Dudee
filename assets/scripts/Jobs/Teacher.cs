using UnityEngine;
using System.Collections;

public class Teacher : Job {

    public static int _teachingLevel; 

    override public void DoJob(Citizen citizen)
    {
        _teachingLevel = citizen.knowledge / 10; 
        

    }
}
