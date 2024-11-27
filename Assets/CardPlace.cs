using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardPlace : MonoBehaviour
{

    [SerializeField] playerSlots _playerSlots;
    bool _placeCard { get; set; } = false;
    bool cardPlaced { get; set; } = false;
    MeshRenderer mesh;

    int _handNum = 0;

    public int phase = 0;

    public bool deckButton = false;

    public bool moveSlider = false;

    [SerializeField]TextMeshProUGUI infoText;
    [SerializeField]TextMeshProUGUI secondInfoText;


    [SerializeField] List<GameObject> cards = new List<GameObject>();
    [SerializeField] List<Transform> handTransforms = new List<Transform>();
    [SerializeField] List<Transform> boardTransforms = new List<Transform>();
    [SerializeField] List<GameObject> currentCards = new List<GameObject>();



    int cardSelectPos = 0;

    [SerializeField] GameObject selectedIcon;

    [SerializeField] List<GameObject> physicalCards = new List<GameObject>();


    float timeUntilNextSelectChange = 0.25f;
    float currentTimeSelected = 0.0f;
    bool checkSelectTime = false;

    GameObject selectedCard;
    GameObject selectedPhysicalCard;



    // Start is called before the first frame update
    void Start()
    {
        mesh = gameObject.GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (phase)
        {
            case 0:
                infoText.text = "Press The DECK Button To Initiate the Draw Phase!";
                if (moveSlider)
                {
                    secondInfoText.text = "Make sure that the slider is at the top before entering the draw phase!";
                }
                if (deckButton)
                {
                    moveSlider = false;
                    infoText.text = "OK! Now slide the slider all the way to the bottom, then back up again to complete the draw phase!";
                    secondInfoText.text = " ";
                }

                break;
            case 1:
                infoText.text = "Great! Now use the joystick to choose a card then hit the SELECT button to select it";
                selectedIcon.transform.position = handTransforms[cardSelectPos].position;
                break;
            case 2:
                infoText.text = "Epic! Now that you have a card selected, use the joystick to choose an open slot to place this card. To lock in the selection, grab the physical blank card and SLAM it onto the card pedestal located on the controller.";
                //selectedCard.transform.position = boardTransforms[cardSelectPos].position;
                if(selectedPhysicalCard != null)
                {
                    selectedPhysicalCard.transform.position = boardTransforms[cardSelectPos].position + new Vector3(0, 0.1f, 0);
                }

                break;
            case 3:
                infoText.text = "Press the SELECT button to move finish your turn!";
                break;
            case 4:
                infoText.text = "Now the enemy will place down their card, press the REVEAL button to initate the BATTLE phase";
                break;
            case 5:

                break;
            case 6:
                infoText.text = "The battle phase has now begun! You can see the placed cards, press the BATTLE button to finish the battle phase!";

                break;
        }


        if (checkSelectTime)
        {
            if(currentTimeSelected < timeUntilNextSelectChange)
            {
                currentTimeSelected += Time.deltaTime;
            }
            else
            {
                currentTimeSelected = 0.0f;
                checkSelectTime = false;
            }
        }

    }

    public void updatePlaceCard(bool newState)
    {
        if(phase == 2)
        {
            _placeCard = newState;

            //phase++;




            if (!_playerSlots.checkSlots(cardSelectPos))
            {
                _playerSlots.updateSlots(cardSelectPos, selectedPhysicalCard);
                selectedPhysicalCard = null;
                phase++;
            }

        }
       
    }

    bool getPlaceCard()
    {
        return _placeCard;
    }

    public void PlaceCard()
    {

        switch (phase)
        {
            case 1:
                if(currentCards.Count >= cardSelectPos + 1)
                {
                    Debug.Log("Can select current card!");
                    selectedCard = currentCards[cardSelectPos].gameObject;

                    selectedPhysicalCard = Instantiate(physicalCards[selectedCard.GetComponent<Card>().type], boardTransforms[cardSelectPos].position + new Vector3(0,0.1f,0), Quaternion.identity);

                    currentCards.RemoveAt(cardSelectPos);
                    selectedCard.GetComponent<Card>().destroyCard();
                    


                    UpdateHandCardPlacements();


                    cardSelectPos = 0;
                    phase++;


                }
                break;
        }


    }


    void UpdateHandCardPlacements()
    {
        for (int i = 0; i < currentCards.Count; i++)
        {
            currentCards[i].transform.position = handTransforms[i].position;
        }
    }

    void RemoveCard()
    {
        if (_placeCard)
        {
            cardPlaced = false;
            mesh.enabled = false;
        }
    }


    public void move(string dir)
    {
        //Debug.Log(cardSelectPos);
        switch (phase)
        {
            case 1:
                switch (dir)
                {
                    case "Left":
                        if (currentTimeSelected == 0.0f)
                        {

                            cardSelectPos++;
                            checkSelectTime = true;

                        }
                        break;
                    case "right":
                        if (currentTimeSelected == 0.0f)
                        {
                           
                            cardSelectPos--;
                            checkSelectTime = true;
                        }
                        break;
                }
                break;
            case 2:
                switch (dir)
                {
                    case "Left":
                        if (currentTimeSelected == 0.0f)
                        {

                            cardSelectPos++;
                            checkSelectTime = true;

                        }
                        break;
                    case "right":
                        if (currentTimeSelected == 0.0f)
                        {

                            cardSelectPos--;
                            checkSelectTime = true;
                        }
                        break;
                }
                break;
        }

        if(cardSelectPos == 3)
        {
            cardSelectPos = 0;
        }
        if(cardSelectPos == -1)
        {
            cardSelectPos = 2;
        }

    }


    public void draw()
    {
        deckButton = false;
        _handNum++;

        int randomNum = Random.Range(0, cards.Count);

        currentCards.Add(Instantiate(cards[randomNum], handTransforms[randomNum]));

        phase++;
    }


    public void Select()
    {
        if(phase == 3)
        {
            phase++;
        }
    }

    public void Reveal()
    {
        if(phase == 5)
        {
            phase++;
        }
    }

    public void startBattle()
    {
        
        if (phase == 6)
        {
            if (currentTimeSelected == 0.0f)
            {
                phase++;
                checkSelectTime = true;
            }
        }
        
        if(phase == 8)
        {
            if (currentTimeSelected == 0.0f)
            {
                //phase = 0;
                checkSelectTime = true;
            }
        }
    }
}
