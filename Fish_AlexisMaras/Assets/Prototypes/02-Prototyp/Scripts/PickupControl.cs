using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupControl : MonoBehaviour
{
    [SerializeField] GameObject pickup0;
    [SerializeField] GameObject pickup1;
    [SerializeField] GameObject pickup2;
    [SerializeField] GameObject pickup3;
    [SerializeField] GameObject pickup4;
    [SerializeField] GameObject pickup5;
    [SerializeField] GameObject pickup6;
    [SerializeField] GameObject pickup7;
    [SerializeField] GameObject pickup8;
    [SerializeField] GameObject pickup9;
    [SerializeField] GameObject pickupB;

    [SerializeField] HudControler hud;

    int timer = 0;
    [SerializeField] int timerMax = 100;
    [SerializeField] int timerMin = 25;

    int timerRandom = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void CreateInstances(int randomNumber)
    {
        if (randomNumber == 0)
        {
        GameObject pickup_0_instance = GameObject.Instantiate(pickup0) as GameObject;
        pickup_0_instance.tag = "Odd";
        }
        else if (randomNumber == 1)
        {
        GameObject pickup_1_instance = GameObject.Instantiate(pickup1) as GameObject;
        pickup_1_instance.tag = "Odd";
        }
        else if (randomNumber == 2)
        {
        GameObject pickup_2_instance = GameObject.Instantiate(pickup2) as GameObject;
        pickup_2_instance.tag = "Even";
        }
        else if (randomNumber == 3)
        {
        GameObject pickup_3_instance = GameObject.Instantiate(pickup3) as GameObject;
        pickup_3_instance.tag = "Odd";
        }
        else if (randomNumber == 4)
        {
        GameObject pickup_4_instance = GameObject.Instantiate(pickup4) as GameObject;
        pickup_4_instance.tag = "Even";
        }
        else if (randomNumber == 5)
        {
        GameObject pickup_5_instance = GameObject.Instantiate(pickup5) as GameObject;
        pickup_5_instance.tag = "Odd";
        }
        else if (randomNumber == 6)
        {
        GameObject pickup_6_instance = GameObject.Instantiate(pickup6) as GameObject;
        pickup_6_instance.tag = "Even";
        }
        else if (randomNumber == 7)
        {
        GameObject pickup_7_instance = GameObject.Instantiate(pickup7) as GameObject;
        pickup_7_instance.tag = "Odd";
        }
        else if (randomNumber == 8)
        {
        GameObject pickup_8_instance = GameObject.Instantiate(pickup8) as GameObject;
        pickup_8_instance.tag = "Even";
        }
        else if (randomNumber == 9)
        {
        GameObject pickup_9_instance = GameObject.Instantiate(pickup9) as GameObject;
        pickup_9_instance.tag = "Odd";
        }
        else if (randomNumber == 10)
        {
            if (Random.Range(1, 10) == 1)
            {
                GameObject pickup_b_instance = GameObject.Instantiate(pickupB) as GameObject;
                pickup_b_instance.tag = "Book";
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (hud.score < 0)
        {
            timerMax = 125;
            timerMin = 75;
        }
        else if (hud.score > (-1) && hud.score < 3)
        {
            timerMax = 100;
            timerMax = 50;
        }
        else if (hud.score > 2 && hud.score < 5)
        {
            timerMax = 75;
            timerMax = 25;
        }
        else if (hud.score > 4 && hud.score < 7)
        {
            timerMax = 50;
            timerMax = 10;
        }
        else if (hud.score > 6)
        {
            timerMax = 25;
            timerMax = 0;
        }


        if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject pickup_b_instance = GameObject.Instantiate(pickupB) as GameObject;
                pickup_b_instance.tag = "Book";
            }
    }

    void FixedUpdate()
    {
        timer += 1;
        if (timer == timerRandom)
        {
            CreateInstances(Random.Range(1, 11));
            timerRandom = Random.Range(timerMin, timerMax);
            timer = 0;
        }
    }
}
