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

    private float shrinkSpeed = .9f;

    public Card card;

    [SerializeField] HexMap hexMap;
    private TextMesh textMesh;

    public int HandPostion;




    public void Hide()
    {
        this.gameObject.GetComponent<MeshCollider>().enabled = false;
        MeshRenderer[] meshs = this.gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach(MeshRenderer mesh in meshs)
        {
            mesh.enabled = false;
        }
    }
    public void Show()
    {
        this.gameObject.GetComponent<MeshCollider>().enabled = true;

        MeshRenderer[] meshs = this.gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mesh in meshs)
        {
            mesh.enabled = false;
        }
        drawed = true;
}

    // Start is called before the first frame update
    void Start()
    {
        this.startPosition = this.transform.position;
        this.selectedPosition = startPosition + new Vector3(0, 0, .5f);
        textMesh = this.gameObject.GetComponentInChildren<TextMesh>();

        //card = setRandomCard();
        

        //setCard();
        played = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (played)
        {
            this.GetComponent<MeshRenderer>().enabled = false;
            textMesh.GetComponent<MeshRenderer>().enabled = false;
            /*
            if (this.gameObject.transform.localScale.magnitude < .1f)
            {
                //Destroy(this.gameObject.transform.parent.gameObject);
                this.GetComponent<MeshRenderer>().enabled = false;
                textMesh.GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                this.gameObject.transform.parent.transform.localScale *= shrinkSpeed;
            }
            */
        }
        if (drawed)
        {

            //this.gameObject.transform.parent.transform.localScale = new Vector3(1,1,1);

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

        HexMap.GetCurrentPlayer().currentMana -= card.ManaCost;
        
    }

    

    public void setCard(Card card)
    {
        this.card = card;

        
        

        textMesh.text = card.name;
    }

    public void setSelectedPosition(Vector3 v)
    {
        this.selectedPosition = v;
    }

    public Vector3 getStartPosition()
    {
        return this.startPosition;
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
