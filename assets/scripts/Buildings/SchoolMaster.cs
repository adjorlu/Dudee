using UnityEngine;
using System.Collections;

public class SchoolMaster : Job {


    public int _dailyFee = 5;
    public int _knowledgeGained = 0; 


    override public void DoJob(Citizen citizen)
    {
        _knowledgeGained = Teacher._teachingLevel;
        citizen.knowledge = citizen.knowledge + _knowledgeGained;
        Money.AddTo(-_dailyFee); 
    }
}
