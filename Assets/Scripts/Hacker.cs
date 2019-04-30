using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game State
    int m_Level;

    private void Start ()
    {
        ShowMainMenu();
    }

    private void OnUserInput (string input)
    {
        switch (input.ToUpper())
        {
            case "MENU":
                ShowMainMenu();
                break;
            case "1":
            case "2":
            case "3":
                m_Level = Int32.Parse(input);
                StartGame();
                break;
            case "007":
                Terminal.WriteLine("Welcome Mr. Bond, please choose a level");
                break;
            case "GOD":
                Terminal.WriteLine("God Mode Activated");
                break;
            default:
                Terminal.WriteLine("Invalid Input");
                break;
        }
    }

    private void StartGame()
    {
        Terminal.WriteLine("You have chosen level " + m_Level);
    }

    private void ShowMainMenu ()
    {
        m_Level = 0;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to the WM2000 Learning Terminal");
        Terminal.WriteLine("");
        Terminal.WriteLine("Select school system to hack:");
        Terminal.WriteLine("Enter 1 for Elementary School");
        Terminal.WriteLine("Enter 2 for Middle School");
        Terminal.WriteLine("Enter 3 for High School");
        Terminal.WriteLine("");
        Terminal.WriteLine("Selection: ");
    }
}
