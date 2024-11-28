/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 * Modifications for InterfaceLab 2020 to move a cube
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MyListener : MonoBehaviour
{

    CardPlace _card;

    

    void Start() // Start is called before the first frame update
    {
        _card = gameObject.GetComponent<CardPlace>();
    }
    void Update() // Update is called once per frame
    {
    }
    void OnMessageArrived(string msg)
    {
        //Debug.Log(msg);
        if(msg == "CARD READ")
        {
            _card.updatePlaceCard(true);
        }
        else if(msg == "Card removed")
        {
            _card.updatePlaceCard(false);
        }
        if(msg == "SELECT")
        {
            _card.PlaceCard();
            _card.Select();
        }

        if(msg == "Left" || msg == "right")
        {
            _card.move(msg);
        }

        if(msg == "DRAW COMPLETED")
        {
            _card.draw();
        }

        if(msg == "MOVE SLIDER")
        {
            _card.moveSlider = true;
        }

        if(msg == "deckButton SELECT")
        {
            _card.deckButton = true;
        }

        if(msg == "banishSelect SELECT")
        {
            _card.Reveal();
        }

        if(msg == "GRAVEYARD SELECT")
        {
            _card.startBattle();
        }
    }
    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }
}