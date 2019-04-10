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

        public int SectorPosition;
        public GameObject StarSystemsObject;
        public Vector3 StarPosition;
        int SectorWidth = 100;
        void Start()
        {
            GenerateSector();
        }
        public void GenerateSector()
        {
            int SectorStars = Random.Range(200, 400 + 1);
            for (int i = 0; i < SectorStars; i++)
            {
                StarPosition = new Vector3(Random.Range(0, SectorWidth + 1), Random.Range(0, SectorWidth + 1), Random.Range(0, SectorWidth + 1));
                Instantiate(StarSystemsObject, StarPosition,
                Quaternion.identity);
            }
        }
    }
}
