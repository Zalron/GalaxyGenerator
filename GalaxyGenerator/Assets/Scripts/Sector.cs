using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SectorType 
{
    Core,
    Middle,
    Edge,
    Far, 
}
public class Sector : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public int SectorPosition;
    public int[] SectorStars;
    public Vector3 StarPosition;
    public void Generate() 
    {
                // Fist pass, just make some random stars for us

                int galaxyWidth = GalaxyConfig.GalaxyWidth;
                for (int i = 0; i < GalaxyConfig.NumStars; i++)
                {
                    StarSystem ss = new StarSystem();
                    ss.Position = new Vector3
                        (
                        Random.Range(-galaxyWidth / 2, galaxyWidth / 2),
                        Random.Range(-galaxyWidth / 2, galaxyWidth / 2),
                        Random.Range(-galaxyWidth / 2, galaxyWidth / 2)
                        );
                    ss.Generate(/* Do we pass exactly what time of start system we want?*/);
                    StarSystems.Add(ss);
                }
                Debug.Log("Num Stars Generated:" + StarSystems.Count);
            }
    public void GenerateSector()
    {
        int SectorWidth = 100;
        for (int i = 0; i < SectorWidth; i++) 
        {

            Random.Range(-galaxyWidth / 2, galaxyWidth / 2),
            Random.Range(-galaxyWidth / 2, galaxyWidth / 2),
            Random.Range(-galaxyWidth / 2, galaxyWidth / 2)
        }

    }
}
