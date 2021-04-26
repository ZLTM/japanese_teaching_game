using UnityEngine;

public class MoveMenu : MonoBehaviour
{
    double destination = 0f;

    public GameObject KanjiInit;
    public GameObject TranslationInit;
    public GameObject DialogBoxInit;

    public GameObject Kanji;
    public GameObject Translation;
    public GameObject DialogBox;


    public void OpenKanji()
    {
        MovePanel(Kanji, KanjiInit, "x", -210, 0.1f);
    }

    public void OpenDialog()
    {
        MovePanel(DialogBox, DialogBoxInit, "y", 100, 0.1f);

        bool isActive = TranslationInit.activeSelf;
        if (isActive == true)
        {  
            OpenTranslation();
        }
    }

    public void OpenTranslation()
    {
        MovePanel(Translation, TranslationInit, "y", -340, 0.1f);
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
