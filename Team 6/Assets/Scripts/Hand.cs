using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3[] positions;
    [SerializeField] GameObject card;
    GameObject[] cards;
    void Start()
    {

        int amountOfCards = this.transform.childCount;
        positions = new Vector3[amountOfCards];

        cards = new GameObject[amountOfCards];
        for (int cardIndex = 0; cardIndex < amountOfCards; cardIndex++)
        {
            positions[cardIndex] = this.transform.GetChild(cardIndex).gameObject.transform.position;
            cards[cardIndex] = this.transform.GetChild(cardIndex).gameObject;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawNewHand()
    {
        /*
        foreach(Vector3 cardPosition in positions)
        {
            Instantiate(card, card.transform.position, card.transform.rotation,this.gameObject.transform);
        }
        */
        foreach (GameObject card in cards)
        {
            card.GetComponentInChildren<CardComponent>().setCard();
            card.GetComponentInChildren<CardComponent>().drawed = true;
        }

    }


}
