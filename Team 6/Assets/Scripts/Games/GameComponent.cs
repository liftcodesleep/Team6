using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComponent : MonoBehaviour
{
    public GameData Game;

    public GameObject player;
    public GameObject GrizzlyBears;
    public GameObject WhiteKnight;
    public GameObject Skeleton;
    public GameObject Minotaur;
    public GameObject Specter;
    public GameObject Knives;
    public GameObject PlagueRats;
    public GameObject Goblin;

    public GameObject[] Spiders;

    public GameObject ToolTip;


    //public static Player[] AllPlayers;


    public static Dictionary<Unit, GameObject> UnitToGameObject;


    [SerializeField] private GameObject HandPreFab;

    

    void Start()
    {
        Game = new GameData();
        Card.SetGameComponent(this);
        MouseController.SetGameLogic(this);

        MakePlayers();
    }

    
    void Update()
    {

    }
    public void DealHands()
    {
        foreach (PlayerData player in Game.Players)
        {
            if (player != null)
            {
                //player.hand.DrawNewHand(player.hand);
            }
        }
    }

    public void InitializeNPlayers(int n)
    {
        Game.Players = new PlayerData[n];

        for (int i = 0; i < n; i++)
        {
            PlayerData CurrentPlayer = new PlayerData();
            Game.Players[i] = CurrentPlayer;

            GameObject PlayerHandGO = Instantiate(HandPreFab, HandPreFab.transform.position, HandPreFab.transform.rotation, Camera.main.transform);
            HandComponent PlayerHandComponent = PlayerHandGO.GetComponent<HandComponent>();

            CurrentPlayer.SetName("Player " + Game.Players.Length);
            CurrentPlayer.SetHand(new Hand(CurrentPlayer));
            CurrentPlayer.SetDeck(new DeckData(CurrentPlayer));
            CurrentPlayer.SetHandComponent(PlayerHandComponent);
            PlayerHandComponent.SetHand(CurrentPlayer.GetHand());

            Game.SetCurrentPlayer(i);
            Unit PlayerAvatar = new AvatarUnit();
            SpawnUnitAt(PlayerAvatar, player, Random.Range(1, 10), Random.Range(1, 10));
            CurrentPlayer.SetAvatar(PlayerAvatar);
        }
    }

    public void MakePlayers()
    {
        //Main Menu Prompts Player Count? Names?

        int PlayerCount = 2; //get user input eventually

        InitializeNPlayers(PlayerCount);

        Game.SetCurrentPlayer(Random.Range(0, PlayerCount));
    }

    public Unit GameObjectToUnit(GameObject unit)
    {

        foreach (var item in UnitToGameObject)
        {
            if (item.Value == unit)
            {
                return item.Key;
            }
        }

        return null;

    }

    public void SpawnUnitAt(Unit unit, GameObject prefab, int col, int row)
    {

        if (Game.units == null)
        {
            Game.units = new HashSet<Unit>();
            UnitToGameObject = new Dictionary<Unit, GameObject>();
        }

        Hex spawnedHex = HexMap.GetHex(col, row);
        GameObject spawpoint = HexMap.HexToGameObject[spawnedHex];
        unit.SetHex(spawnedHex);
        unit.SetOwner(Game.GetCurrentPlayer());
        GameObject unitGO = Instantiate(prefab, spawpoint.transform.position, prefab.transform.rotation, spawpoint.transform);
        
        unitGO.GetComponent<UnitComponent>().unit = unit;

        //Game.GetCurrentPlayer().GetUnits().Add(unit);

        Game.units.Add(unit);

        UnitToGameObject[unit] = unitGO;
    }

    

    public void NextTurn()
    {
        Game.NextTurn();
    }



    
}