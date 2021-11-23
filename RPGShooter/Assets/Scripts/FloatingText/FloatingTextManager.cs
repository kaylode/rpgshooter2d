using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FloatingTextManager : MonoBehaviour
{
    //public static FloatingTextManager instance;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();

    public FloatingText Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = this.GetFloatingText();
        floatingText.Set(msg, fontSize, color, position, motion, duration);
        floatingText.Show();
        return floatingText;
    }

    private FloatingText GetFloatingText()
    {
        FloatingText txt = new FloatingText();
        txt.go = Instantiate(this.textPrefab, this.transform);
        txt.txt = txt.go.GetComponent<Text>();
        floatingTexts.Add(txt);
        return txt;
    }

    private void Update()
    {
        foreach (FloatingText txt in this.floatingTexts)
        {
            txt.UpdateFloatingText();
        }
    }
}
