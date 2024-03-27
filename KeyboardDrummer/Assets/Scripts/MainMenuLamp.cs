using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class MainMenuLamp : MainMenuOption
{
    public override string thoughtText
    {
        get {return "I'm in the mood for a nap (quit)...";}
    }

    public override void Select()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}