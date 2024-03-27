using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThoughtBubble : MonoBehaviour
{
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
            }

            if (collider.gameObject.name == "mic")
            {
               textMeshPro.text = "I'm in the mood to sing...";
            }

            if (collider.gameObject.name == "drumset")
            {
               textMeshPro.text = "I'm in the mood for drums...";
            }

            if (collider.gameObject.name == "guitar")
            {
               textMeshPro.text = "I'm in the mood for guitar...";
            }

            if (collider.gameObject.name == "lamp")
            {
               textMeshPro.text = "I'm in the mood for a nap... (quit)";
            }
        }
        
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        thoughtCanvas.enabled = false;
    }
}
