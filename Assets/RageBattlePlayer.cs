using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageBattlePlayer : MonoBehaviour {

    [HideInInspector]
    public int playerIndex = 0;

    [SerializeField] private float speed = 10;

    private void Update()
    {
        // Player1 control
        if(playerIndex == 1)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(transform.forward * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(-transform.forward * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-transform.right * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(transform.right * Time.deltaTime * speed);
            }
        }
        // Player2 control
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(transform.forward * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(-transform.forward * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-transform.right * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(transform.right * Time.deltaTime * speed);
            }
        }
    }
}
