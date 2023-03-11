using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class GameData
{
    public int TurnCount = 1;
    public int PlayerCount;
    public PlayerData[] Players;
    private int CurrentPlayer;

    public PlayerComponent[] AllPlayers;


    public HashSet<Unit> units;

    public static Card[] AllCards = {
        new GrizzlyBears(),
        new HolyStrength(),
        new Bolt(),
        new WhiteKnight(),
        new Skeleton(),
        new Teleport(),
        new Minotaur(),
        new Specter(),
        new Spider()};

    public GameData()
    {
        Card.SetGameData(this);
        HandComponent.SetGameData(this);
        CardComponent.SetGameData(this);
    }

    public void SetCurrentPlayer(int player)
    {
        this.CurrentPlayer = player;
    }
    public int GetCurrentPlayer() 
    { 
        return this.CurrentPlayer; 
    }

    public PlayerData GetCurrentPlayerData()
    {
        return Players[CurrentPlayer];
    }
    
}