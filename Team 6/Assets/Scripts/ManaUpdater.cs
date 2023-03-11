using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaUpdater : MonoBehaviour
{
    public GameData GameData;
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
            GameData.GetCurrentPlayer().Name,
            GameData.GetCurrentPlayer().currentMana);
    }
}
