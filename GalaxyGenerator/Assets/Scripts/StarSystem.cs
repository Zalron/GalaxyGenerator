using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GalaxyGenerator
{
    public enum StarSystemType 
    {
        SINGULAR_STAR_SYSTEM,
        SINGULAR_VARIABLE_STAR_SYSTEM,
        BINARY_STAR_SYSTEM,
        XRAY_BINARY_STAR_SYSTEM,
        ECLIPSING_BINARY_STAR_SYSTEM,
        TRINARY_STAR_SYSTEM,
        COUNT,
    }
    public enum StarType 
    {   
        NONE,
        PULSAR,
        NEUTRON_STAR,
        WHITE_DWARF,
        BROWN_DWARF,
        YELLOW_DWARF,
        YELLOW,
        BLUE,
        WHITE,
        BLUE_GIANT,
        RED_GIANT,
        SUPER_RED_GIANT,
        COUNT,
    }
    public class StarSystem
    {
        public int numPlanets;
        public StarType starType1;
        public StarType starType2;
        public StarType starType3;
        public StarSystemType starSystemType;
        public Vector3 starPosition;
        public string starSystemName;
        public StarSystem(StarType StarType1, StarType StarType2, StarType StarType3, StarSystemType StarSystemType, int NumPlanets, Vector3 StarPosition, string StarSystemName) 
        {
            numPlanets = NumPlanets;
            GenerateStarSystemType();
            starSystemType = StarSystemType;
            GenerateStars(StarSystemType);
            starType1 = StarType1;
            starType2 = StarType2;
            starType3 = StarType3;
            starPosition = StarPosition;
            starSystemName = StarSystemName;
        }
        void GenerateStarSystemType() 
        {
            starSystemType = (StarSystemType)Random.Range(0, (int)StarSystemType.COUNT); 
        }
        void GenerateStars(StarSystemType StarSystemType) 
        {
            if (StarSystemType == StarSystemType.SINGULAR_STAR_SYSTEM || StarSystemType == StarSystemType.SINGULAR_VARIABLE_STAR_SYSTEM) 
            {
                starType1 = (StarType)Random.Range(0, (int)StarType.COUNT);
                starType2 = StarType.NONE;
                starType3 = StarType.NONE;
                numPlanets = (int)Random.Range(0,9);
            }
            if (StarSystemType == StarSystemType.BINARY_STAR_SYSTEM || StarSystemType == StarSystemType.ECLIPSING_BINARY_STAR_SYSTEM || StarSystemType == StarSystemType.XRAY_BINARY_STAR_SYSTEM)
            {
                starType1 = (StarType)Random.Range(0, (int)StarType.COUNT);
                starType2 = (StarType)Random.Range(0, (int)StarType.COUNT);
                starType3 = StarType.NONE;
                numPlanets = (int)Random.Range(0, 9);
            }
            if (StarSystemType == StarSystemType.TRINARY_STAR_SYSTEM)
            {
                starType1 = (StarType)Random.Range(0, (int)StarType.COUNT);
                starType2 = (StarType)Random.Range(0, (int)StarType.COUNT);
                starType3 = (StarType)Random.Range(0, (int)StarType.COUNT);
                numPlanets = (int)Random.Range(0, 9);
            }
        }
    }
}
