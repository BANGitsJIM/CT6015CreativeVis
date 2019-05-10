using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex = -1;

    public ButtonPressed GoButton;
    public ButtonPressed StopButton;
    public ButtonPressed ResetButton;
    public ButtonPressed ExitButton;
    public ButtonPressed StartButton;
    public ButtonPressed ContinueButton;

    private GameObject car;
    private CarController carController;
    private GameObject sign;
    private DestructibleController destructibleController;

    private bool turnLeft = false;
    private bool turnRight = false;
    private bool signSelected = false;

    private bool touchSingle = false;
    private bool touchDouble = false;
    private bool goPressed = false;
    private bool stopPressed = false;
    private bool startTilt = false;

    private float waitTime = 2f;

    private void Start()
    {
        car = GameObject.FindWithTag("Player");
        carController = car.GetComponent<CarController>();
        StartCoroutine(StartPopUps(3));
    }

    private IEnumerator StartPopUps(float myDelay)
    {
        yield return new WaitForSeconds(myDelay);
        popUpIndex++;
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
            if (StartButton.Pressed())
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                touchSingle = true;
            }

            if (touchSingle == true)
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
            if (Input.GetButton("Fire2"))
            {
                touchDouble = true;
            }

            if (touchDouble == true)
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
        else if (popUpIndex == 3)
        {
            GoButton.gameObject.SetActive(true);

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
        else if (popUpIndex == 4)
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
        else if (popUpIndex == 5)
        {
            if (carController.m_horizontalInput < 0)
            {
                turnRight = true;
            }
            if (carController.m_horizontalInput > 0)
            {
                turnLeft = true;
            }

            if (turnLeft && turnRight)
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
        else if (popUpIndex == 6)
        {
            ResetButton.gameObject.SetActive(true);

            if (ResetButton.Pressed())
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 7)
        {
            if (ContinueButton.Pressed())
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 8)
        {
            GameObject game = GameObject.FindWithTag("GameController");
            SignHandler signHandler = game.GetComponent<SignHandler>();
            signHandler.enabled = true;
            Debug.Log(signSelected);

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
        else if (popUpIndex == 9)
        {
            ExitButton.gameObject.SetActive(true);
        }
    }
}