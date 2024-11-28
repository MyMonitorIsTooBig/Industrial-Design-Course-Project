using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battle : MonoBehaviour
{

    [SerializeField] enemySlots enemy;
    [SerializeField] playerSlots player;
    [SerializeField] CardPlace gameController;
    public List<int> enemyTypes = new List<int>();
    public List<int> playerTypes = new List<int>();

    List<GameObject> enemyCards = new List<GameObject>();
    List<GameObject> playerCards = new List<GameObject>();
    bool canAdd = true;

    bool reset = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameController.phase)
        {
            case 0:
                enemyTypes = new List<int>();
                playerTypes = new List<int>();
                break;
            case 6:
                if (canAdd)
                {

                    for (int i = 0; i < 3; i++)
                    {
                        if (enemy.checkSlots(i))
                        {
                            enemyTypes.Add(enemy.GetCardInSlot(i).GetComponent<Card>().type);
                            enemyCards.Add(enemy.GetCardInSlot(i));
                        }

                        if (player.checkSlots(i))
                        {
                            playerTypes.Add(player.GetCardInSlot(i).GetComponent<Card>().type);
                            playerCards.Add(player.GetCardInSlot(i));
                        }


                    }
                    canAdd = false;
                }
                break;
            case 7:
                canAdd = true;

                break;

        }
    }
    }   
