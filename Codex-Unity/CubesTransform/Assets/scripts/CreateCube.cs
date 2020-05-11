using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(0, 0, -2);
        GameObject cube = CubeClass.createCube(pos, Vector3.up, 45f, Vector3.one, "Cube_01", Color.cyan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
