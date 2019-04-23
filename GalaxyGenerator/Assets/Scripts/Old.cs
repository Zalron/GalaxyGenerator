using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Old
{
    //public void CreateSphere()
    //{
    //Find radius using simple length equation (distance between center and northPoint)

    //Find southPoint using radius.

    //Cut the line segment from northPoint to southPoint into the latitudinal number
    //These will be the number of horizontal slices (ie. equator)

    //Then divide 360 degrees by the longitudinal number to find the number of vertical slices.

    //Use trigonometry to determine the angle and then the curcumference point for each circle starting from the top.

    //Stores these points in however format you want and return the data structure. 

    //    MeshFilter filter = starSystemObject.AddComponent<MeshFilter>();
    //    MeshRenderer renderer = starSystemObject.AddComponent<MeshRenderer>();
    //    Mesh mesh = filter.mesh;
    //    Material material = renderer.material;
    //    mesh.Clear();

    //    float radius = 1f;
    //    // Longitude |||
    //    int nbLong = 24;
    //    // Latitude ---
    //    int nbLat = 16;

    //    #region Vertices
    //    Vector3[] vertices = new Vector3[(nbLong + 1) * nbLat + 2];
    //    float _pi = Mathf.PI;
    //    float _2pi = _pi * 2f;

    //    vertices[0] = Vector3.up * radius;
    //    for (int lat = 0; lat < nbLat; lat++)
    //    {
    //        float a1 = _pi * (float)(lat + 1) / (nbLat + 1);
    //        float sin1 = Mathf.Sin(a1);
    //        float cos1 = Mathf.Cos(a1);

    //        for (int lon = 0; lon <= nbLong; lon++)
    //        {
    //            float a2 = _2pi * (float)(lon == nbLong ? 0 : lon) / nbLong;
    //            float sin2 = Mathf.Sin(a2);
    //            float cos2 = Mathf.Cos(a2);

    //            vertices[lon + lat * (nbLong + 1) + 1] = new Vector3(sin1 * cos2, cos1, sin1 * sin2) * radius;
    //        }
    //    }
    //    vertices[vertices.Length - 1] = Vector3.up * -radius;
    //    #endregion

    //    #region Normales		
    //    Vector3[] normales = new Vector3[vertices.Length];
    //    for (int n = 0; n < vertices.Length; n++)
    //        normales[n] = vertices[n].normalized;
    //    #endregion

    //    #region UVs
    //    Vector2[] uvs = new Vector2[vertices.Length];
    //    uvs[0] = Vector2.up;
    //    uvs[uvs.Length - 1] = Vector2.zero;
    //    for (int lat = 0; lat < nbLat; lat++)
    //        for (int lon = 0; lon <= nbLong; lon++)
    //            uvs[lon + lat * (nbLong + 1) + 1] = new Vector2((float)lon / nbLong, 1f - (float)(lat + 1) / (nbLat + 1));
    //    #endregion

    //    #region Triangles
    //    int nbFaces = vertices.Length;
    //    int nbTriangles = nbFaces * 2;
    //    int nbIndexes = nbTriangles * 3;
    //    int[] triangles = new int[nbIndexes];

    //    //Top Cap
    //    int i = 0;
    //    for (int lon = 0; lon < nbLong; lon++)
    //    {
    //        triangles[i++] = lon + 2;
    //        triangles[i++] = lon + 1;
    //        triangles[i++] = 0;
    //    }

    //    //Middle
    //    for (int lat = 0; lat < nbLat - 1; lat++)
    //    {
    //        for (int lon = 0; lon < nbLong; lon++)
    //        {
    //            int current = lon + lat * (nbLong + 1) + 1;
    //            int next = current + nbLong + 1;

    //            triangles[i++] = current;
    //            triangles[i++] = current + 1;
    //            triangles[i++] = next + 1;

    //            triangles[i++] = current;
    //            triangles[i++] = next + 1;
    //            triangles[i++] = next;
    //        }
    //    }

    //    //Bottom Cap
    //    for (int lon = 0; lon < nbLong; lon++)
    //    {
    //        triangles[i++] = vertices.Length - 1;
    //        triangles[i++] = vertices.Length - (lon + 2) - 1;
    //        triangles[i++] = vertices.Length - (lon + 1) - 1;
    //    }
    //    #endregion

    //    mesh.vertices = vertices;
    //    mesh.normals = normales;
    //    mesh.uv = uvs;
    //    mesh.triangles = triangles;

    //    mesh.RecalculateBounds();
    //    mesh.Optimize();
    //}

    //static MeshFilter meshFilters;

    //static Mesh mesh;
    //[Range(2, 256)]
    //static int systemResolution;
    //static Vector3 localUp;
    //static Vector3 axisA;
    //static Vector3 axisB;
    //public static void CreateSphere(GameObject starSystemObject)
    //{
    //    axisA = new Vector3(localUp.y, localUp.z, localUp.x);
    //    axisB = Vector3.Cross(localUp, axisA);
    //    meshFilters = new MeshFilter();
    //    Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

    //    for (int i = 0; i < 6; i++)
    //    {
    //        if (meshFilters == null)
    //        {
    //            GameObject meshobj = new GameObject("mesh");
    //            meshobj.transform.parent = starSystemObject.transform;
    //            meshobj.transform.position = starSystemObject.transform.position;
    //            meshobj.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));

    //            meshFilters = meshobj.AddComponent<MeshFilter>();
    //            meshFilters.sharedMesh = new Mesh();
    //            ConstructMesh();
    //        }
    //    }
    //}
    //public static void ConstructMesh()
    //{
    //    Vector3[] vertices = new Vector3[systemResolution * systemResolution];
    //    int[] triangles = new int[(systemResolution - 1) * (systemResolution - 1) * 6];
    //    int triIndex = 0;
    //    for (int y = 0; y < systemResolution; y++)
    //    {
    //        for (int x = 0; x < systemResolution; x++)
    //        {
    //            int i = x + y * systemResolution;
    //            Vector2 percent = new Vector2(x, y) / (systemResolution - 1);
    //            Vector3 pointOnUnitCube = localUp + (percent.x - 0.5f) * 2 * axisA + (percent.y - 0.5f) * 2 * axisB;
    //            Vector3 pointOnUnitSphere = pointOnUnitCube.normalized;
    //            vertices[i] = pointOnUnitSphere;
    //            if (x != systemResolution - 1 && y != systemResolution - 1)
    //            {
    //                triangles[triIndex] = i;
    //                triangles[triIndex + 1] = i + systemResolution + 1;
    //                triangles[triIndex + 2] = i + systemResolution;

    //                triangles[triIndex + 3] = i;
    //                triangles[triIndex + 4] = i + 1;
    //                triangles[triIndex + 5] = i + systemResolution + 1;
    //                triIndex += 6;
    //            }
    //        }
    //    }
    //    mesh.Clear();
    //    mesh.vertices = vertices;
    //    mesh.triangles = triangles;
    //    mesh.RecalculateNormals();
        //CombineSphereInstances();
    //}
    //public void CombineSphereInstances()
    //{
    //    mesh.CombineMeshes(mesh);
    //}
}
