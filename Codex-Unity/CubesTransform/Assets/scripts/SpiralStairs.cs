using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralStairs : MonoBehaviour
{
    [SerializeField] int stairCount;
    List<GameObject> staircase = new List<GameObject>();
    [SerializeField] Material mat;
    Vector3 size = new Vector3(.5f, 0.1f, 1f);
    float stairangle = 45f;
    // Start is called before the first frame update
    void Start()
    {
        //deafult floor 
        Vector3 loc;
        Vector3 pos = Vector3.zero;
        Vector3 dir = Vector3.up;
        float angle;
        string name;
        Color color = Color.black;
        for (int i = 0; i < stairCount; i++)
        {
            loc = new Vector3(0.4f, size.y * i - size.y / 2, 1.4f);
            angle = 25f + 10 * i;
            name = "stair" + i;
            GameObject cube = CubeClass.createCube(pos, dir, angle, size, name, color);
            if (i != 0)
                cube.transform.Translate(loc, staircase[i - 1].transform);
            else
            {
                cube.gameObject.SetActive (false);
            }
            cube.transform.SetParent(this.transform);
            cube.GetComponent<Renderer>().material = mat;
            staircase.Add(cube);
        }
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
