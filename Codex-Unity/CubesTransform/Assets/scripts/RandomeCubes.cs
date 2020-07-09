using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomeCubes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 minsize = new Vector3(.5f, .5f, .5f);
        Vector3 incremntSize = new Vector3(.25f, .25f, .25f);
        Vector3 loc = Vector3.zero;
        Vector3 dir = Vector3.forward;
        float angle = 45f;
        string name;
        Color color = Color.magenta;
        for (int i = -2, j=0; i < 3; i++, j++)
        {
            Vector3 _size = minsize + (j * incremntSize);

            //equaltion of an ellipse using sin and cosine
            loc.y = 4f * Mathf.Sin((15f + _size.y) *i* Mathf.PI / 180);
            loc.x = 2f * Mathf.Cos((15f + _size.y) * i* Mathf.PI / 180);
            angle = 30f*i;
            name = "cube"+ i;
            GameObject cube = CubeClass.createCube(loc, dir, angle, _size, name, color);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
