using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game State
    int m_Level;

    enum Screen { MainMenu, Password, Win };
    Screen m_CurrentScreen = Screen.MainMenu;

    private void Start ()
    {
        ShowMainMenu();
    }

    private void OnUserInput (string input)
    {
        if (input.ToUpper() == "MENU")
        {
            ShowMainMenu();
        }

        if (m_CurrentScreen == Screen.MainMenu)
        {
            switch (input.ToUpper())
            {
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
    }

    private void StartGame()
    {
        m_CurrentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + m_Level);
        Terminal.WriteLine("Please enter your password: ");
    }

    private void ShowMainMenu ()
    {
        m_Level = 0;
        m_CurrentScreen = Screen.MainMenu;
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
