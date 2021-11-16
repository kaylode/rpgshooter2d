using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FloatingTextManager : MonoBehaviour
    /*
     * Observer Design Pattern
     */
{

    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = this.GetFloatingText();
        floatingText.Set(msg, fontSize, color, position, motion, duration);
        floatingText.Show();
    }

    private FloatingText GetFloatingText()
    {
        FloatingText txt = floatingTexts.Find(t => !t.active);

        if (txt == null)
        {
            txt = new FloatingText();
            txt.go = Instantiate(this.textPrefab);
            txt.go.transform.SetParent(this.textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();

            floatingTexts.Add(txt);
        }
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
