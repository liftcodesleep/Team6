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

        card = setRandomCard();
        

        setCard();
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

    public void DoAbility(Hex hex)
    {
        card.DoAction(hex);
        played = true;
        
    }

    public void setCard()
    {
        
        card = setRandomCard();
        //card.setMap(hexMap);

        textMesh.text = card.Name;
    }
    public void setCard(Card card)
    {

        this.card = card;
        //card.setMap(hexMap);

        textMesh.text = card.Name;
    }
    public void setSelectedPosition(Vector3 v)
    {
        this.selectedPosition = v;
    }

    public Vector3 getStartPosition()
    {
        return this.startPosition;
    }

    private Card setRandomCard()
    {
      
        return allCards[Random.Range(0,allCards.Length)];
        //return allCards[0];
    }

    public void RemoveFromHand()
    {
        Hand hand = HexMap.AllPlayers[HexMap.currentPlayer].hand;
        Debug.Log("Removing ");
        Debug.Log(hand.cards.Count);
        hand.cards.Remove(card);
        Debug.Log(hand.cards.Count);
    }
}
