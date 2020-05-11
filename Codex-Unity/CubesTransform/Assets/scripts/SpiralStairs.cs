using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralStairs : MonoBehaviour
{
    GameObject[] staircase = new GameObject[50];
    Vector3 size = new Vector3(.5f, 0.1f, 1f);
    float stairangle = 45f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 51; i++)
        {
            //deafult floor 
            Vector3 loc = new Vector3(size.z/2, size.y * i- size.y / 2, size.z/2);
            Vector3 dir = Vector3.up;
            staircase[i] = CubeClass.createCube(Vector3.zero, dir, 25f*i, size, "stair" + i, Color.grey);
            if (i != 0)
                staircase[i].transform.Translate(loc, staircase[i - 1].transform);
            else
            {
                staircase[i].gameObject.SetActive (false);
            }
        }
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
