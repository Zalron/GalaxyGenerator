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
        public SectorType sectorType;
        public Sector sectorMB;
        public Galaxy galaxy;
        public string sectorName;
        public Vector3 sectorPosition;
        public GameObject starSystemsObject;
        public int sectorStars;
        public Sector(SectorType SectorType, Vector3 SectorPosition, GameObject StarSystemsObject, string SectorName, Galaxy Galaxy)
        {
            sectorName = SectorName;
            sectorType = SectorType;
            sectorPosition = SectorPosition; 
            starSystemsObject = StarSystemsObject;
            galaxy = Galaxy;
            starSystemsObject = new GameObject(Galaxy.BuildSectorName(sectorPosition));
            //starSystemsObject.transform.position = sectorPosition;
            GenerateSector(SectorType);
        }
        public void GenerateSector(SectorType sectorType)
        {
            if (sectorType == SectorType.Core)
            {
                sectorStars = Random.Range(500, 800 + 1);
                for (int i = 0; i < sectorStars; i++)
                {
                    Vector3 StarPosition = new Vector3(Random.Range(sectorPosition.x, Galaxy.SectorSize + sectorPosition.x + 1), Random.Range(sectorPosition.y, Galaxy.SectorSize + sectorPosition.y + 1), Random.Range(sectorPosition.z, Galaxy.SectorSize + sectorPosition.z + 1));
                    galaxy.GenerateSectorStars(StarPosition, starSystemsObject);
                }
            }
            else if (sectorType == SectorType.Middle)
            {
                sectorStars = Random.Range(200, 500 + 1);
                for (int i = 0; i < sectorStars; i++)
                {
                    Vector3 StarPosition = new Vector3(Random.Range(sectorPosition.x, Galaxy.SectorSize + sectorPosition.x + 1), Random.Range(sectorPosition.y, Galaxy.SectorSize + sectorPosition.y + 1), Random.Range(sectorPosition.z, Galaxy.SectorSize + sectorPosition.z + 1));
                    galaxy.GenerateSectorStars(StarPosition, starSystemsObject);
                }
            }
            else if (sectorType == SectorType.Edge)
            {
                sectorStars = Random.Range(50, 200 + 1);
                for (int i = 0; i < sectorStars; i++)
                {
                    Vector3 StarPosition = new Vector3(Random.Range(sectorPosition.x, Galaxy.SectorSize + sectorPosition.x + 1), Random.Range(sectorPosition.y, Galaxy.SectorSize + sectorPosition.y + 1), Random.Range(sectorPosition.z, Galaxy.SectorSize + sectorPosition.z + 1));
                    galaxy.GenerateSectorStars(StarPosition, starSystemsObject);
                }
            }
            else if (sectorType == SectorType.Far)
            {
                sectorStars = Random.Range(10, 50 + 1);
                for (int i = 0; i < sectorStars; i++)
                {
                    Vector3 StarPosition = new Vector3(Random.Range(sectorPosition.x, Galaxy.SectorSize + sectorPosition.x + 1), Random.Range(sectorPosition.y, Galaxy.SectorSize + sectorPosition.y + 1), Random.Range(sectorPosition.z, Galaxy.SectorSize + sectorPosition.z + 1));
                    galaxy.GenerateSectorStars(StarPosition, starSystemsObject);
                }
            }
        }
    }
}
