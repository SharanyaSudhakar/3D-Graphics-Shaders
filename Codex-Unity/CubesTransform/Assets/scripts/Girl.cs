using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var g = CreateGirl();
        g.transform.localPosition = new Vector3(0, 0, -1.75f);
        g.transform.SetParent(this.transform);
    }

    private GameObject CreateGirl()
    {
        var girl = new GameObject("girl");
        float back = 1.5f;
        var leftleg = CreateLeg();
        leftleg.transform.localPosition = new Vector3(-0.5f, 0, 0);

        var rightleg = CreateLeg();
        rightleg.transform.localPosition = new Vector3(0.5f, 0, 0);

        var body = new GameObject("body");
        var b1 = CubeClass.createCube(new Vector3(0, 2f, back), Vector3.zero, 0, new Vector3(2, 0.5f, 0.5f), "tummy", Color.white);
        var b2 = CubeClass.createCube(new Vector3(0, 2.5f, back), Vector3.zero, 0, new Vector3(2, 0.5f, 0.5f), "chest1", Color.red);
        var b3 = CubeClass.createCube(new Vector3(0, 3f, back), Vector3.zero, 0, new Vector3(2, 0.5f, 0.5f), "chest2", Color.white);
        var c = CubeClass.createCube(new Vector3(0, 3.5f, back), Vector3.zero, 0, new Vector3(3, 0.5f, 0.5f), "chest2", Color.red);

        var head = new GameObject("head");
        var h1 = CubeClass.createCube(new Vector3(0, 4f, back), Vector3.zero, 0, new Vector3(1, 0.5f, 0.5f), "neck", Color.yellow);
        var h2 = CubeClass.createCube(new Vector3(0, 4.5f, back), Vector3.zero, 0, new Vector3(2, 0.5f, 0.5f), "face", Color.yellow);
        var h3 = CubeClass.createCube(new Vector3(0, 5f, back), Vector3.zero, 0, new Vector3(1, 0.5f, 0.5f), "forehead", Color.yellow);
        var h4 = CubeClass.createCube(new Vector3(0.75f, 5f, back), Vector3.zero, 0, new Vector3(0.5f, 0.5f, 0.5f), "hair1", Color.black);
        var h5 = CubeClass.createCube(new Vector3(-0.75f, 5f, back), Vector3.zero, 0, new Vector3(0.5f, 0.5f, 0.5f), "hair2", Color.black);
        var h6 = CubeClass.createCube(new Vector3(0, 5.375f, back), Vector3.zero, 0, new Vector3(2, 0.25f, 0.5f), "head", Color.black);


        var leftarm = CubeClass.createCube(new Vector3(1.25f, 3f, 0.5f), Vector3.zero, 0, new Vector3(0.5f, 0.5f, 2.5f), "leftarm", Color.yellow);
        var rightarm = new GameObject("rightarm");
        var r = Lego.slantpiece("arm");
        r.transform.localPosition = new Vector3(-1.25f, 2.5f, back);
        r.transform.Rotate(Vector3.up, -90);
        r.transform.localScale = new Vector3(0.5f, 1, 1);

        var hand = CubeClass.createCube(new Vector3(-1.5f, 1.5f, 1.25f), Vector3.zero, 0, new Vector3(1, 0.5f, 1), "hand", Color.yellow);

        leftleg.transform.SetParent(girl.transform);
        rightleg.transform.SetParent(girl.transform);
        b1.transform.SetParent(body.transform);
        b2.transform.SetParent(body.transform);
        b3.transform.SetParent(body.transform);
        c.transform.SetParent(body.transform);

        h1.transform.SetParent(head.transform);
        h2.transform.SetParent(head.transform);
        h3.transform.SetParent(head.transform);
        h4.transform.SetParent(head.transform);
        h5.transform.SetParent(head.transform);
        h6.transform.SetParent(head.transform);

        body.transform.SetParent(girl.transform);
        head.transform.SetParent(girl.transform);
        leftarm.transform.SetParent(girl.transform);

        r.transform.SetParent(rightarm.transform);
        hand.transform.SetParent(rightarm.transform);
        rightarm.transform.SetParent(girl.transform);
        return girl;
    }

    private GameObject CreateLeg()
    {
        var leg = new GameObject("leg");

        var foot = CubeClass.createCube(Vector3.zero, Vector3.zero, 0, new Vector3(1, 0.5f, 1.5f), "foot", Color.red);
        var l = CubeClass.createCube(new Vector3(0, 0.75f, 0.25f), Vector3.zero, 0, Vector3.one, "leg", Color.green);
        var t = CubeClass.createCube(new Vector3(0, 1.5f, 1f), Vector3.zero, 0, new Vector3(1, 0.5f, 1.5f), "thigh", Color.green);

        foot.transform.SetParent(leg.transform);
        l.transform.SetParent(leg.transform);
        t.transform.SetParent(leg.transform);

        return leg;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
