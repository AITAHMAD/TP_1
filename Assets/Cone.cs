using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : MonoBehaviour
{
    public float radiusBottom = 1f; 
    public float radiusTop = 0f;    
    public float height = 2f;      
    public int radialSegments = 36;

    private void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        int vertexCount = (radialSegments + 1) * 2 + 2; // Sommets

        Vector3[] vertices = new Vector3[vertexCount];
        Vector3[] normals = new Vector3[vertexCount];
        Vector2[] uv = new Vector2[vertexCount];
        int[] triangles = new int[radialSegments * 6];

        float angleStep = 2 * Mathf.PI / radialSegments;

        int vertexIndex = 0;
        int triIndex = 0;

        // Générer les sommets pour les bords supérieur et inférieur
        for (int i = 0; i <= radialSegments; i++)
        {
            float angle = i * angleStep;
            float xBottom = Mathf.Cos(angle) * radiusBottom;
            float zBottom = Mathf.Sin(angle) * radiusBottom;

            float xTop = Mathf.Cos(angle) * radiusTop;
            float zTop = Mathf.Sin(angle) * radiusTop;

            vertices[vertexIndex] = new Vector3(xBottom, 0, zBottom);    // Sommet bas
            vertices[vertexIndex + 1] = new Vector3(xTop, height, zTop); // Sommet haut

            normals[vertexIndex] = new Vector3(xBottom, 0, zBottom).normalized;
            normals[vertexIndex + 1] = new Vector3(xTop, height, zTop).normalized;

            uv[vertexIndex] = new Vector2((float)i / radialSegments, 0);
            uv[vertexIndex + 1] = new Vector2((float)i / radialSegments, 1);

            if (i < radialSegments)
            {
                // Créer les faces du cône
                triangles[triIndex] = vertexIndex;
                triangles[triIndex + 1] = vertexIndex + 1;
                triangles[triIndex + 2] = vertexIndex + 2;

                triangles[triIndex + 3] = vertexIndex + 1;
                triangles[triIndex + 4] = vertexIndex + 3;
                triangles[triIndex + 5] = vertexIndex + 2;

                triIndex += 6;
            }

            vertexIndex += 2;
        }

        // Ajouter un sommet pour les centres
        vertices[vertexIndex] = new Vector3(0, 0, 0); // Centre du bas
        vertices[vertexIndex + 1] = new Vector3(0, height, 0); // Centre du haut

        normals[vertexIndex] = Vector3.down;
        normals[vertexIndex + 1] = Vector3.up;

        uv[vertexIndex] = new Vector2(0.5f, 0.5f);
        uv[vertexIndex + 1] = new Vector2(0.5f, 0.5f);

        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.uv = uv;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }
}