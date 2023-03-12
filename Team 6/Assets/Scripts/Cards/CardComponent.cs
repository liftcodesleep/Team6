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
    private MeshCollider meshCollider;


    // Start is called before the first frame update
    void Start()
    {
        this.startPosition = this.transform.position;
        this.selectedPosition = startPosition + new Vector3(0, 0, .5f);
        textMesh = this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMesh>();
        meshCollider = this.transform.GetChild(0).GetChild(0).GetComponent<MeshCollider>();
        card = SetRandomCard();
        

        SetCard();
    }

    // Update is called once per frame
    void Update()
    {

        if (played)
        {
            this.transform.GetChild(0).GetChild(0).GetComponent<MeshCollider>().enabled = false;
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

    public void ToggleCardMeshesVisible()
    {
        MeshRenderer[] meshes = this.GetComponentsInChildren<MeshRenderer>();

        //MeshRenderer[] meshes = this.transform.Find("Card/Model").GetComponentsInChildren<MeshRenderer>();

        meshCollider.enabled = meshCollider.enabled ? false : true;

        //meshCollider.enabled = toggle;

        foreach (MeshRenderer mesh in meshes)
        {
            mesh.enabled = meshCollider.enabled;
        }
    }
    /*
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
    */

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
    public void RemoveCard(CardComponent cardComponent)
    {
        if(cardComponent == null)
        {
            return;
        }
        Debug.Log("Removing: " + cardComponent);
        Debug.Log("From: " + this.transform.parent);
        this.transform.parent.GetComponent<HandComponent>().RemoveCard(cardComponent);
        //this.gameObject.transform.Find("MainCamera/Hand").gameObject.GetComponent<HandComponent>().RemoveCard(cardComponent);

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
      
        return GameData.AllCards[Random.Range(0, GameData.AllCards.Length)];
        //return allCards[0];
    }
}
