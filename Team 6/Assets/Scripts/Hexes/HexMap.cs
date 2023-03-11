using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class HexMap : MonoBehaviour 
{

    public GameObject[] Prefabs;


    public static readonly int NumRows = 10;
    public static readonly int NumColumns = 15;

    public GameObject player;
    public GameObject GrizzlyBears;
    public GameObject WhiteKnight;
    public GameObject Skeleton;
    public GameObject Minotaur;
    public GameObject Specter;

    public GameObject[] Spiders;

    private static Hex[,] hexes;
    private HashSet<Unit> units;

    public static Dictionary<Hex, GameObject> hexToGameObject;
    public static Dictionary<Unit, GameObject> unitToGameObject;

    public static bool allowWrapEastWest = true;
    public static bool allowWrapNorthSouth = false;

    private readonly bool debug = false;

    public static bool MakeRandomMap = true;

    public static Player[] AllPlayers;
    public static int currentPlayer;

    [SerializeField] private GameObject HandPreFab;


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

    void Start()
    {
        Card.setMap(this);
        
        GenerateMap();

        MakePlayers();

        

    }

    private void Update()
    {
       
        
    }

    public int GetPrefabsCount()
    {
        return Prefabs.Length;
    }
    public void GenerateMap()
    {
        hexes = new Hex[NumRows,NumColumns];
        hexToGameObject = new Dictionary<Hex, GameObject>();

        for (int column = 0; column < NumColumns; column++)
        {
            for (int row = 0; row < NumRows; row++)
            {

                Hex h = new Hex(column, row);

                GameObject hexGo = (GameObject)Instantiate(
                 Prefabs[h.GetSeed()],
                 new Vector3(0,0,0),
                 Quaternion.identity,
                 this.transform
                 );
                
                HexComponent component = hexGo.GetComponent<HexComponent>();

                component.hex = h;
                component.hexMap = this;

                hexGo.transform.position = component.PositionFromCamera();

                if (debug)
                {
                    hexGo.GetComponentInChildren<TextMesh>().text = string.Format("{0},{1}", column, row);
                }
                else
                {
                    hexGo.GetComponentInChildren<TextMesh>().text = "";
                }
                
                //TODO name should be capitalized and relfect hex type/prefab/identity
                hexGo.name = string.Format("{0},{1}", column, row);


                
                //MeshRenderer mr = hexGo.transform.Find("Model").GetComponentInChildren<MeshRenderer>();
                
                //mr.material = HexMaterials[h.GetElevation()];
                
                hexes[row, column] = h;
                hexToGameObject[h] = hexGo;
              
            }

        }

    }

    public static Hex GetHex(int col, int row)
    {
        return hexes[row, col % NumColumns];
    }

    public static Hex gameObjectToHex(GameObject hex)
    {
        
        foreach(var item in hexToGameObject)
        {
            if(item.Value == hex)
            {
                return item.Key;
            }
        }

        return null;

    }

    public static Unit gameObjectToUnit(GameObject unit)
    {

        foreach (var item in unitToGameObject)
        {
            if (item.Value == unit)
            {
                return item.Key;
            }
        }

        return null;

    }




    public static Vector3 GetHexPosition(int q, int r)
    {

        Hex h = GetHex(q, r);

        return GetHexPosition(h);
    }

    public static Vector3 GetHexPosition(Hex h)
    {

        return hexToGameObject[h].GetComponent<HexComponent>().PositionFromCamera();
    }

    public void SpawnUnitAt(Unit unit, GameObject prefab, int col, int  row)
    {

        if(units == null)
        {
            units = new HashSet<Unit>();
            unitToGameObject = new Dictionary<Unit, GameObject>();
        }

        Hex spawnedHex = GetHex(col, row);
        GameObject spawpoint = hexToGameObject[spawnedHex];
        unit.SetHex(spawnedHex);
        //GameObject unitGO = Instantiate(prefab, spawpoint.transform.position, Quaternion.identity, spawpoint.transform);
        GameObject unitGO = Instantiate(prefab, spawpoint.transform.position, prefab.transform.rotation, spawpoint.transform);

        units.Add(unit);
        unitToGameObject[unit] = unitGO;
    }


    public void NextTurn()
    {
        currentPlayer = (currentPlayer + 1) % AllPlayers.Length;
        //GetCurrentPlayer().hand.Draw();
        GetCurrentPlayer().NewTurn();
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


        currentPlayer = 0;
        SpawnUnitAt(AllPlayers[0], player, 5, 5);
        SpawnUnitAt(AllPlayers[1], player, 10, 3);
    }

    public static Player GetCurrentPlayer()
    {
        return AllPlayers[currentPlayer];
    }
}
