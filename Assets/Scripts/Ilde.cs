using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;
using static BreakInfinity.BigDouble;

[Serializable]

public class PlayerData
{
    public BigDouble coins;
    public BigDouble coinsCollected;
    public BigDouble coinsPerSec;
    public BigDouble coinsClickValue;
    public BigDouble clickUpgrade1Level;
    public BigDouble clickUpgrade2Level;
    public BigDouble productionUpgrade1Level;
    public BigDouble productionUpgrade2Level;
    public BigDouble gems;
    public BigDouble gemBoost;
    public BigDouble gemsToGet;
    public BigDouble achLevel1;
    public BigDouble achLevel2;

public PlayerData()
{
    FullReset();
}

public void FullReset()
{
    coins = 0;
    coinsCollected = 0;
    coinsClickValue = 1;
    clickUpgrade1Level = 0;
    clickUpgrade2Level = 0;
    productionUpgrade1Level = 0;
    productionUpgrade2Level = 0;
    productionUpgrade2Power = 0;
    gems = 0;
    gemBoost = 1;
    gemsToGet = 0;
    achLevel1 = 0;
    achLevel2 = 0;
}

public class Idle : MonoBehaviour
{
    public PlayerData data;
    
    // Texts
    public Text coinsText;
    public Text coinsPerSecText;
    public Text clickTextValue;

    // Click Upgrade 1
    public Text clickUpgrade1Text;

    // Click Upgrade 1 Buy Max
    public Text clickUpgrade1MaxText;

    // Click Upgrade 2
    public Text clickUpgrade2Text;

    // Click Upgrade 2 Buy Max
    public Text clickUpgrade2MaxText;

    // Production Upgrade 1
    public Text productionkUpgrade1Text;

    // Production Upgrade 1 Buy Max
    public Text productionUpgrade1MaxText;

    // Production Upgrade 2
    public Text productionUpgrade2Text;

    // Production Upgrade 2 Buy Max
    public Text productionkUpgrade2MaxText;

    // Prestige
    public Text gemsText;
    public Text gemBoostText;
    public Text gemsToGetText;

    // Canvas Group
    public CanvasGroup mainMenuGroup;
    public CanvasGroup upgradesGroup;
    public CanvasGroup achievementsGroup;
    public int tabSwitcher;

    // Settings
    public GameObject settings;

    // Image Bar
    public Image clickUpgrade1Bar;
    public Image clickUpgrade1BarSmooth;

    // Costs

    // Click Upgrade 1 Cost
    public BigDouble clickCost1 => 10 * Pow(1.07, data.clickUpgrade1Level);

    // Click Upgrade 2 Cost
    public BigDouble clickCost2 => 25 * Pow(1.07, data.clickUpgrade2Level);

    // Production Upgrade 1 Cost
    public BigDouble pCost1 => 25 * Pow(1.07, data.productionUpgrade1Level);

    // Production Upgrade 2 Cost
    public BigDouble pCost2 => 250 * Pow(1.07, data.productionUpgrade2Level);

    public BigDouble coinsTemp;

    // Achievements
    public GameObject achievementScreen;
    public List<Achievements> AchievementList = new List<Achievements>();

    public void Start()
    {
        Application.targetFrameRate = 60;

        foreach(var x in achievementScreen.GetComponentsInChildren<Achievements>())
            achievementList.Add(x);
        
        CanvasGroupChange(true, mainMenuGroup);
        CanvasGroupChange(false, upgradesGroup);
        CanvasGroupChange(false, achievementGroup);
        tabSwitcher = 0;

        SaveSystem.LoadPlayer(ref data);
    }

    public void CanvasGroupChange(bool x, CanvasGroup y)
    {
        if (x)
        {
            y.alpha = 1;
            y.interactable = true;
            y.blocksRaycasts = true;
            return;
        }
        y.alpha = 0;
        y.interactable = false;
        y.blocksRaycasts = false;
    }

    public Update()
    {
        BigDoubleFill(data.coins, clickCost1, clickUpgrade1Bar);
        BigDoubleFill(data.coins, clickCost1, clickUpgrade1BarSmooth);

        data.gemsToGet = 150 * sqrt(data.coins / 1e7);
        data.gemBoost = (data.gems * 0.05) + 1;

        gemsToGetText.text = "Prestige :\n" + Floor(data.gemsToGet).ToString("F0") + "Gems";
        gemsText.text = "Gems : " + Floor(data.gems).ToString("F0");
        gemBoostText.text = data.gemBoost.ToString("F2") + "x boost";

        data.coinsPerSec
    }

}