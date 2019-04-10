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
        public int SectorStars;
        public GameObject StarsSystem;
        public Vector3 StarPosition;
        int SectorWidth = 100;
        int NumStars = 50;
        public Sector()
        {
            SectorStars = Random.Range(1, 400);
        }
        //public void Generate() 
        //{
        //    // Fist pass, just make some random stars for us

        //    int galaxyWidth = GalaxyConfig.GalaxyWidth;
        //    for (int i = 0; i < GalaxyConfig.NumStars; i++)
        //    {
        //        StarSystem ss = new StarSystem();
        //        ss.Position = new Vector3
        //            (
        //            Random.Range(-galaxyWidth / 2, galaxyWidth / 2),
        //            Random.Range(-galaxyWidth / 2, galaxyWidth / 2),
        //            Random.Range(-galaxyWidth / 2, galaxyWidth / 2)
        //            );
        //        ss.Generate(/* Do we pass exactly what time of start system we want?*/);
        //        StarSystems.Add(ss);
        //    }
        //    Debug.Log("Num Stars Generated:" + StarSystems.Count);
        //}
        public void GenerateSector()
        {
            for (int i = 0; i < NumStars; i++)
            {
                Instantiate(StarSystem, new Vector3(
                Random.Range(0, SectorWidth),
                Random.Range(0, SectorWidth),
                Random.Range(0, SectorWidth)), 
                Quaternion.Identity);
            }
        }
    }
}
