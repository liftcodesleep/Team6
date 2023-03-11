using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardComponent : MonoBehaviour
{
    public GameObject unitSummon;
    private Vector3 startPosition;
   

    public bool clicked;
    private Vector3 currentVelocity;

    private Vector3 selectedPosition;

    private float smoothTime = .5f;

    public bool played = false;
    public bool drawed = false;

    //private float shrinkSpeed = .9f;

    public static GameData Game;
    public Card card;

    [SerializeField] HexMap hexMap;
    private TextMesh textMesh;


    static Card[] allCards = {
        new GrizzlyBears(),
        new HolyStrength(),
        new Bolt(),
        new WhiteKnight(),
        new Skeleton(),
        new Teleport(),
        new Minotaur(),
        new UnholyStrength(),
        new Specter(),
        new Spider()};



    public void Hide()
    {
        MeshRenderer[] meshes = this.GetComponentsInChildren<MeshRenderer>();

        this.GetComponent<MeshCollider>().enabled = false;

        foreach (MeshRenderer mesh in meshes)
        {
            mesh.enabled = false;
        }
    }

    public void Show()
    {
        MeshRenderer[] meshes = this.GetComponentsInChildren<MeshRenderer>();

        this.GetComponent<MeshCollider>().enabled = true;

        foreach (MeshRenderer mesh in meshes)
        {
            mesh.enabled = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.startPosition = this.transform.position;
        this.selectedPosition = startPosition + new Vector3(0, 0, .5f);
        textMesh = this.gameObject.GetComponentInChildren<TextMesh>();

        card = SetRandomCard();
        

        SetCard();
    }

    // Update is called once per frame
    void Update()
    {

        if (played)
        {
            this.GetComponent<MeshRenderer>().enabled = false;
            textMesh.GetComponent<MeshRenderer>().enabled = false;
        }
        if (drawed)
        {
            this.GetComponent<MeshRenderer>().enabled = true;
            textMesh.GetComponent<MeshRenderer>().enabled = true;
            drawed = false;
            played = false;

        }
        
        Vector3 updatePosition;
        if (clicked)
        {
            updatePosition = Vector3.SmoothDamp(this.transform.position, selectedPosition, ref currentVelocity, smoothTime);

        }
        else
        {
            updatePosition = Vector3.SmoothDamp(this.transform.position, startPosition, ref currentVelocity, smoothTime);
            
        }
        
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, updatePosition.z);
    }
    public static void SetGameData(GameData GameData)
    {
        CardComponent.Game = GameData;
    }
    public void DoAbility(Hex hex)
    {
        card.DoAction(hex);
        played = true;
        
    }

    public void SetCard()
    {
        
        card = SetRandomCard();
        //card.SetMap(hexMap);

        textMesh.text = card.Name;
    }
    public void SetCard(Card card)
    {

        this.card = card;
        //card.SetMap(hexMap);

        textMesh.text = card.Name;
    }
    public void SetSelectedPosition(Vector3 v)
    {
        this.selectedPosition = v;
    }

    public Vector3 GetStartPosition()
    {
        return this.startPosition;
    }

    private Card SetRandomCard()
    {
      
        return allCards[Random.Range(0,allCards.Length)];
        //return allCards[0];
    }

    public void RemoveFromHand()
    {
        Hand hand = HexMap.AllPlayers[Game.CurrentPlayer].hand;
        Debug.Log("Removing ");
        Debug.Log(hand.cards.Count);
        hand.cards.Remove(card);
        Debug.Log(hand.cards.Count);
    }
}
