using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComponent : MonoBehaviour
{
    public static Game game;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject Player1 = new PlayerObject();
        PlayerObject Player2 = new PlayerObject();
        game.Players[game.ActivePlayerIndex] = Player1;
        game.Players[game.ActivePlayerIndex + 1] = Player2;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DealHands()
    {
        foreach (PlayerObject player in game.Players)
        {
            if (player != null)
            {
                player.hand.DrawNewHand(player.hand);
            }
        }
    }
    public void AdvanceTurn()
    {
        game.ActivePlayerIndex += 1;
        if (game.ActivePlayerIndex > game.PlayerCount)
        {
            game.ActivePlayerIndex = 0;
        }
    }
}
