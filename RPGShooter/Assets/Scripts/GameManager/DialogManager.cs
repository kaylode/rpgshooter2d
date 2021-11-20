using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public int lettersPerSecond;

    public static DialogManager instance;
    private void Awake()
    {
        if (DialogManager.instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private Dialog currentDialog;
    private int currentLine = 0;

    public void ShowDialog(Dialog dialog)
    {
        GameManager.instance.FreezeAllMovement();
        if (CheckDialogFree())
        {
            this.currentDialog = dialog;
        }

        // Force a dialog to run all its lines , if not will raise this error
        if (!object.ReferenceEquals(this.currentDialog, dialog)){
            Debug.LogError("Dialog box error");
        }

        if (this.currentLine < this.currentDialog.Lines.Count)
        {
            this.dialogBox.SetActive(true);
            StartCoroutine(TypeDialog(this.currentDialog.Lines[this.currentLine]));
            this.currentLine++;
        }
        else
        {
            HideDialog();
            GameManager.instance.UnFreezeAllMovement();
        }
    }

    public void HideDialog()
    {
        this.dialogBox.SetActive(false);
        this.currentDialog = null;
        this.currentLine = 0;
    }

    public bool CheckDialogFree()
    {
        return (currentDialog == null);
    }

    public void RegisterDialog(Dialog dialog)
    {
        this.currentDialog = dialog;
        this.currentLine = 0;
    }

    public IEnumerator TypeDialog(string line)
    {
        dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / this.lettersPerSecond);
        }
    }
}
