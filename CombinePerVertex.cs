using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MeshFilter))]
public class CombinePerVertex : MonoBehaviour
{
    public static List<Transform> transforms;
    List<Vector3> vert;
    List<Vector3> norm;
    List<int> triag;
    List<Vector2> uv;
    List<Vector2> uv2;
    Texture2D[] ordinaryTextures;

    private void InitializeList()
    {
        vert = new List<Vector3>();
        norm = new List<Vector3>();
        triag = new List<int>();
        uv = new List<Vector2>();
        uv2 = new List<Vector2>();
    }

    public void CombineMeshes()
    {
        InitializeList();
        Transform[] t = GetComponentsInChildren<Transform>();
        transforms = new List<Transform>();
        for (int i = 1; i < t.Length; i++)//only the child transforms are added to the list.
            transforms.Add(t[i]);
        Debug.LogFormat("Number of objects:{0}", transforms.Count);
        ordinaryTextures = new Texture2D[transforms.Count];
        for (int i = 0; i < transforms.Count; i++)
        {

            Mesh newMesh = new Mesh();
            newMesh = transforms[i].GetComponent<MeshFilter>().mesh;

            int triagOffset = vert.Count;

            for (int j = 0; j < newMesh.vertices.Length; j++)
            {
                vert.Add(transforms[i].TransformPoint(newMesh.vertices[j]));
                norm.Add(newMesh.normals[j]);
                uv.Add(newMesh.uv[j]);
                uv2.Add(new Vector2(i, 0));
            }

            for (int j = 0; j < newMesh.triangles.Length; j++)
                triag.Add(triagOffset + newMesh.triangles[j]);
            ordinaryTextures[i] = transforms[i].GetComponent<Renderer>().material.GetTexture("_MainTex") as Texture2D;
            transforms[i].gameObject.SetActive(false);
        }

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();

        mesh.vertices = vert.ToArray();
        mesh.normals = norm.ToArray();
        mesh.triangles = triag.ToArray();
        mesh.uv = uv.ToArray();
        mesh.uv2 = uv2.ToArray();
        CreateTextureArray(mesh);
    }
    
    //create a texture array to be used in conjunction with a customshader TextureArrayShader
    private void CreateTextureArray(Mesh mesh)
    {

        Texture2DArray texture2DArray = new Texture2DArray(ordinaryTextures[0].width,
                                                ordinaryTextures[0].height, ordinaryTextures.Length,
                                                TextureFormat.RGBA32, true, false);

        for (int i = 0; i < ordinaryTextures.Length; i++)
        {
            texture2DArray.SetPixels(ordinaryTextures[i].GetPixels(0), i, 0);
        }
        texture2DArray.Apply();
        GetComponent<Renderer>().material.SetTexture("_MainTex", texture2DArray);
        //add collider component if needed
        this.gameObject.AddComponent<MeshCollider>();
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }
}
