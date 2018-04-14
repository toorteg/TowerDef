using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {

    public GameObject[] goarr_buildings;
    private BuildingPlacer buildingPlacer;

	void Start () {
        buildingPlacer = FindObjectOfType<BuildingPlacer>();
    }
	
	void Update () {
		
	}

    void OnGUI()
    {
        for (int i = 0; i < goarr_buildings.Length; i++)
        {
            if (GUI.Button(new Rect(Screen.width/20, Screen.height/15 + Screen.height/12 * i,100,30), goarr_buildings[i].name))
            {
                buildingPlacer.SetBuilding(goarr_buildings[i]);
            }
        }
    }
}
