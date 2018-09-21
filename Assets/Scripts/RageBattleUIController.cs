using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageBattleUIController : MonoBehaviour {

    [SerializeField] Slider player1RageMeter;
    [SerializeField] Slider player2RageMeter;

    private Gradient gradient;

    private void Update()
    {
        if(RageBattleGameManager.Instance.player1 != null)
        {
            player1RageMeter.value = RageBattleGameManager.Instance.player1.health;
            player2RageMeter.value = RageBattleGameManager.Instance.player2.health;
        }
    }
}
