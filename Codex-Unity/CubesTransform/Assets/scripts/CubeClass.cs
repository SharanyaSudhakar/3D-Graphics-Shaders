using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeClass : MonoBehaviour
{
    /// <summary>
    /// The function creates a cube at a postion, roated about a 
    /// specified axis with the given angle. it can set the color 
    /// and name property of the cube.
    /// </summary>
    /// <param name="pos">Position of the Cube</param>
    /// <param name="rot_axis">Rotation Axis</param>
    /// <param name="angle">Angle of Rotation</param>
    /// <param name="scale">Scale of the Cube</param>
    /// <param name="name">Name Property</param>
    /// <param name="clr">Color Attribute</param>
    /// <returns>Returns a Cube GameObject</returns>
    public static GameObject createCube(Vector3 pos, Vector3 rot_axis, float angle,Vector3 scale, string name, Color clr)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localPosition = pos;
        cube.GetComponent<Renderer>().material.color = clr;
        cube.transform.Rotate(rot_axis, angle, Space.Self);
        cube.transform.localScale = scale;
        cube.name = name;
        return cube;
    }
}
