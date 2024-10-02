using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylindre : MonoBehaviour
{
    public int nbMeridiens;
    public float rayon;
    public float hauteur;
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        Vector3[] vertices = new Vector3[nbMeridiens * 2 + 2];
        int[] triangles = new int[nbMeridiens * 6];

        for (int i = 0; i < nbMeridiens; i++)
        {
            float angle = i * Mathf.PI * 2 / nbMeridiens;
            vertices[i * 2] = new Vector3(Mathf.Cos(angle) * rayon, 0, Mathf.Sin(angle) * rayon);
            vertices[i * 2 + 1] = new Vector3(Mathf.Cos(angle) * rayon, hauteur, Mathf.Sin(angle) * rayon);
        }

        vertices[nbMeridiens * 2] = new Vector3(0, 0, 0);
        vertices[nbMeridiens * 2 + 1] = new Vector3(0, hauteur, 0);

        for (int i = 0; i < nbMeridiens; i++)
        {
            triangles[i * 6] = i * 2;
            triangles[i * 6 + 1] = (i + 1) % nbMeridiens * 2;
            triangles[i * 6 + 2] = (i + 1) % nbMeridiens * 2 + 1;
            triangles[i * 6 + 3] = i * 2;
            triangles[i * 6 + 4] = (i + 1) % nbMeridiens * 2 + 1;
            triangles[i * 6 + 5] = i * 2 + 1;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}




   

   