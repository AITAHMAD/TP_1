using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphère : MonoBehaviour
{
    public int nbParalleles;
    public int nbMeridiens;
    public float rayon;
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        Vector3[] vertices = new Vector3[(nbParalleles + 1) * (nbMeridiens + 1)];
        int[] triangles = new int[nbParalleles * nbMeridiens * 6];

        int index = 0;
        for (int i = 0; i <= nbParalleles; i++)
        {
            float angleY = i * Mathf.PI / nbParalleles;
            for (int j = 0; j <= nbMeridiens; j++)
            {
                float angleX = j * Mathf.PI * 2 / nbMeridiens;
                vertices[i * (nbMeridiens + 1) + j] = new Vector3(Mathf.Cos(angleX) * Mathf.Sin(angleY) * rayon, Mathf.Cos(angleY) * rayon, Mathf.Sin(angleX) * Mathf.Sin(angleY) * rayon);
            }
        }

        for (int i = 0; i < nbParalleles; i++)
        {
            for (int j = 0; j < nbMeridiens; j++)
            {
                triangles[index] = i * (nbMeridiens + 1) + j;
                triangles[index + 1] = (i + 1) * (nbMeridiens + 1) + j;
                triangles[index + 2] = (i + 1) * (nbMeridiens + 1) + j + 1;
                triangles[index + 3] = i * (nbMeridiens + 1) + j;
                triangles[index + 4] = (i + 1) * (nbMeridiens + 1) + j + 1;
                triangles[index + 5] = i * (nbMeridiens + 1) + j + 1;
                index += 6;
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



