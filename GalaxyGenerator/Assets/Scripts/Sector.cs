using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GalaxyGenerator
{
    public enum SectorType
    {
        Core,
        Middle,
        Edge,
        Far,
    }
    public class Sector
    {
        public  SectorType sectorType;
        public Galaxy galaxy;
        public string sectorName;
        public Vector3 sectorPosition;
        public GameObject starSystemObject;
        public int numSectorStars;
        public GameObject sectorGameObject;
        static public Sector sector;
        public Sector(SectorType SectorType, Vector3 SectorPosition, string SectorName, int NumSectorStars)
        {
            sectorName = SectorName;
            sectorType = SectorType;
            sectorPosition = SectorPosition; 
            numSectorStars = NumSectorStars;
            sectorGameObject = new GameObject(sectorName);
            GenerateSector(SectorType);
        }
        public static string BuildStarSystemName(Vector3 v, string sectorName) // assigning a name to a Sector
        {
            return (int)v.x + "_" + (int)v.y + "_" + (int)v.z + "_Sector: " + sectorName;
        }
        public void GenerateSector(SectorType sectorType)
        {
            if (sectorType == SectorType.Core)
            {
                numSectorStars = Random.Range(500, 800 + 1);
                for (int i = 0; i < numSectorStars; i++)
                {
                    Vector3 StarPosition = new Vector3(Random.Range(sectorPosition.x, Galaxy.SectorSize + sectorPosition.x + 1), Random.Range(sectorPosition.y, Galaxy.SectorSize + sectorPosition.y + 1), Random.Range(sectorPosition.z, Galaxy.SectorSize + sectorPosition.z + 1));
                    GenerateStarSystem(StarPosition, sectorName, sectorGameObject);
                }
            }
            else if (sectorType == SectorType.Middle)
            {
                numSectorStars = Random.Range(200, 500 + 1);
                for (int i = 0; i < numSectorStars; i++)
                {
                    Vector3 StarPosition = new Vector3(Random.Range(sectorPosition.x, Galaxy.SectorSize + sectorPosition.x + 1), Random.Range(sectorPosition.y, Galaxy.SectorSize + sectorPosition.y + 1), Random.Range(sectorPosition.z, Galaxy.SectorSize + sectorPosition.z + 1));
                    GenerateStarSystem(StarPosition, sectorName, sectorGameObject);
                }
            }
            else if (sectorType == SectorType.Edge)
            {
                numSectorStars = Random.Range(50, 200 + 1);
                for (int i = 0; i < numSectorStars; i++)
                {
                    Vector3 StarPosition = new Vector3(Random.Range(sectorPosition.x, Galaxy.SectorSize + sectorPosition.x + 1), Random.Range(sectorPosition.y, Galaxy.SectorSize + sectorPosition.y + 1), Random.Range(sectorPosition.z, Galaxy.SectorSize + sectorPosition.z + 1));
                    GenerateStarSystem(StarPosition, sectorName, sectorGameObject);
                }
            }
            else if (sectorType == SectorType.Far)
            {
                numSectorStars = Random.Range(10, 50 + 1);
                for (int i = 0; i < numSectorStars; i++)
                {
                    Vector3 StarPosition = new Vector3(Random.Range(sectorPosition.x, Galaxy.SectorSize + sectorPosition.x + 1), Random.Range(sectorPosition.y, Galaxy.SectorSize + sectorPosition.y + 1), Random.Range(sectorPosition.z, Galaxy.SectorSize + sectorPosition.z + 1));
                    GenerateStarSystem(StarPosition, sectorName, sectorGameObject);
                }
            }
        }
        public void GenerateStarSystem(Vector3 StarPosition, string sectorName, GameObject sectorGameObject) 
        {
            string ssn = BuildStarSystemName(StarPosition, sectorName);
            starSystemObject = new GameObject(ssn);
            starSystemObject.transform.position = StarPosition;
            new StarSystem(StarType.NONE, StarType.NONE, StarType.NONE, StarSystemType.COUNT, 0, StarPosition, ssn, sector, starSystemObject);
            CreateSphere();
            starSystemObject.transform.SetParent(sectorGameObject.transform);
        }
        public void CreateSphere()
        {
            //Find radius using simple length equation (distance between center and northPoint)

            //Find southPoint using radius.

            //Cut the line segment from northPoint to southPoint into the latitudinal number
            //These will be the number of horizontal slices (ie. equator)

            //Then divide 360 degrees by the longitudinal number to find the number of vertical slices.

            //Use trigonometry to determine the angle and then the curcumference point for each circle starting from the top.

            //Stores these points in however format you want and return the data structure. 

            MeshFilter filter = starSystemObject.AddComponent<MeshFilter>();
            MeshRenderer renderer = starSystemObject.AddComponent<MeshRenderer>();
            Mesh mesh = filter.mesh;
            Material material = renderer.material;
            mesh.Clear();

            float radius = 1f;
            // Longitude |||
            int nbLong = 24;
            // Latitude ---
            int nbLat = 16;

            #region Vertices
            Vector3[] vertices = new Vector3[(nbLong + 1) * nbLat + 2];
            float _pi = Mathf.PI;
            float _2pi = _pi * 2f;

            vertices[0] = Vector3.up * radius;
            for (int lat = 0; lat < nbLat; lat++)
            {
                float a1 = _pi * (float)(lat + 1) / (nbLat + 1);
                float sin1 = Mathf.Sin(a1);
                float cos1 = Mathf.Cos(a1);

                for (int lon = 0; lon <= nbLong; lon++)
                {
                    float a2 = _2pi * (float)(lon == nbLong ? 0 : lon) / nbLong;
                    float sin2 = Mathf.Sin(a2);
                    float cos2 = Mathf.Cos(a2);

                    vertices[lon + lat * (nbLong + 1) + 1] = new Vector3(sin1 * cos2, cos1, sin1 * sin2) * radius;
                }
            }
            vertices[vertices.Length - 1] = Vector3.up * -radius;
            #endregion

            #region Normales		
            Vector3[] normales = new Vector3[vertices.Length];
            for (int n = 0; n < vertices.Length; n++)
                normales[n] = vertices[n].normalized;
            #endregion

            #region UVs
            Vector2[] uvs = new Vector2[vertices.Length];
            uvs[0] = Vector2.up;
            uvs[uvs.Length - 1] = Vector2.zero;
            for (int lat = 0; lat < nbLat; lat++)
                for (int lon = 0; lon <= nbLong; lon++)
                    uvs[lon + lat * (nbLong + 1) + 1] = new Vector2((float)lon / nbLong, 1f - (float)(lat + 1) / (nbLat + 1));
            #endregion

            #region Triangles
            int nbFaces = vertices.Length;
            int nbTriangles = nbFaces * 2;
            int nbIndexes = nbTriangles * 3;
            int[] triangles = new int[nbIndexes];

            //Top Cap
            int i = 0;
            for (int lon = 0; lon < nbLong; lon++)
            {
                triangles[i++] = lon + 2;
                triangles[i++] = lon + 1;
                triangles[i++] = 0;
            }

            //Middle
            for (int lat = 0; lat < nbLat - 1; lat++)
            {
                for (int lon = 0; lon < nbLong; lon++)
                {
                    int current = lon + lat * (nbLong + 1) + 1;
                    int next = current + nbLong + 1;

                    triangles[i++] = current;
                    triangles[i++] = current + 1;
                    triangles[i++] = next + 1;

                    triangles[i++] = current;
                    triangles[i++] = next + 1;
                    triangles[i++] = next;
                }
            }

            //Bottom Cap
            for (int lon = 0; lon < nbLong; lon++)
            {
                triangles[i++] = vertices.Length - 1;
                triangles[i++] = vertices.Length - (lon + 2) - 1;
                triangles[i++] = vertices.Length - (lon + 1) - 1;
            }
            #endregion

            mesh.vertices = vertices;
            mesh.normals = normales;
            mesh.uv = uvs;
            mesh.triangles = triangles;

            mesh.RecalculateBounds();
            mesh.Optimize();
        }
    }
}
