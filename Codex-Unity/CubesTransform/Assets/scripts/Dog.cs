using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var d = CreateDog();
        d.transform.localPosition = new Vector3(-4, 0, -3);
        d.transform.SetParent(this.transform);
    }

    private GameObject CreateDog()
    {
        var _dog = new GameObject("dog");

        var l = CubeClass.createCube(new Vector3(0, 0f, -0.75f), Vector3.zero, 0, new Vector3(1, 0.5f, 0.5f), "leg", Color.yellow);
        var l2 = CubeClass.createCube(new Vector3(0, 0f, 0.5f), Vector3.zero, 0, new Vector3(2, 0.5f, 1f), "backleg", Color.yellow);
        var b = CubeClass.createCube(new Vector3(0, 0.5f, 0), Vector3.zero, 0, new Vector3(1, 0.5f, 2f), "body", Color.yellow);

        var collar = CubeClass.createCube(new Vector3(0.25f, 0.85f, -0.5f), Vector3.zero, 0, new Vector3(1.5f, 0.20f, 1f), "collar", Color.red);

        var h1 = CubeClass.createCube(new Vector3(0, 1.23f, -0.75f), Vector3.zero, 0, new Vector3(1f, 0.5f, 1.5f), "head", Color.yellow);
        var h2 = CubeClass.createCube(new Vector3(0, 1.7f, -0.5f), Vector3.zero, 0, new Vector3(1f, 0.5f, 1f), "head", Color.yellow);
        var ear1 = Lego.hookpiece("ear1");
        ear1.transform.localPosition = new Vector3(0.25f, 2f, -0.5f);
        ear1.transform.Rotate(Vector3.up, 90);
        var ear2 = Lego.hookpiece("ear2");
        ear2.transform.localPosition = new Vector3(-0.25f, 2f, -0.5f);
        ear2.transform.Rotate(Vector3.up, -90);

        l.transform.SetParent(_dog.transform);
        l2.transform.SetParent(_dog.transform);
        b.transform.SetParent(_dog.transform);
        collar.transform.SetParent(_dog.transform);
        h2.transform.SetParent(_dog.transform);
        h1.transform.SetParent(_dog.transform);
        ear1.transform.SetParent(_dog.transform);
        ear2.transform.SetParent(_dog.transform);
        return _dog;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
