using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMngr : MonoBehaviour
{
    public enum Choice
    {
        Rock,
        Paper,
        Scissors
    }


    public string previousOption = "";
    public void UpdateUserOption(string option)
    {
        if (option != previousOption)
        {
            if (option == "OK" || option == "Pointer")
            {
            option = "";
            }
            Debug.Log($"Received option: {option}");
            previousOption = option;
        }
    }

    public Choice playerChoice;
    public Choice cpuChoice;

    public void PlayGame()
    {
        if (previousOption=="") 
        {
            Debug.Log("Player choice is empty");
        }
        else
        {
        cpuChoice = (Choice)Random.Range(0, 3);

        playerChoice = (Choice)System.Enum.Parse(typeof(Choice), previousOption);
        DetermineWinner();
        }
        }

    private void DetermineWinner()
    {
        if (playerChoice == cpuChoice)
        {
            Debug.Log("It's a tie!");
        }
        else if ((playerChoice == Choice.Rock && cpuChoice == Choice.Scissors) ||
                 (playerChoice == Choice.Paper && cpuChoice == Choice.Rock) ||
                 (playerChoice == Choice.Scissors && cpuChoice == Choice.Paper))
        {
            Debug.Log("Player wins!");
        }
        else
        {
            Debug.Log("CPU wins!");
        }
    }
}
