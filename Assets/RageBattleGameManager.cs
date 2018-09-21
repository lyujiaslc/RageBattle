using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageBattleGameManager : MonoBehaviour {

    [SerializeField] private GameObject playerPrefab = null;

    private RageBattlePlayer player1;
    private RageBattlePlayer player2;

    public void InitializePlayers()
    {
        player1 = Instantiate(playerPrefab, GetSpawnpoint(), Quaternion.identity).GetComponent<RageBattlePlayer>();
        player1.playerIndex = 1;

        player2 = Instantiate(playerPrefab, GetSpawnpoint(), Quaternion.identity).GetComponent<RageBattlePlayer>();
        player2.playerIndex = 2;
    }

    public void OnGameStarted()
    {
        InitializePlayers();
    }

    public void OnGameFinished()
    {
        Destroy(player1.gameObject);
        Destroy(player2.gameObject);
    }

    private void Start()
    {
        OnGameStarted();
    }

    private Vector3 GetSpawnpoint()
    {
        return new Vector3(Random.Range(-20, 20), Random.Range(2, 8), Random.Range(-20, 20));
    }
}
