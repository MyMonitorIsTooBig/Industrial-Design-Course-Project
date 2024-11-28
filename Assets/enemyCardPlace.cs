using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemyCardPlace : MonoBehaviour
{
    [SerializeField] CardPlace _playerCardPlace;
    [SerializeField] enemySlots _slots;
    int phase;

    [SerializeField] List<Transform> cardSlots = new List<Transform>();
    [SerializeField] List<GameObject> physicalCards = new List<GameObject>();

    GameObject selectedPhysicalCard;

    List<int> cards = new List<int>();


    bool canPopulate = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        phase = _playerCardPlace.phase;

        switch (phase)
        {
            case 0:
                
                break;
            case 1:

                break;
            case 2:

                break;
            case 4:
                populate();
                int rand = Random.Range(0,3);
                if (!_slots.checkSlots(rand))
                {
                    _slots.updateSlots(rand, selectedPhysicalCard);
                    selectedPhysicalCard.transform.position = cardSlots[rand].position + new Vector3(0,0.1f,0);
                    selectedPhysicalCard.GetComponent<Card>().slot = rand;
                    canPopulate = true;
                    _playerCardPlace.phase++;
                }
                
                break;
        }
    }

    void populate()
    {
        if (canPopulate)
        {
            int rand = Random.Range(0, 3);
            cards.Add(rand);

            int rand2 = Random.Range(0, cards.Count);
            selectedPhysicalCard = Instantiate(physicalCards[rand2]);
            canPopulate = false;
        }
    }

}
