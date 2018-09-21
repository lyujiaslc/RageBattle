using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    private Camera m_camera;

    private Transform player1;
    private Transform player2;

    void Start()
    {
        m_camera = Camera.main;
    }

    void Update()
    {
        if (player1 == null || player2 == null)
        {
            player1 = RageBattleGameManager.Instance.player1.transform;
            player2 = RageBattleGameManager.Instance.player2.transform;
        }
        transform.position = (player1.position + player2.position) / 2;
        float dis = Vector3.Distance(player1.position, player2.position);
        float size = dis;
        m_camera.orthographicSize = Mathf.Clamp(Mathf.Lerp(m_camera.orthographicSize, size, 0.2f),9.0f, 22.0f);

    }
}
