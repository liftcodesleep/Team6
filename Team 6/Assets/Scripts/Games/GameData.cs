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
        new Spider(),
        new Knives(),
        new Goblin()};

    public GameData()
    {
        Card.SetGameData(this);
        HandComponent.SetGameData(this);
        CardComponent.SetGameData(this);
        UnitComponent.SetGameData(this);
        HexComponent.SetGameData(this);
        ManaUpdater.SetGameData(this);
    }

    public void SetCurrentPlayer(int player)
    {
        this.CurrentPlayer = player;
    }
    public PlayerData GetCurrentPlayer() 
    { 
        return this.Players[CurrentPlayer];
    }

    public void NextTurn()
    {
        SetCurrentPlayer((CurrentPlayer + 1) % Players.Length); //AllPlayers.Length);
        GetCurrentPlayer().GetHand().DrawNCards(1);
    }
}