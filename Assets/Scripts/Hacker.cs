using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    private void Start ()
    {
        ShowMainMenu();
    }

    private void OnUserInput (string input)
    {
        switch (input.ToUpper())
        {
            case "MENU":
                ShowMainMenu("Good to see you again");
                break;
            case "1":
                Terminal.WriteLine("You've chosen Elementary School");
                break;
            case "2":
                Terminal.WriteLine("You've chosen Middle School");
                break;
            case "3":
                Terminal.WriteLine("You've chosen High School");
                break;
            case "007":
                Terminal.WriteLine("Welcome Mr. Bond, please choose a level");
                break;
            case "GOD":
                Terminal.WriteLine("God Mode Active");
                break;
            default:
                Terminal.WriteLine("Invalid Input");
                break;
        }
    }

    private void ShowMainMenu ()
    {
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
