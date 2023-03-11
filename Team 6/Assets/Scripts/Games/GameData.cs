using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class GameData
{
    public int TurnCount = 1;
    public int PlayerCount;
    public PlayerData[] Players;
    public int CurrentPlayer;

    public Player[] AllPlayers;


    public HashSet<Unit> units;

    public static Card[] allCards = {
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

    public Player GetCurrentPlayer()
    {
        return AllPlayers[CurrentPlayer];
    }
}