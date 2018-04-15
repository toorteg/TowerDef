using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    private GameObject go_buildingToBuild;
    private PlaceableBuilding m_placeableBuilding;
    private Grid m_grid;
    private bool b_buildingPlaced = false;
    private bool b_buildingInHand = false;
    //getter
    private bool gridDrawed = false;
    public bool get_IsBuildingInHand() {  return b_buildingInHand; }  
    private RaycastHit hitinfo;

    void Awake()
    {
        m_grid = FindObjectOfType<Grid>();
    }



    void Update()
    {
        // Function for Hovering and placing a Building
        // First check if any building has been selected from the BuildingManager.cs
        if (go_buildingToBuild != null && b_buildingPlaced == false)
        {
            b_buildingInHand = true;
            //Cast a Ray to the mouse position to feed the Grid.cs
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hitinfo))
            {
                if(gridDrawed == false)
                {
                    m_grid.SetGrid(hitinfo);
                    gridDrawed = true;
                }
                // first line is needed to not make the building fly away under the cursor... -.-
                // get the position of the building attached to the nearest grid point
                hitinfo.point = new Vector3(hitinfo.point.x, 1f, hitinfo.point.z);                
                if ((int)go_buildingToBuild.transform.localScale.x % 2 == 0)
                {
                    go_buildingToBuild.transform.position = m_grid.GetNearestPointOnGrid(hitinfo.point) - new Vector3(0.5f, 0f, 0f);
                }
                else
                {
                    go_buildingToBuild.transform.position = m_grid.GetNearestPointOnGrid(hitinfo.point);
                }

                // --Legal Check-- --Rendering-- //
                // Paint Red if Position not legal, else paint green                 
                // 3. Param is for "has been placed now" Render original color not transparent any more  

                if (!isLegalPosition())
                {
                    m_placeableBuilding.MaterialChange(go_buildingToBuild, false, false);
                }
                else
                {
                    m_placeableBuilding.MaterialChange(go_buildingToBuild, true, false);
                }

                if (Input.GetMouseButtonDown(0) && isLegalPosition() == true)
                {                    
                        PlaceBuildingNear(go_buildingToBuild.transform.position);
                        m_placeableBuilding.MaterialChange(go_buildingToBuild, true, true);                    
                }                
            }
        }
    }

    // Which Building was selected in "BuildingManager.cs"? Instantiate this
    public void SetBuilding(GameObject chosenBuilding)
    {
        b_buildingPlaced = false;
        go_buildingToBuild = GameObject.Instantiate(chosenBuilding);
    }

    // Check for other Buildings in area
    bool isLegalPosition()
    {
        m_placeableBuilding = go_buildingToBuild.GetComponent<PlaceableBuilding>();
        if (m_placeableBuilding.colliders.Count > 0)
        {         
            return false;
        }
        return true;
    }

    // Set the Building onto the map within the finalposition
    private void PlaceBuildingNear(Vector3 clickPoint)
    {
        var finalPosition = clickPoint;
        go_buildingToBuild.transform.position = finalPosition;
        b_buildingPlaced = true;
        NoBuildingInHand();
    }

    private void NoBuildingInHand()
    {
        b_buildingInHand = false;
    }

    void OnCollisionEnter(Collision col)
    {
        
    }
}