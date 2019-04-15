using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using UnityEngine;
namespace GalaxyGenerator
{
    public class Galaxy : MonoBehaviour
    {
        
        //public Sector sector;
        public GameObject player;
        public GameObject starSystemsObject;
        public static int SectorSize = 100;
        public static ConcurrentDictionary<string, Sector> sectors;
        public static List<string> toRemove = new List<string>(); // a list to remove the chunks that are not needed from the dictionary
        public static int galaxyHeight = 120; // the height of the world
        public static int galaxyLength = 1000; // the height of the world
        public static int galaxyWidth = 1000; // the height of the world
        // Start is called before the first frame update
        void Start()
        {
            GenerateGalaxy((int)(player.transform.position.x / SectorSize), (int)(player.transform.position.y / SectorSize), (int)(player.transform.position.z / SectorSize), 2, 2);
        }
        public static string BuildSectorName(Vector3 v) // assigning a name to a chunk
        {
            return (int)v.x + "_" + (int)v.y + "_" + (int)v.z;
        }
        void GenerateSectorAt(int x, int y, int z)// builds chunks
        {
            Vector3 SectorPosition = new Vector3(x * SectorSize, y * SectorSize, z * SectorSize);
            string sn = BuildSectorName(SectorPosition);
            Sector _s;
            if (!sectors.TryGetValue(sn, out _s))
            {
                _s = new Sector(SectorType.Core, SectorPosition, starSystemsObject, sn, this);
                _s.starSystemsObject.transform.parent = this.transform;
                sectors.TryAdd(_s.starSystemsObject.name, _s);
            }
        }
        void GenerateGalaxy(int x, int y, int z, int startradius, int radius)// builds Sectors around the player
        {
            //builds chunk forward
            GenerateSectorAt(x, y, z + 1);

            //builds chunk back
            GenerateSectorAt(x, y, z - 1);

            //builds chunk left
            GenerateSectorAt(x - 1, y, z);

            //builds chunk right
            GenerateSectorAt(x + 1, y, z - 1);

            //builds chunk up
            GenerateSectorAt(x, y + 1, z);

            //builds chunk down
            GenerateSectorAt(x, y - 1, z - 1);

        }
        public void GenerateSectorStars(Vector3 StarPosition)
        {
            Instantiate(starSystemsObject, StarPosition, Quaternion.identity);

        }
    }
}
