using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lego : MonoBehaviour
{
    public static GameObject slantpiece(string name = "slantpiece")
    {
        GameObject slant = new GameObject(name);
        GameObject ys = CubeClass.createCube(Vector3.zero, Vector3.zero, 0, new Vector3(1f, 1.5f, 0.5f), "yellowslant", Color.yellow);
        GameObject yss = CubeClass.createCube(new Vector3(0f, -0.1f, 0.26f), Vector3.right, -20, new Vector3(1f, 1.5f, 0.5f), "yellowslants", Color.yellow);
        ys.transform.SetParent(slant.transform);
        yss.transform.SetParent(slant.transform);
        return slant;
    }

    public static GameObject hookpiece(string name = "hookpiece")
    {
        GameObject hook = new GameObject(name);
        GameObject b = CubeClass.createCube(Vector3.zero, Vector3.zero, 0, new Vector3(1, 0.1f, 0.5f), "base1", Color.yellow);
        GameObject b1 = CubeClass.createCube(new Vector3(0.45f, 0.2f, 0.129f), Vector3.zero, 0, new Vector3(0.1f, 0.5f, 0.25f), "base2", Color.yellow);
        GameObject b2 = CubeClass.createCube(new Vector3(-0.45f, 0.2f, 0.129f), Vector3.zero, 0, new Vector3(0.1f, 0.5f, 0.25f), "base2", Color.yellow);

        GameObject bs1 = CubeClass.createCube(new Vector3(0.45f, 0.19f, -0.02f), Vector3.right, 38, new Vector3(0.1f, 0.5f, 0.15f), "base2", Color.yellow);
        GameObject bs2 = CubeClass.createCube(new Vector3(-0.45f, 0.19f, -0.02f), Vector3.right, 38, new Vector3(0.1f, 0.5f, 0.15f), "base2", Color.yellow);
        GameObject t = CubeClass.createCube(new Vector3(0, 0.4f, 0.15f), Vector3.zero, 0, new Vector3(1, 0.1f, 0.1f), "base1", Color.yellow);

        b.transform.SetParent(hook.transform);
        b1.transform.SetParent(hook.transform);
        b2.transform.SetParent(hook.transform);
        bs1.transform.SetParent(hook.transform);
        bs2.transform.SetParent(hook.transform);
        t.transform.SetParent(hook.transform);

        return hook;
    }
}
