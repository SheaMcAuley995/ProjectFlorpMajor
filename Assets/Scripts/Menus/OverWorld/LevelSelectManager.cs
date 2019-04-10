﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    public PlayerController[] players;

    private void Awake()
    {
        players = FindObjectsOfType<PlayerController>();
    }

    // TODO: Store user data on levels they've beaten & lock levels 2 and 3 until reached
    public void LaunchLevel(string scene)
    {
        switch (OverworldManager.instance.level)
        {
            case OverworldManager.Level.Level1:
                scene = "MichaelBetaLevelBuild";
                break;
            case OverworldManager.Level.Level2:
                scene = "MichaelBetaLevelBuild";
                break;
            case OverworldManager.Level.Level3:
                scene = "MichaelBetaLevelBuild";
                break;
        }

        SceneFader.instance.FadeTo(scene);
    }
}
