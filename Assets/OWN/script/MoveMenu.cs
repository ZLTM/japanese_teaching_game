using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MoveMenu : MonoBehaviour
{
    double destination = 0f;
    string clickedButtonName;

    public GameObject KanjiInit;
    public GameObject TranslationInit;
    public GameObject DialogBoxInit;
    public GameObject KanjiInfoInit;
    public GameObject Kanji;
    public GameObject Translation;
    public GameObject DialogBox;
    public GameObject KanjiInfo;
    Button selectedKanji;
    Sprite kanjiImage;

    void Start()
    {
        kanjiImage = null;
    }
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

    public void OpenKanjiInfo()
    {
        MovePanel(KanjiInfo, KanjiInfoInit, "x", -210, 0.1f);

        bool isActive = KanjiInit.activeSelf;
        if (isActive == true)
        {  
            OpenKanji();
        }

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

    public void SetKanjiImage()
    {
        clickedButtonName = EventSystem.current.currentSelectedGameObject.name;
        kanjiImage = GameObject.Find(clickedButtonName).GetComponent<Image>().sprite;
        selectedKanji = GameObject.Find("SelectedKanji").GetComponent<Button>();
        selectedKanji.image.sprite = kanjiImage;
    }
}
