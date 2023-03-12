using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardComponent : MonoBehaviour
{
    public static GameData Game;
    private Vector3 startPosition;
    private Vector3 selectedPosition;
    private Vector3 currentVelocity;
    private float smoothTime = .5f;

    public bool clicked;

    public Card card;

    private TextMesh textMesh;
    private MeshCollider meshCollider;

    // Start is called before the first frame update
    void Start()
    {
        this.startPosition = this.transform.position;
        this.selectedPosition = startPosition + new Vector3(0, 0, .5f);
        textMesh = this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMesh>();
        meshCollider = this.transform.GetChild(0).GetChild(0).GetComponent<MeshCollider>();
        meshCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
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

    public void SetCardIsVisible(bool toggle)
    {
        MeshRenderer[] meshes = this.GetComponentsInChildren<MeshRenderer>();

        meshCollider.enabled = toggle;

        foreach (MeshRenderer mesh in meshes)
        {
            mesh.enabled = meshCollider.enabled;
        }
    }

    public void DoAbility(Hex hex)
    {
        card.DoAction(hex);
    }

    public void SetCardText(Card card)
    {
        this.card = card;
        textMesh.text = card.Name + "\nOwner: " + Game.GetCurrentPlayer().GetName();
    }
    public void RemoveCard(CardComponent cardComponent)
    {
        this.transform.parent.GetComponent<HandComponent>().RemoveCard(cardComponent);
    }
    public void SetSelectedPosition(Vector3 v)
    {
        this.selectedPosition = v;
    }
    public Vector3 GetStartPosition()
    {
        return this.startPosition;
    }
}
