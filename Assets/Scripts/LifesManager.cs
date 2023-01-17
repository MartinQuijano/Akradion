using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifesManager : MonoBehaviour
{
    public Player player;
   // public TMPro.TextMeshProUGUI lifesText;

    public GameObject[] ui_racketlifes;
    public GameObject[] ui_powerupsacc;

    public int activePowerUps;
    private int maxActivePowerUps;

    // Start is called before the first frame update
    void Start()
    {
        activePowerUps = 0;
        maxActivePowerUps = 10;

        //  lifesText = GetComponent<TMPro.TextMeshProUGUI>();
        ui_racketlifes[0].SetActive(true);
        ui_racketlifes[1].SetActive(true);
        ui_racketlifes[2].SetActive(true);
        ui_racketlifes[3].SetActive(false);
        ui_racketlifes[4].SetActive(false);

        ui_powerupsacc[0].SetActive(false);
        ui_powerupsacc[1].SetActive(false);
        ui_powerupsacc[2].SetActive(false);
        ui_powerupsacc[3].SetActive(false);
        ui_powerupsacc[4].SetActive(false);
        ui_powerupsacc[5].SetActive(false);
        ui_powerupsacc[6].SetActive(false);
        ui_powerupsacc[7].SetActive(false);
        ui_powerupsacc[8].SetActive(false);
        ui_powerupsacc[9].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //  lifesText.text = "Lifes: " + player.GetLifes();
        if (activePowerUps == 10)
        {
            player.IncreaseLifesByOne();
            activePowerUps = 0;
        }

        for (int i = 0; i < player.GetLifes(); i++)
        {
            ui_racketlifes[i].SetActive(true);
        }

        for (int j = player.GetLifes(); j < 5; j++)
        {
            ui_racketlifes[j].SetActive(false);
        }

        for (int a = 0; a < activePowerUps; a++)
        {
            ui_powerupsacc[a].SetActive(true);
        }

        for (int b = activePowerUps; b < 10; b++)
        {
            ui_powerupsacc[b].SetActive(false);
        }
    }

    public void IncreasePowerUpsActive()
    {
        if(activePowerUps < maxActivePowerUps)
            activePowerUps++;
    }
}
