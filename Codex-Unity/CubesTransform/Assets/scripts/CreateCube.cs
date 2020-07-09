using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{
    [SerializeField] Vector3 pos, scale;
    // Start is called before the first frame update
    void Start()
    {
   
        //up - y
        //forward = z
        //right - x
        GameObject cube = CubeClass.createCube(pos, Vector3.forward, 45f, scale, "Cube_01", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
