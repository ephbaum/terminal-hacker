using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start ()
    {
        ShowMainMenu("Hello Ben");
    }

    // Update is called once per frame
    private void Update ()
    {
        
    }

    private void ShowMainMenu (string greeting)
    {
        Terminal.ClearScreen();

        Terminal.WriteLine(greeting);

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
