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

    // Start is called before the first frame update
    void Start()
    {
        battleLogic = GameObject.FindObjectOfType<battle>();
        cardPlace = GameObject.FindObjectOfType<CardPlace>();
        score = GameObject.FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (cardPlace.phase)
        {
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

        GetComponent<MeshRenderer>().material = newMat;
    }


    public void destroyCard()
    {
        Destroy(gameObject);
    }

    public void battle()
    {
        if(player == "Player")
        {
            if (battleLogic.enemyTypes.Contains(weakType))
            {
                destroyCard();
                score.updateScore("Enemy");
            }
        }

        if(player == "Enemy")
        {
            if (battleLogic.playerTypes.Contains(weakType))
            {
                destroyCard();
                score.updateScore("Player");
            }
        }
        
    }
}
