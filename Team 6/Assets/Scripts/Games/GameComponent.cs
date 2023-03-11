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

    public GameObject[] Spiders;

    //public static Player[] AllPlayers;


    public static Dictionary<Unit, GameObject> UnitToGameObject;


    [SerializeField] private GameObject HandPreFab;

    

    void Start()
    {
        Game = new GameData();
        Card.SetGameComponent(this);

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
        //AllPlayers = new Player[] { new Player(), new Player() };


        GameObject PlayerHandGO = Instantiate(HandPreFab, HandPreFab.transform.position, HandPreFab.transform.rotation, Camera.main.transform);
        HandComponent PlayerHandComponent = PlayerHandGO.GetComponent<HandComponent>();
        
        //PlayerHandComponent.SetHand(AllPlayers[0].hand);

        PlayerHandGO = Instantiate(HandPreFab, HandPreFab.transform.position, HandPreFab.transform.rotation, Camera.main.transform);
        PlayerHandComponent = PlayerHandGO.GetComponent<HandComponent>();
        //PlayerHandComponent.SetHand(AllPlayers[1].hand);


        Game.SetCurrentPlayer(0);
        SpawnUnitAt(new AvatarUnit(), player, 5, 8);
        SpawnUnitAt(new AvatarUnit(), player, 10, 3);
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
        //GameObject unitGO = Instantiate(prefab, spawpoint.transform.position, Quaternion.identity, spawpoint.transform);
        GameObject unitGO = Instantiate(prefab, spawpoint.transform.position, prefab.transform.rotation, spawpoint.transform);

        Game.units.Add(unit);
        UnitToGameObject[unit] = unitGO;
    }

    

    public void NextTurn()
    {
        Game.SetCurrentPlayer((Game.GetCurrentPlayer() + 1) % 2); //AllPlayers.Length);
        //GetCurrentPlayer().hand.Draw();
        Game.AllPlayers[Game.GetCurrentPlayer()].playerData.GetHand().Draw();
    }



    
}