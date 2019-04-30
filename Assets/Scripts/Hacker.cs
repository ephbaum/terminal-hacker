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
        m_CurrentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + m_Level);
        Terminal.WriteLine("Please enter your password: ");

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
                break;
        }
        // @TODO Remove onscreen debugging
        Terminal.WriteLine(m_Password);
    }

    private void CheckGuess(string guess)
    {
        if (guess.ToUpper() == m_Password.ToUpper())
        {
            // @TODO Win State
            m_CurrentScreen = Screen.Win;
            Terminal.WriteLine("Access Granted!");
            Terminal.WriteLine("Win State Entered");
        }
        else
        {
            // @TODO Improve and remoe debugging
            Terminal.WriteLine("Does not match " + m_Password);
            Terminal.WriteLine("Incorrect, try again: ");
        }
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
        Terminal.WriteLine("");
        Terminal.WriteLine("Selection: ");
    }
}
