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
    private float redRatio, greenRatio;

    private void Start()
    {
        UpdateColor(0);
    }

    //Player control stuff
    private void Update()
    {
        if(currentColor != targetColor)
        {
            GetComponent<Renderer>().material.color = targetColor;
            currentColor = targetColor;
        }
        // Player1 control
        if(playerIndex == 1)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                UpdateColor(1);
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

    //Collect health
    private void OnTriggerEnter(Collider other)
    {
        
    }

    //Hit something: player or wall
    private void OnCollisionEnter(Collision collision)
    {

    }

    //Update player color based on the health change
    private void UpdateColor(float change)
    {
        health += change;
        redRatio = (health + change) / 100;
        greenRatio = 1 - redRatio;
        //Debug.LogError("red: " + redRatio);
        //Debug.LogError("green: " + greenRatio);
        targetColor = new Color(Mathf.Clamp01(redRatio), Mathf.Clamp01(greenRatio), 0f);
    }
}
