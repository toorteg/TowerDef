using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    [SerializeField]
    private float f_size = 10f;
    [SerializeField]
    private float f_yGizmos = 0.5f;
    [SerializeField]
    private bool b_drawGizmos = false;

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
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
