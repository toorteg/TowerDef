using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableBuilding : MonoBehaviour {

    [HideInInspector]
    public List<Collider> colliders = new List<Collider>();
    public Material[] materials;
    private Grid m_grid;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[0];
    }
   

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Debug.Log("Test");           
        }
        if (col.tag == "Building")
        {            
            colliders.Add(col);            
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Building")
        {
            colliders.Remove(col);
        }
    }   

    public void MaterialChange(GameObject buildingToPaint, bool isLegalPlace, bool placed)
    {
        // Building already placed? If yes render green
        if (placed)
        {
            rend.sharedMaterial = materials[0];
        }
        // Else
        else
        {
            // If not legal render red
            if (!isLegalPlace)
            {
                rend.sharedMaterial = materials[1];
            }
            // else render green transparent
            else
            {
                rend.sharedMaterial = materials[2];
            }
        }
    }
}
