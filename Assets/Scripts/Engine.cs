﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Engine : MonoBehaviour {

    public static Engine instance;
    [Header("Engine Statistics")]
    public float engineHeat;
    public float maxHeat;
    public float engineCoolingAmount;
    [Range(0, 1)] public float florpCoolingPercentage;

    [HideInInspector] public bool startEngineBehavior = false;
    public bool isFuled = false;

    [Header("Win Condition")]
    //public JumpToHyperSpace jumpScript;
    public float winConditionLimit;
    public float currentProgress;
    public float enemyProgress;


    public Slider ShipProgressSlider;
    public Slider enemyShipProgressSlider;
    public AlertUI alertUI;

    [Header("Debug Tools")]
    public bool testInputFlorp = false;

    public GameObject loseGameScreen;
    public GameObject winGameScreen;

    private float time;
    private float timeSinceLastEvent;

    private float preEnemyProgress;
    private float preCurrentProgress;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void Start()
    {
        GameplayLoopManager.onNextTickEvent += EngineUpdate;
        //engineHeat = maxHeat * 0.75f;
        currentProgress = 2;
        //alertUI.problemMax = maxHeat;
    }

    private void Update()
    {
        
        ShipProgressSlider.value = Mathf.Lerp(ShipProgressSlider.value, currentProgress / winConditionLimit, time / GameplayLoopManager.TimeBetweenEvents);
        enemyShipProgressSlider.value = Mathf.Lerp(enemyShipProgressSlider.value, enemyProgress / winConditionLimit, time / GameplayLoopManager.TimeBetweenEvents);
        time += Time.deltaTime;
        //Debug.Log(time / GameplayLoopManager.TimeBetweenEvents);
    }

    public void EngineUpdate()
    {

        //engineHeat -= Time.deltaTime * engineCoolingAmount;

        if (testInputFlorp)
        {
            InsertFlorp();
            testInputFlorp = false;
        }



        preEnemyProgress = enemyProgress;
        preCurrentProgress = currentProgress;
        time = 0;
        if (isFuled) { currentProgress += 2; }
        enemyProgress += 1;

        //currentProgress += Time.deltaTime * engineHeatPercentage() * progressionMultiplier;
        //enemyProgress += Time.deltaTime * 100 * enemyProgressionMultiplier;

        engineHeat = Mathf.Clamp(engineHeat, 0, maxHeat);


        if (currentProgress > winConditionLimit)
        {
            WinGame();
        }
        if (enemyProgress > currentProgress)
        {
            LoseGame();
        }
        //AudioEventManager.instance.PlaySound("engine");
        //alertUI.problemCurrent = engineHeat;
    }

    private void WinGame()
    {
        winGameScreen.SetActive(true);
        //GameStateManager.instance.SetGameState(GameState.Won);

        //TODO: GAMESTATE: ZACH. There's a lot of zach's work in here that needs replacing. All the commented stuff needs to be removed or fixed.
        
        //StartCoroutine(jumpScript.HyperspaceJump());
    }

    private void LoseGame()
    {
        //SceneFader.instance.FadeTo("LoseScene");
        loseGameScreen.SetActive(true);
        GameStateManager.instance.SetGameState(GameState.LostByFlorp);
        //ASyncManager.instance.loseOperation.allowSceneActivation = true;
    }

    public void InsertFlorp()
    {
        engineHeat = Mathf.Clamp(engineHeat += maxHeat * florpCoolingPercentage, 0, maxHeat);
    }

    public float engineHeatPercentage()
    {
        return Mathf.Clamp((engineHeat / maxHeat) * 100, 0, 100);
    }
}
