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
    public class Sector : MonoBehaviour
    {
        public SectorType sectorType;
        public Vector3 SectorPosition;
        public GameObject StarSystemsObject;
        public int SectorStars;
        int SectorWidth = 100;
        void Start()
        {
            SectorPosition = this.transform.position;
            GenerateSector(sectorType);
        }
        public void GenerateSector(SectorType sectorType)
        {
            Vector3 StarPosition = new Vector3(Random.Range(0, SectorWidth + 1), Random.Range(0, SectorWidth + 1), Random.Range(0, SectorWidth + 1));
            if (sectorType == SectorType.Core)
            {
                SectorStars = Random.Range(500, 800 + 1);
                for (int i = 0; i < SectorStars; i++)
                {
                    Instantiate(StarSystemsObject, StarPosition, Quaternion.identity);
                }
            }
            else if (sectorType == SectorType.Middle)
            {
                SectorStars = Random.Range(200, 500 + 1);
                for (int i = 0; i < SectorStars; i++)
                {
                    Instantiate(StarSystemsObject, StarPosition, Quaternion.identity);
                }
            }
            else if (sectorType == SectorType.Edge)
            {
                SectorStars = Random.Range(50, 200 + 1);
                for (int i = 0; i < SectorStars; i++)
                {
                    Instantiate(StarSystemsObject, StarPosition, Quaternion.identity);
                }
            }
            else if (sectorType == SectorType.Far)
            {
                SectorStars = Random.Range(10, 50 + 1);
                for (int i = 0; i < SectorStars; i++)
                {
                    Instantiate(StarSystemsObject, StarPosition, Quaternion.identity);
                }
            }
        }
    }
}
