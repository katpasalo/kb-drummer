using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(BoxCollider2D))]

public abstract class MainMenuOption : MonoBehaviour
{
    public Canvas thoughtCanvas;
    public TMPro.TMP_Text textMeshPro;
    public Sprite thoughtActive;
    public Sprite thoughtPassive;
    public SpriteRenderer sr;

    public virtual string thoughtText{get;}

    void Awake()
    {
        thoughtCanvas.enabled = false;
        sr.enabled = false;
    }

    public virtual void Select() 
    {
        sr.sprite = thoughtPassive;
        textMeshPro.text = "Actually... no I'm not (maybe later!)";
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().gameObject.name == "Player")
        {
            sr.sprite = thoughtActive;
            thoughtCanvas.enabled = true;
            sr.enabled = true;
            textMeshPro.text = thoughtText;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trigger Exit");
        thoughtCanvas.enabled = false;
        sr.enabled = false;
    }
}