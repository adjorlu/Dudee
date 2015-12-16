using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Food : MonoBehaviour
{

    public int _cost;
    public int _nutrition;
    public int _happiness;
    public int _sickness; 

    public List<GameObject> _Foods = new List<GameObject>();
}
