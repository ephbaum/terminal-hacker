using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game State
    int m_Level;
    string m_Password;

    enum Screen { MainMenu, Password, Win };
    Screen m_CurrentScreen = Screen.MainMenu;

    // Level Word Arrays
    readonly string[] m_ElementarySchoolWords = { "easy", "safe", "double", "study", "think" };
    readonly string[] m_MiddleSchoolWords = { "challenge", "expected", "anagram", "instruct", "decision" };
    readonly string[] m_HighSchoolWords = { "apparition", "capitulate", "necessitated", "indicitive", "parliamentarian" };

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
        else if (m_CurrentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (m_CurrentScreen == Screen.Password)
        {
            CheckGuess(input);
        }
        else if (m_CurrentScreen == Screen.Win)
        {
            ShowMainMenu();
        }
    }

    private void RunMainMenu (string input)
    {
        switch (input.ToUpper())
        {
            case "1":
            case "2":
            case "3":
                m_Level = int.Parse(input);
                SetRandomPassword();
                RequestPassword();
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

    private void RequestPassword ()
    {
        m_CurrentScreen = Screen.Password;

        Terminal.ClearScreen();
        Terminal.WriteLine("Enter password, hint: " + m_Password.Anagram());

        // @TODO Remove onscreen debugging
        Terminal.WriteLine(m_Password);
    }

    private void SetRandomPassword ()
    {
        System.Random rnd = new System.Random();
        int index;

        switch (m_Level)
        {
            case 1: // Elementary School Level
                index = rnd.Next(1, m_ElementarySchoolWords.Length);
                m_Password = m_ElementarySchoolWords[index];
                break;
            case 2: // Middle School Level
                index = rnd.Next(1, m_MiddleSchoolWords.Length);
                m_Password = m_MiddleSchoolWords[index];
                break;
            case 3: // High School Level
                index = rnd.Next(1, m_HighSchoolWords.Length);
                m_Password = m_HighSchoolWords[index];
                break;
            default:
                m_Password = null;
                Debug.LogError("SetRandomPassword m_Level invalid state: " + m_Level);
                break;
        }
    }

    private void CheckGuess(string guess)
    {
        if (guess.ToUpper() == m_Password.ToUpper())
        {
            DisplayWinScreen();
        }
        else
        {
            RequestPassword();
        }
    }

    private void DisplayWinScreen ()
    {
        m_CurrentScreen = Screen.Win;

        Terminal.ClearScreen();
        Terminal.WriteLine("Access Granted!");
        GenerateWinScreenContent();
    }

    private void GenerateWinScreenContent ()
    {
        string reward = "      _,                _.\n     (  `)            (`  ).\n  .=( ` ,_ `)    .-``(      ).\n (.__.:-`-_.'   (.,,(.       '`.\n                      `--`--`'`\n         ____.........__H_\n      __/%%%%|%%%%%%%|%%%%\\\n _ ()/%%|:II:|II:::II|:II:|_ _ _\n|-(()|--|:II:|II:H:II|:II:|-|-|-|\n`'.'\"^  ^` \"^ \"^|\"|^'\"' `^`-.^~'";

        switch (m_Level)
        {
            case 1:
                reward += "\n\nTry Middle School for more challenge!";
                break;
            case 2:
                reward += "\n\nTry High School for more challenge!";
                break;
            case 3:
                reward += "\n\nYou are a smart cookie!";
                break;
            default:
                reward = "Game broken, sorry.";
                Debug.LogError("GenerateWarningScreenContent invalid m_Level state: " + m_Level);
                break;
        }
        Terminal.WriteLine(reward);
    }

    private void ShowMainMenu ()
    {
        m_Level = 0;
        m_Password = null;
        m_CurrentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to the WM2000 Learning Terminal");
        Terminal.WriteLine("");
        Terminal.WriteLine("Select school system to hack:");
        Terminal.WriteLine("Enter 1 for Elementary School");
        Terminal.WriteLine("Enter 2 for Middle School");
        Terminal.WriteLine("Enter 3 for High School");
        Terminal.WriteLine("Type menu any time to start over.");
        Terminal.WriteLine("Selection: ");
    }
}
