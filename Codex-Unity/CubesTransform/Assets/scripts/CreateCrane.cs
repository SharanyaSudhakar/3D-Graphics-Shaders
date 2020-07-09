using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCrane : MonoBehaviour
{
    readonly Color orange = new Color(1, 0.44f, 0);
    // Start is called before the first frame update
    void Start()
    {
        //base
        GameObject b = CubeClass.createCube(new Vector3(0, 0, 2f), Vector3.zero, 0, new Vector3(5, 0.5f, 1), "base1", Color.black);
        GameObject b1 = CubeClass.createCube(new Vector3(0, 0, -2f), Vector3.zero, 0, new Vector3(5, 0.5f, 1), "base2", Color.black);
        GameObject yb11 = CubeClass.createCube(new Vector3(1, 0.5f, 0), Vector3.up, 90, new Vector3(5, 0.5f, 1), "yellowBase11", Color.yellow);
        GameObject yb12 = CubeClass.createCube(new Vector3(-1, 0.5f, 0), Vector3.up, 90, new Vector3(5, 0.5f, 1), "yellowBase12", Color.yellow);

        //tower base
        GameObject yb21 = CubeClass.createCube(new Vector3(0, 1f, 0.5f), Vector3.zero, 0, new Vector3(3, 0.5f, 1), "yellowBase21", Color.yellow);
        GameObject yb22 = CubeClass.createCube(new Vector3(0, 1f, -0.5f), Vector3.zero, 0, new Vector3(3, 0.5f, 1), "yellowBase22", Color.yellow);
        GameObject cb = CubeClass.createCube(new Vector3(0, 1.5f, 0f), Vector3.zero, 0, new Vector3(2.5f, 0.5f, 2f), "centerbase", Color.black);
        GameObject t = tower();

        b.transform.SetParent(this.transform);
        b1.transform.SetParent(this.transform);
        yb11.transform.SetParent(this.transform);
        yb12.transform.SetParent(this.transform);
        yb21.transform.SetParent(this.transform);
        yb22.transform.SetParent(this.transform);
        cb.transform.SetParent(this.transform);
        t.transform.SetParent(this.transform);
    }    

    private GameObject tower()
    {
        GameObject tower = new GameObject("tower");
        //tower
        GameObject ob = CubeClass.createCube(new Vector3(0, 2f, 0f), Vector3.zero, 0, new Vector3(2.5f, 0.5f, 2f), "centerbaseOrange", orange);
        GameObject ob11 = CubeClass.createCube(new Vector3(0.5f, 2.5f, 0.25f), Vector3.up, 90, new Vector3(1.5f, 0.5f, 1f), "centerbaseOrange11", orange);
        GameObject ob12 = CubeClass.createCube(new Vector3(-0.5f, 2.5f, 0.25f), Vector3.up, 90, new Vector3(1.5f, 0.5f, 1f), "centerbaseOrange12", orange);
        GameObject ob13 = CubeClass.createCube(new Vector3(0f, 2.5f, -0.75f), Vector3.zero, 0, new Vector3(1f, 0.5f, 0.5f), "centerbaseOrange13", orange);

        for (int i = 0; i < 3; i++)
        {
            GameObject cube = CubeClass.createCube(new Vector3(0f, 3f + (i * 0.5f), -0.5f), Vector3.zero, 0, new Vector3(1f, 0.5f, 1f), "orangeCube" + i, orange);
            cube.transform.SetParent(tower.transform);
        }

        GameObject ob21 = CubeClass.createCube(new Vector3(0f, 4.5f, -0.25f), Vector3.up, 90, new Vector3(1.5f, 0.5f, 1f), "topOrangeBase", orange);
        GameObject sp = Lego.slantpiece();
        sp.transform.localPosition = new Vector3(0f, 3.5f, 0.25f);
        GameObject yt = CubeClass.createCube(new Vector3(0f, 5f, -0.5f), Vector3.up, 90, new Vector3(2f, 0.5f, 1f), "topyellow", Color.yellow);


        ob.transform.SetParent(tower.transform);
        ob11.transform.SetParent(tower.transform);
        ob12.transform.SetParent(tower.transform);
        ob13.transform.SetParent(tower.transform);
        sp.transform.SetParent(tower.transform);
        ob21.transform.SetParent(tower.transform);
        yt.transform.SetParent(tower.transform);
        return tower;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
