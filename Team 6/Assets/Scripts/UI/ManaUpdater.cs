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
            "Name: {0}\n\n" +
            "Mana available: {1}\n",
            Game.GetCurrentPlayer().GetName(),
            Game.GetCurrentPlayer().GetMana());
    }
    public static void SetGameData(GameData GameData)
    {
        ManaUpdater.Game = GameData;
    }
}
