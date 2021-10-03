using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{

    public TextAsset jsonDataFile;
    public GameObject celestialBodyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(jsonDataFile.text);
        StarSystemData starSystemData = JsonUtility.FromJson<StarSystemData>(jsonDataFile.text);
        foreach (var planet in starSystemData.planets)
        {
            var newBody = Instantiate(celestialBodyPrefab);
            newBody.transform.parent = transform;
            var ctrl = newBody.GetComponent<CelestialBodyController>();
            ctrl.CreatePlanet(planet);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Reset()
    {
        Debug.Log("hi");
    }
}


/*
 * Unity units
 * 1 um = 1e-9 m = 1e-6 km
 * 1 ug = 1e24 kg
 */

[System.Serializable]
public struct CelestialBodyData
{
    public string name;
    public float mass; // 10^24 kg
    public float diameter; // km
    public float density; // kg/m^3
    public float gravity; // m/s^2
    public float escapeVelocity; // km/s
    public float rotationPeriod; // hours
    public float lengthOfDay; // hours
    public float distanceFromSun; // 10^6 km
    public float perihelion; // 10^6 km
    public float aphelion; // 10^6 km
    public float orbitalPeriod; // days
    public float orbitalVelocity; // km/s
    public float orbitalInclination; // degrees
    public float orbitalEccentricity;
    public float obliquityToOrbit; // degrees
    public float meanTemperature; // C
    public float surfacePressure; // bars
    public int numberOfMoons;
    public bool ringSystem;
    public bool globalMagneticField;
    public float orbitalVelocityNorm { get => orbitalVelocity / 1000000; }
}

[System.Serializable]
public struct StarSystemData
{
    public CelestialBodyData[] stars;
    public CelestialBodyData[] planets;
    public CelestialBodyData[] moons;
}
