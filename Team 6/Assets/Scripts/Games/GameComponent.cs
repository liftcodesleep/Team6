using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComponent : MonoBehaviour
{
    public GameData game;

    public GameObject player;
    public GameObject GrizzlyBears;
    public GameObject WhiteKnight;
    public GameObject Skeleton;
    public GameObject Minotaur;
    public GameObject Specter;

    public GameObject[] Spiders;

    public static Player[] AllPlayers;
    



    [SerializeField] private GameObject HandPreFab;

    
    public static Dictionary<Unit, GameObject> UnitToGameObject;

    void Start()
    {
        game = new GameData();
        Card.SetGameComponent(this);

        MakePlayers();
    }

    
    void Update()
    {

    }
    public void DealHands()
    {
        foreach (PlayerData player in game.Players)
        {
            if (player != null)
            {
                //player.hand.DrawNewHand(player.hand);
            }
        }
    }
    public void AdvanceTurn()
    {

    }

    public void MakePlayers()
    {


        AllPlayers = new Player[] { new Player(), new Player() };

        AllPlayers[0].Name = "Player 1";
        AllPlayers[1].Name = "Player 2";

        GameObject handGO = Instantiate(HandPreFab, HandPreFab.transform.position, HandPreFab.transform.rotation, Camera.main.transform);
        HandComponent hand = handGO.GetComponent<HandComponent>();
        hand.SetHand(AllPlayers[0].hand);

        handGO = Instantiate(HandPreFab, HandPreFab.transform.position, HandPreFab.transform.rotation, Camera.main.transform);
        hand = handGO.GetComponent<HandComponent>();
        hand.SetHand(AllPlayers[1].hand);


        game.CurrentPlayer = 0;
        SpawnUnitAt(AllPlayers[0], player, 5, 5);
        SpawnUnitAt(AllPlayers[1], player, 10, 3);
    }


    public void SpawnUnitAt(Unit unit, GameObject prefab, int col, int row)
    {

        if (game.units == null)
        {
            game.units = new HashSet<Unit>();
            UnitToGameObject = new Dictionary<Unit, GameObject>();
        }

        Hex spawnedHex = HexMap.GetHex(col, row);
        GameObject spawpoint = HexMap.HexToGameObject[spawnedHex];
        unit.SetHex(spawnedHex);
        //GameObject unitGO = Instantiate(prefab, spawpoint.transform.position, Quaternion.identity, spawpoint.transform);
        GameObject unitGO = Instantiate(prefab, spawpoint.transform.position, prefab.transform.rotation, spawpoint.transform);

        game.units.Add(unit);
        UnitToGameObject[unit] = unitGO;
    }

    public static Unit GameObjectToUnit(GameObject unit)
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

    public void NextTurn()
    {
        game.CurrentPlayer = (game.CurrentPlayer + 1) % AllPlayers.Length;
        //GetCurrentPlayer().hand.Draw();
        game.GetCurrentPlayer().NewTurn();
    }



    
}