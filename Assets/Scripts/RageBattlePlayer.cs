using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageBattlePlayer : MonoBehaviour {

    [SerializeField] private float speed = 10;

    [HideInInspector]
    public int playerIndex;
    [HideInInspector]
    public float health;

    private Color currentColor;
    private Color targetColor;

    private int collectEnergyAmount;

    private void Start()
    {
        UpdateColor(0);
    }

    //Player control stuff
    private void Update()
    {
        UpdateColor(collectEnergyAmount);
        if(currentColor != targetColor)
        {
            GetComponent<Renderer>().material.color = targetColor;
            currentColor = targetColor;
            if(collectEnergyAmount != 0)
            {
                health += collectEnergyAmount / Mathf.Abs(collectEnergyAmount);
            }
        }

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

    //Update health and color
    private void OnTriggerEnter(Collider col)
    {
        collectEnergyAmount += EnergyManger.Instance.CollectEnergyAmount(col);
    }

    //Hit something: player or wall
    private void OnCollisionEnter(Collision collision)
    {

    }

    //Update player color based on the health change
    private void UpdateColor(float change)
    {
        float redRatio = (health + change) / 100;
        float greenRatio = 1 - redRatio;
        targetColor = new Color(Mathf.Clamp01(redRatio), Mathf.Clamp01(greenRatio), 0f);
    }
}
