using UnityEngine;
using TMPro;

public class UIScoreBoard : MonoBehaviour
{
    public TMP_Text scoreField;
    public TMP_Text multiplierField;


    private void Start()
    {
        ComboSystem.OnScoreChange += UpdateUI;          //Luister naar bericht en voer dan de functie UpdateUI uit
    }
    private void OnDisable()
    {
        ComboSystem.OnScoreChange -= UpdateUI;          //Stop met luisteren
    }
    private void UpdateUI(int score, int multiplier)    //ontvang de score en de multiplier uit het bericht
    {
        scoreField.text = "Score: " + score; //de text in het textveld (TMP_Text component) van de score aanpassen.
        multiplierField.text = "Multiplier: " + multiplier + "X"; //de text in het textveld (TMP_Text component) van de multiplier aanpassen.
    }
}