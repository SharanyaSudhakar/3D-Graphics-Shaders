using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornellCube : MonoBehaviour
{
    string[] names = { "boxFloor", "boxCeiling", "boxleft", "boxright", "boxback" };
    GameObject[] box = new GameObject[5];
    float boxLength = 5.4f;
    float boxWidth = 0.2f;
    float boxAngle = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 sc = new Vector3(boxLength, boxWidth, boxLength);
        for (int i=0; i< box.Length; i++)
        {
            //default floor 
            Vector3 loc = new Vector3(0, boxWidth/2, 0);
            Vector3 dir = Vector3.up;
            boxAngle = 0f;

            //ceiling
            if(i==1)
            {
                loc = new Vector3(0, boxLength-boxWidth/2, 0);
            }

            //left wall
            else if (i == 2)
            {
                loc = new Vector3(boxLength/2, boxLength/2, 0);
                dir = Vector3.forward;
                boxAngle = 90f;
            }

            //right wall
            else if (i == 3)
            {
                loc = new Vector3(-1*boxLength/2, boxLength/2, 0);
                dir = Vector3.forward;
                boxAngle = -90f;
            }

            //backwall
            else if (i == 4)
            {
                loc = new Vector3(0, boxLength/2, boxLength/2 - boxWidth / 2);
                dir = Vector3.left;
                boxAngle = 90f;
            }
                       
            box[i] = CubeClass.createCube(loc, dir, boxAngle,sc, names[i], Color.grey);
            box[i].transform.SetParent(this.transform);
        }

        GameObject lightObj = new GameObject("Lightobj");
        Light lightup = lightObj.AddComponent<Light>();
        lightObj.transform.position = new Vector3(0, boxLength - 1f, 0);
        lightup.range = 45;
        lightObj.transform.SetParent(box[1].transform);

        Vector3 pos = new Vector3(-1f, boxWidth / 2 + 1.5f, 1f);
        sc = new Vector3(1.5f, 3, 1.5f);
        GameObject rect = CubeClass.createCube(pos, Vector3.up, 35f, sc, "Rectangle", Color.yellow);

        pos = new Vector3(1f,( boxWidth +1.5f)/ 2 , -1f);
        sc = new Vector3(1.5f, 1.5f, 1.5f);
        GameObject cube = CubeClass.createCube(pos, Vector3.up, 15f, sc, "Cube01", Color.red);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
