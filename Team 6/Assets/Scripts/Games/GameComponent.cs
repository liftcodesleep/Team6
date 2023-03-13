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

    public void MakePlayers()
    {
        //Main Menu Prompts Player Count? Names?
        Game.Players = new PlayerData[] { new PlayerData(), new PlayerData() };


        GameObject PlayerHandGO = Instantiate(HandPreFab, HandPreFab.transform.position, HandPreFab.transform.rotation, Camera.main.transform);
        HandComponent PlayerHandComponent = PlayerHandGO.GetComponent<HandComponent>();

        Game.Players[0].SetName("Player 1");
        Game.Players[0].SetHand(new Hand(Game.Players[0]));
        Game.Players[0].SetDeck(new DeckData(Game.Players[0]));
        Game.Players[0].SetHandComponent(PlayerHandComponent);
        PlayerHandComponent.SetHand(Game.Players[0].GetHand());

        PlayerHandGO = Instantiate(HandPreFab, HandPreFab.transform.position, HandPreFab.transform.rotation, Camera.main.transform);
        PlayerHandComponent = PlayerHandGO.GetComponent<HandComponent>();

        Game.Players[1].SetName("Player 2");
        Game.Players[1].SetHand(new Hand(Game.Players[1]));
        Game.Players[1].SetDeck(new DeckData(Game.Players[1]));
        Game.Players[1].SetHandComponent(PlayerHandComponent);
        PlayerHandComponent.SetHand(Game.Players[1].GetHand());

        Game.SetCurrentPlayer(0);
        Unit PlayerOneAvatar = new AvatarUnit();
        Unit PlayerTwoAvatar = new AvatarUnit();
        SpawnUnitAt(PlayerOneAvatar, player, 5, 8);
        SpawnUnitAt(PlayerTwoAvatar, player, 10, 3);
        Game.Players[0].SetAvatar(PlayerOneAvatar);
        Game.Players[1].SetAvatar(PlayerTwoAvatar);
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
        //GameObject unitGO = Instantiate(prefab, spawpoint.transform.position, Quaternion.identity, spawpoint.transform);
        GameObject unitGO = Instantiate(prefab, spawpoint.transform.position, prefab.transform.rotation, spawpoint.transform);
        
        unitGO.GetComponent<UnitComponent>().unit = unit;
        
        Game.units.Add(unit);

        Game.GetCurrentPlayer().GetUnits().Add(unit);
        UnitToGameObject[unit] = unitGO;
    }

    

    public void NextTurn()
    {
        Game.NextTurn();
    }



    
}