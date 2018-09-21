using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    private Camera m_camera;

    private Transform player1;
    private Transform player2;
    // Use this for initialization
    void Start()
    {
        RageBattlePlayer[] players = GameObject.FindObjectsOfType<RageBattlePlayer>();
        player1 = players[0].transform;
        player2 = players[1].transform;

        m_camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1 == null || player2 == null) return;
        transform.position = (player1.position + player2.position) / 2;
        float dis = Vector3.Distance(player1.position, player2.position);
        float size = dis;
        m_camera.orthographicSize = Mathf.Clamp(Mathf.Lerp(m_camera.orthographicSize, size, 0.2f),9.0f, 22.0f);

    }
}
