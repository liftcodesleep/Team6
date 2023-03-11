using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class GameData
{
    public int TurnCount = 1;
    public int PlayerCount;
    public PlayerData[] Players;
    public int ActivePlayerIndex = 0;

    public Player[] AllPlayers;

    public  int currentPlayer;

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
        Card.setGameData(this);
        HandComponent.SetGameData(this);

    }

    public Player GetCurrentPlayer()
    {
        return AllPlayers[currentPlayer];
    }
}