using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //game configuration data
    const string menuHint = "You can type menu to start over.";
    string[] level1Passwords = {"math", "desk", "list", "code", "teach"};
    string[] level2Passwords = {"testing", "games", "player", "shift", "question"};
    string[] level3Passwords = {"working", "salary", "schedule", "references", "vacations"};


    // game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("Hello Franck!");
    }


    void ShowMainMenu(string greeting)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Where would you like to hack into?");
        Terminal.WriteLine("Press 1 to enter the school.");
        Terminal.WriteLine("Press 2 to enter the interview office.");
        Terminal.WriteLine("Press 3 to enter the job office.");
        Terminal.WriteLine("Please enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") //So we can go back to the main menu
        {
            Start();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("If on the web, close tab.");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

     void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == " ") //easter egg
        {
            Terminal.WriteLine("Congratulations! You are in!");
        }
        else
        {
            Terminal.WriteLine("You have to choose between 1, 2, 3 or menu.");
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Here's a ASCII school as a reward!");
                Terminal.WriteLine(@"
          /_\
          |Q|
    .-----' '-----.             __
   /____[SCHOOL]___\           ()))
    | [] .-.-. [] |           (((())
  ..|____|_|_|____|.............)(...
                ");
                Terminal.WriteLine(menuHint);
                break;
            case 2:
                Terminal.WriteLine("You get the job! Now shake my hand");
                Terminal.WriteLine("Try number 3 for a greater challenge!");
                Terminal.WriteLine(@"
    _______
---'   ____)____
          ______)
          _______)
         _______)
---.__________)
                ");
                Terminal.WriteLine(menuHint);
                break;
            case 3:
                Terminal.WriteLine("You found the password! Have a computer");
                Terminal.WriteLine(@"
   .----.
   |C>_ |
 __|____|__
|  ______--|
`-/.::::.\-'
 `--------'
                ");
                Terminal.WriteLine(menuHint);
                break;
            default:
                Debug.LogError("Invalid Level reached.");
                break;
        }
    }

    // Update is called once per frame
    /*  void Update()
  {

  }*/
}
