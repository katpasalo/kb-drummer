using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private KeyCode selectKey = KeyCode.Return;


    public Canvas thoughtCanvas;
    public TMPro.TMP_Text textMeshPro;

    void Awake()
    {
        thoughtCanvas.enabled = false;
    }


    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Interactable")
        {
            thoughtCanvas.enabled = true;

            if (collider.gameObject.name == "keyboard")
            {
                textMeshPro.text = "I'm in the mood for piano...";
                if(Input.GetKeyDown(selectKey))
                {
                    ShowUnavailable();
                }
            }

            if (collider.gameObject.name == "mic")
            {
                textMeshPro.text = "I'm in the mood to sing...";
                if(Input.GetKeyDown(selectKey))
                {
                    ShowUnavailable();
                }
            }

            if (collider.gameObject.name == "drumset")
            {
                textMeshPro.text = "I'm in the mood for drums...";
                if(Input.GetKeyDown(selectKey))
                {
                    PlayDrums();
                }
            }

            if (collider.gameObject.name == "guitar")
            {
                textMeshPro.text = "I'm in the mood for guitar...";
                if(Input.GetKeyDown(selectKey))
                {
                    ShowUnavailable();
                }
            }

            if (collider.gameObject.name == "lamp")
            {
                textMeshPro.text = "I'm in the mood for a nap... (quit)";
                if(Input.GetKeyDown(selectKey))
                {
                    ShowUnavailable();
                }
            }
        }
        
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        thoughtCanvas.enabled = false;
    }

    public void PlayDrums()
    {
        SceneManager.LoadScene("Drums01");
    }

    private void ShowUnavailable()
    {
        textMeshPro.text = "Actually... no I'm not (maybe later!)";
    }
}