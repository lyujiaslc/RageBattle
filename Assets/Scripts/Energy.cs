using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour {
    private EnergyManger.EnergyType m_energyType;
    public EnergyManger.EnergyType EnergyType { get { return m_energyType; } }

    [SerializeField] MeshRenderer renderer;
    [SerializeField] Light light1;


    public void Init(EnergyManger.EnergyType et)
    {
        m_energyType = et;
        if (et == EnergyManger.EnergyType.ANGRY)
            SetColor(Color.red);
        else
            SetColor(Color.green);

    }

    private void SetColor(Color c)
    {
        renderer.material.color = c;
        light1.color = c;
    }
}

