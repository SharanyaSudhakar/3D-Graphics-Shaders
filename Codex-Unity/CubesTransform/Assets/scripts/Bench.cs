using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bench : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var b = ParkBench();
        b.transform.SetParent(this.transform);
    }

    private GameObject ParkBench()
    {
        GameObject bench = new GameObject("Park Bench");
        var legleft = BenchLeg("leftleg");
        legleft.transform.localPosition = new Vector3(2.25f, 0, 0);
        var rightleg = BenchLeg("rightleg");
        rightleg.transform.localPosition = new Vector3(-2.25f, 0, 0);

        var benchbase = CubeClass.createCube(new Vector3(0, 1, 0), Vector3.zero, 0, new Vector3(5, 0.5f, 2f), "benchbase", Color.blue);
        var st = BenchStem("stemleft");
        var st2 = BenchStem("stemright");

        st.transform.localPosition = new Vector3(2.25f, 1.5f, 0.75f);
        st2.transform.Rotate(Vector3.up, 180f);
        st2.transform.localPosition = new Vector3(-2.25f, 1.5f, 0.75f);

        var top = CubeClass.createCube(new Vector3(0, 2.5f, 0.75f), Vector3.zero, 0, new Vector3(4, 0.5f, 0.5f), "top", Color.blue);

        benchbase.transform.SetParent(bench.transform);
        legleft.transform.SetParent(bench.transform);
        rightleg.transform.SetParent(bench.transform);
        st.transform.SetParent(bench.transform);
        st2.transform.SetParent(bench.transform);
        top.transform.SetParent(bench.transform);

        return bench;
    }

    private GameObject BenchStem(string name)
    {
        var stem = new GameObject(name);
        var s1 = CubeClass.createCube(Vector3.zero, Vector3.zero, 0, new Vector3(0.5f, 0.5f, 0.5f), "stem1", Color.blue);
        var s2 = CubeClass.createCube(new Vector3(-0.25f, 0.5f, 0), Vector3.zero, 0, new Vector3(1f, 0.5f, 0.5f), "stem1", Color.cyan);

        s1.transform.SetParent(stem.transform);
        s2.transform.SetParent(stem.transform);
        return stem;
    }

    private GameObject BenchLeg(string legname)
    {
        var leg = new GameObject(legname);

        var l1 = CubeClass.createCube(Vector3.zero, Vector3.zero, 0, new Vector3(0.5f, 0.5f, 2), "left1", Color.blue);
        var l2 = CubeClass.createCube(new Vector3(0, 0.5f, 0.75f), Vector3.zero, 0, new Vector3(0.5f, 0.5f, 0.5f), "left1", Color.cyan);
        var l3 = CubeClass.createCube(new Vector3(0, 0.5f, -0.75f), Vector3.zero, 0, new Vector3(0.5f, 0.5f, 0.5f), "left1", Color.cyan);

        l1.transform.SetParent(leg.transform);
        l2.transform.SetParent(leg.transform);
        l3.transform.SetParent(leg.transform);

        return leg;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
