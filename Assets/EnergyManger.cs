using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManger : MonoBehaviour{

    public enum EnergyType
    {
        HAPPY = -1,
        ANGRY = 3
    }



    private List<Energy> energies = new List<Energy>();

    private Vector3[] m_energyPlaceCenters;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}


