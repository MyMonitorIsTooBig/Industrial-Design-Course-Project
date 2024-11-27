using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSlots : MonoBehaviour
{
    public bool slot1;
    public bool slot2;
    public bool slot3;


    GameObject slot1Card;
    GameObject slot2Card;
    GameObject slot3Card;


    [SerializeField] List<Transform> boardTransforms = new List<Transform>();



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void updateSlots(int slotNum, GameObject card)
    {

        card.transform.position = boardTransforms[slotNum].position + new Vector3(0, 0.1f, 0);

        if (slotNum == 0)
        {
            slot1Card = card;
            slot1 = true;
        }
        else if(slotNum == 1)
        {
            slot2Card = card;
            slot2 = true;
        }
        else if(slotNum == 2)
        {
            slot3Card = card;
            slot3 = true;
        }

        

    }

    public bool checkSlots(int slot)
    {
        if(slot == 0)
        {
            return slot1;
        }
        else if(slot == 1)
        {
            return slot2;
        }
        else if(slot == 2)
        {
            return slot3;
        }
        return false;
    }

    public void deleteCard(int slot)
    {
        if(slot == 0 && slot1)
        {
            Destroy(slot1Card);
            slot1 = false;
        }
        else if (slot == 1 && slot2)
        {
            Destroy(slot2Card);
            slot2 = false;
        }
        else if (slot == 2 && slot3)
        {
            Destroy(slot3Card);
            slot3 = false;
        }
    }

    public GameObject GetCardInSlot(int slot)
    {
        if (slot == 0)
        {
            return slot1Card;
        }
        else if (slot == 1)
        {
            return slot2Card;
        }
        else if (slot == 2)
        {
            return slot3Card;
        }

        return null;
    }

}
