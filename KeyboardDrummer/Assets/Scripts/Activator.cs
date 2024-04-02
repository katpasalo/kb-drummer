using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public KeyCode key;
    bool active = false;
    GameObject note;
    public Sprite ready;
    public Sprite pressed;

    void Update()
    {
        HandleKeyAnimation();
        if(Input.GetKeyDown(key) && active)
        {
            
            Destroy(note);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        active = true;
        if(col.gameObject.tag == "Note")
        {
            note = col.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        active = false;
    }

    void HandleKeyAnimation() {
        if (Input.GetKey(key))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = pressed;
            // play sound
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = ready;
        }
    }
}
