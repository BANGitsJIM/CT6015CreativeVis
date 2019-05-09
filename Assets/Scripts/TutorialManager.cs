using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;

    public ButtonPressed GoButton;
    public ButtonPressed StopButton;
    public ButtonPressed ResetButton;
    public ButtonPressed ExitButton;

    private GameObject car;
    private CarController carController;
    private GameObject sign;
    private DestructibleController destructibleController;

    private bool turnLeft = false;
    private bool turnRight = false;
    private bool signSelected = false;

    private bool goPressed = false;
    private bool stopPressed = false;
    private bool startTilt = false;

    private float waitTime = 2f;

    private void Start()
    {
        car = GameObject.FindWithTag("Player");
        carController = car.GetComponent<CarController>();
    }

    private void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        if (popUpIndex == 0)
        {
            if (GoButton.Pressed())
            {
                goPressed = true;
            }

            if (goPressed == true)
            {
                if (waitTime <= 0)
                {
                    waitTime = 2f;
                    popUpIndex++;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
        else if (popUpIndex == 1)
        {
            StopButton.gameObject.SetActive(true);

            if (StopButton.Pressed())
            {
                stopPressed = true;
            }

            if (stopPressed == true)
            {
                if (waitTime <= 0)
                {
                    waitTime = 2f;
                    popUpIndex++;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
        else if (popUpIndex == 2)
        {
            if (carController.m_horizontalInput == 1)
            {
                turnRight = true;
            }
            if (carController.m_horizontalInput == -1)
            {
                turnLeft = true;
            }

            if (turnLeft && turnRight)
            {
                if (waitTime <= 0)
                {
                    waitTime = 3f;
                    popUpIndex++;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
        else if (popUpIndex == 3)
        {
            ResetButton.gameObject.SetActive(true);

            if (ResetButton.Pressed())
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 4)
        {
            if (waitTime <= 0)
            {
                waitTime = 2f;
                popUpIndex++;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (popUpIndex == 5)
        {
            GameObject game = GameObject.FindWithTag("GameController");
            SignHandler signHandler = game.GetComponent<SignHandler>();
            signHandler.enabled = true;

            if (signSelected == false)
            {
                sign = GameObject.FindWithTag("Sign");
                destructibleController = sign.GetComponent<DestructibleController>();
                signSelected = true;
            }

            if (destructibleController.thisSignDestroyed == true)
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 6)
        {
            ExitButton.gameObject.SetActive(true);
        }
    }
}