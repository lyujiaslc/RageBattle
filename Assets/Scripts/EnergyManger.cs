using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManger : MonoBehaviour {
    public static EnergyManger Instance { get; private set; }

    private const float RANDOMRANGE = 12.0f;
    public enum EnergyType
    {
        HAPPY = -1,
        ANGRY = 3
    }

    [SerializeField] Energy EmergyPrefab;

    private Dictionary<GameObject, Energy> m_energies = new Dictionary<GameObject, Energy>();
    private Queue<Energy> m_collectedEnergies = new Queue<Energy>();

    private List<Vector3> m_energyPlaceCentersposes = new List<Vector3>();


	// Use this for initialization
	void Start () {
        Instance = this;
        GetEnergyPlaceCenters();
        PlaceEnergys();

        StartCoroutine(AutoGenerateEnergy());
    }

    private void GetEnergyPlaceCenters()
    {
        GameObject[] energyPlaceCenters = GameObject.FindGameObjectsWithTag("EnergyPos");
        for (int i = 0; i < energyPlaceCenters.Length; ++i)
        {
            m_energyPlaceCentersposes.Add(energyPlaceCenters[i].transform.position);
            Destroy(energyPlaceCenters[i]);
        }
    }

    private void PlaceEnergys()
    {
        foreach(var pos in m_energyPlaceCentersposes)
        {
            int amount = Random.Range(2, 5);

            for (int i = 0; i < amount; ++i)
            {
                PlaceEnergyAroundPosition(pos);
            }
        }
    }

    private void PlaceEnergyAroundPosition(Vector3 pos)
    {
        float maxX = pos.x + Random.Range(0.0f, RANDOMRANGE);
        float minX = pos.x - Random.Range(0.0f, RANDOMRANGE);
        float maxZ = pos.z + Random.Range(0.0f, RANDOMRANGE);
        float minZ = pos.z - Random.Range(0.0f, RANDOMRANGE);
        PlaceEnergyAtPosition(new Vector3(Random.Range(maxX, minX), pos.y, Random.Range(maxZ, minZ)));
    }
	

    public int CollectEnergyAmount(Collider c)
    {
        if(m_energies.ContainsKey(c.gameObject))
        {
            Energy e = m_energies[c.gameObject];
            m_energies.Remove(e.gameObject);
            m_collectedEnergies.Enqueue(e);
            e.gameObject.SetActive(false);
            return (int)e.EnergyType;
        }
        return 0;
    }

    private void PlaceEnergyAtPosition(Vector3 pos)
    {
        Energy e = null;
        if(m_collectedEnergies.Count > 0)
            e = m_collectedEnergies.Dequeue();
        else
            e = Instantiate(EmergyPrefab.gameObject, Vector3.zero, Quaternion.identity, gameObject.transform).GetComponent<Energy>();

        e.transform.position = pos;
        e.Init(Random.Range(0, 2)==0? EnergyType.ANGRY: EnergyType.HAPPY);
        e.gameObject.SetActive(true);
        m_energies.Add(e.gameObject, e);
    }


    IEnumerator AutoGenerateEnergy()
    {
        while(true)
        {
            yield return new WaitForSeconds( 1 + (m_energies.Count / 10));
            if(m_energies.Count <= 30)
                PlaceEnergyAroundPosition(m_energyPlaceCentersposes[Random.Range(0, m_energyPlaceCentersposes.Count)]);
        }
    }

}


