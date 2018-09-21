using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageBattleUIController : MonoBehaviour {

    [SerializeField] RageBattleGameManager rageBattleGameManager;
    [SerializeField] Slider player1RageMeter;
    [SerializeField] Slider player2RageMeter;

    private Gradient gradient;

    private void Update()
    {
        player1RageMeter.value = rageBattleGameManager.player1.health;
        player2RageMeter.value = rageBattleGameManager.player2.health;
        //gradient.Evaluate(Time.deltaTime);
    }
}
