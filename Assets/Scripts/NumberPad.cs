using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberPad : MonoBehaviour
{
    string code = "1442";
    public int isOccupied;
    bool correct;
    [SerializeField] GameObject keyCard;
    [SerializeField] TextMeshProUGUI inputText;
    [SerializeField] TextMeshProUGUI correctText;
    // Start is called before the first frame update
    void Start()
    {
        isOccupied = 0;
        inputText.text = "";
        correct = false;
    }
    public void UpdateAndCheck(char number)
    {
        if (!correct)
        {
            inputText.text += number;
            if (inputText.text.Length == code.Length)
            {
                if (inputText.text == code)
                {
                    correct = true;
                    correctText.gameObject.SetActive(true);
                    SpawnKeyCard();
                }
                else
                    inputText.text = "";
            }
        }
    }
    void SpawnKeyCard()
    {
        keyCard.SetActive(true);
    }
}
