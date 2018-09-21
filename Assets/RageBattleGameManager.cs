using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageBattleGameManager : MonoBehaviour {

    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private Transform[] spawnPoints = null;

    public void InitializePlayers()
    {
        Instantiate(playerPrefab, spawnPoints[0]);
        Instantiate(playerPrefab, spawnPoints[1]);
    }

    public void OnGameFinished()
    {
        
    }

    private void SetupSpawnpoints(Transform[] spawnPoints)
    {
        
    }
}
