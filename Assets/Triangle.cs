using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plan : MonoBehaviour
{
    public int nbLignes ;
    public int nbColonnes ;
    // Start is called before the first frame update
    private void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        Vector3[] vertices = new Vector3[(nbLignes + 1) * (nbColonnes + 1)];
        int[] triangles = new int[nbLignes * nbColonnes * 6];

        int index = 0;
        for (int i = 0; i <= nbLignes; i++)
        {
            for (int j = 0; j <= nbColonnes; j++)
            {
                vertices[i * (nbColonnes + 1) + j] = new Vector3(j, 0, i);
            }
        }

        for (int i = 0; i < nbLignes; i++)
        {
            for (int j = 0; j < nbColonnes; j++)
            {
                triangles[index] = i * (nbColonnes + 1) + j;
                triangles[index + 1] = (i + 1) * (nbColonnes + 1) + j;
                triangles[index + 2] = (i + 1) * (nbColonnes + 1) + j + 1;
                triangles[index + 3] = i * (nbColonnes + 1) + j;
                triangles[index + 4] = (i + 1) * (nbColonnes + 1) + j + 1;
                triangles[index + 5] = i * (nbColonnes + 1) + j + 1;
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