using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {

    private Grid m_grid;
    private PlaceableBuilding m_placeableBuilding;
    private BuildingPlacer m_BuildingPlacer;
	// Use this for initialization
	void Start () {
        m_BuildingPlacer = FindObjectOfType<BuildingPlacer>();
        m_grid = FindObjectOfType<Grid>();
        m_placeableBuilding = FindObjectOfType<PlaceableBuilding>();
    }
	
	// Update is called once per frame
	void Update () {
		/*if (m_BuildingPlacer.get_IsBuildingInHand() == true)
        {
            RaycastHit hitinfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitinfo))
            {
                m_grid.UpdateGrid((int)hitinfo.point.x - 3, (int)hitinfo.point.z - 3, (int)hitinfo.point.x + 3, (int)hitinfo.point.z + 3, true);
            }
        }*/
	}
}
