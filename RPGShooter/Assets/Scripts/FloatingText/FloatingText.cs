using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FloatingText : MonoBehaviour
{

    public bool active;
    public GameObject go; // Attach gameObject
    public Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;


    
    public void Set(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        this.txt.text = msg;
        this.txt.fontSize = fontSize;
        this.txt.color = color;
        this.motion = motion;
        this.duration = duration;
        this.go.transform.position = position;
    }

    public void Show()
    {
        this.active = true;
        this.lastShown = Time.time;
    }

    public void Hide()
    {
        this.active = false;
        Destroy(this.go);
    }

    public void UpdateFloatingText()
    {
        if (!this.active)
            return;
        
        if (this.duration > 0)
        {
            if (Time.time - this.lastShown > this.duration)
                this.Hide();
        }

        this.go.transform.position += this.motion * Time.deltaTime;
        
    }
}
