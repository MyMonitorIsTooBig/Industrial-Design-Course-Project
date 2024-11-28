using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int type;
    [SerializeField] string player;
    public int weakType;
    [SerializeField] GameObject cardFace;
    battle battleLogic;

    CardPlace cardPlace;

    Score score;

    [SerializeField] Material newMat;

    playerSlots _playerSlots;
    enemySlots _enemySlots;

    bool placed = false;

    public int slot = 0;
    // Start is called before the first frame update
    void Start()
    {
        battleLogic = GameObject.FindObjectOfType<battle>();
        cardPlace = GameObject.FindObjectOfType<CardPlace>();
        score = GameObject.FindObjectOfType<Score>();
        _playerSlots = FindObjectOfType<playerSlots>();
        _enemySlots = FindObjectOfType<enemySlots>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (cardPlace.phase)
        {
            case 2:
                if(player == "Player")
                {
                    if (!placed)
                    {
                        slot = cardPlace.cardSelectPos;
                    }
                }
                break;
            case 3:
                placed = true;
                break;
            case 6:
                revealCard();
                break;
            case 7:
                battle();
                break;
        }
    }

    void revealCard()
    {
        //cardFace.SetActive(true);
        if(player != "HAND")
        {
            GetComponent<MeshRenderer>().material = newMat;
        }
    }


    public void destroyCard()
    {
        //Destroy(gameObject);
        if(player == "Player")
        {
            _playerSlots.deleteCard(slot);
        }
        if(player == "Enemy")
        {
            _enemySlots.deleteCard(slot);
        }
    }

    public void battle()
    {
        if(player == "Player")
        {
            if (battleLogic.enemyTypes.Contains(weakType))
            {
                Debug.Log("I am ded and my type: " + type);
                destroyCard();
                score.updateScore("Enemy");
            }
        }

        if(player == "Enemy")
        {
            if (battleLogic.playerTypes.Contains(weakType))
            {
                Debug.Log("I am ded and my type: " + type);
                destroyCard();
                score.updateScore("Player");
            }
        }
        
    }
}
