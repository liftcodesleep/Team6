using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaUpdater : MonoBehaviour
{
    public static GameData Game;
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
            "Your Mana: {1}\n",
            Game.GetCurrentPlayer().GetName(),
            Game.GetCurrentPlayer().GetMana());
    }
    public static void SetGameData(GameData GameData)
    {
        ManaUpdater.Game = GameData;
    }
}
