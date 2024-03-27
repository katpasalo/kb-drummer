using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuDrums : MainMenuOption
{
    public override string thoughtText
    {
        get {return "I'm in the mood for drums...";}
    }

    public override void Select()
    {
        SceneManager.LoadScene("Drums01");
    }
}
