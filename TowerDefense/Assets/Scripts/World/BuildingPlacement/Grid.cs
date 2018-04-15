using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject/*[][]*/ goarr_playerGrid;

    [SerializeField]
    private GameObject _gridObject;

    /*[SerializeField]
    private Transform _transform;

    [SerializeField]
    private Material _material;

    [SerializeField]
    private Vector2 _gridSize;
    */
    [SerializeField]
    private int _rows;

    [SerializeField]
    private int _columns;

    [SerializeField]
    private float f_size = 10f;
    [SerializeField]
    private float f_yGizmos = 0.5f;
    [SerializeField]
    private bool b_drawGizmos = false;
  
    // Painting Overlay Grid
    void Start()
    {

        UpdateGrid();
        
    }

    public void UpdateGrid()
    {
        for(int x = -49; x < _rows-50; x++)
        {
            for(int z = -49; z < _columns-50; z++)
            {
                goarr_playerGrid = GameObject.Instantiate(_gridObject);
                goarr_playerGrid.transform.localScale = new Vector3(goarr_playerGrid.transform.localScale.x * 1.5f, goarr_playerGrid.transform.localScale.y * 1.5f, 1.0f );
                goarr_playerGrid.transform.position = new Vector3(x, 0.51f, z);
                /*GameObject.Instantiate(_gridObject);
                this.transform.position = new Vector3(x, 0.51f, z);*/
               /* goarr_playerGrid[x][z] = this.gameObject;
                Debug.Log(_gridObject.transform.position);
                Debug.Log(goarr_playerGrid[x][z]);*/
            }
        }
        /*
        _transform.localScale = new Vector3(_gridSize.x, _gridSize.y, 1.0f);

        _material.SetTextureScale("_MainTex", new Vector2(_columns, _rows));       
        */
    }

    // Dunno..
    // Guy is explaining but I didn't listen ^^ Source Code here:
    // https://www.youtube.com/watch?v=VBZFYGWvm4A
    // Casting to int rounding the results casting back to make it attach to a grid
    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / f_size);
        int yCount = Mathf.RoundToInt(position.y / f_size);
        int zCount = Mathf.RoundToInt(position.z / f_size);

        Vector3 result = new Vector3(
        (float)xCount * f_size,
        (float)yCount * f_size,
        (float)zCount * f_size);

        result += transform.position;

        return result;
    }

    // Draw the Gizmos. Just for Scene not ingame
    private void OnDrawGizmos()
    {
        if (b_drawGizmos == true)
        {

            Gizmos.color = Color.yellow;
            for (float x = -50; x < 50; x += f_size)
            {
                for (float z = -50; z < 50; z += f_size)
                {
                    var point = GetNearestPointOnGrid(new Vector3(x, f_yGizmos, z));
                    Gizmos.DrawSphere(point, 0.1f);                   
                }
            }

        }
    }
	
	// Update is called once per frame
	void Update () {
       /* for (int x = 0; x < _gridSize.x; x++)
        {
            for (int z = 0; z < _gridSize.y; z++)
            {
                _gridObject.transform.position = new Vector3(x, 0.51f, z);
                goarr_playerGrid[x][z] = GameObject.Instantiate(_gridObject);
            }
        }*/
    }
}
