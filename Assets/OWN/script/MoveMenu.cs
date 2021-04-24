using UnityEngine;

public class MoveMenu : MonoBehaviour
{
    double destination = 0f;

    public GameObject KanaInit;
    public GameObject TranslationInit;
    public GameObject DialogBoxInit;

    public GameObject Kana;
    public GameObject Translation;
    public GameObject DialogBox;


    public void OpenKana(string order)
    {
        MovePanel(Kana, KanaInit, "x", -210, 0.1f);
    }

    public void OpenDialog()
    {
        MovePanel(DialogBox, DialogBoxInit, "y", 100, 0.1f);
    }

    public void OpenTranslation(string order)
    {
        MovePanel(Translation, TranslationInit, "y", -300, 0.1f);
    }

    public void MovePanel(GameObject Panel, GameObject Initialiter, string Direction, int Pixels, float Speed)
    {
        bool isActive = Initialiter.activeSelf;
        if (isActive == false)
        {  
            Initialiter.SetActive(true);
            destination = Pixels;
            iTween.MoveBy(Panel, iTween.Hash(Direction, destination, "easeType", "easeOutExpo", "delay", Speed));
        }
        else
        {
            Initialiter.SetActive(false);
            destination = -Pixels;
            iTween.MoveBy(Panel, iTween.Hash(Direction, destination, "easeType", "easeOutExpo", "delay", Speed));
        }
    }
}
