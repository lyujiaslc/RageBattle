using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour, CollectAble {
    private EnergyManger.EnergyType m_energyType;
    public EnergyManger.EnergyType EnergyType { get { return m_energyType; } }

    public int CollectEnergyAmount { get { return (int)m_energyType; } }

}

