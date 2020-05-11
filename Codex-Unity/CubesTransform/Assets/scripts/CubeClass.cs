using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeClass : MonoBehaviour
{
    public static GameObject createCube(Vector3 pos, Vector3 rot_axis, float angle,Vector3 scale, string name, Color clr)
    {
        GameObject cube0 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube0.transform.position = pos;
        cube0.AddComponent<Renderer>();
        cube0.GetComponent<Renderer>().material.color = clr;
        cube0.transform.Rotate(rot_axis, angle, Space.Self);
        cube0.transform.localScale = scale;
        cube0.name = name;
        return cube0;
    }
}
