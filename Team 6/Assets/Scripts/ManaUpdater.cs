using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaUpdater : MonoBehaviour
{
    public GameData Game;
    TMPro.TextMeshProUGUI text;
    void Start()
    {
        text = this.GetComponentInChildren<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        text.text = string.Format(
            "{0}\n" +
            "Your Mana: {1}",
            Game.AllPlayers[Game.GetCurrentPlayer()].playerData.GetName(),
            Game.AllPlayers[Game.GetCurrentPlayer()].playerData.GetMana());
    }
}
