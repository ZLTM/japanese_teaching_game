using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class MoveMenu : MonoBehaviour
{
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
    string kanjiReading;
    TextMeshProUGUI selectedReading;
    string kanjiDescription;
    TextMeshProUGUI selectedDescription;    

    void Start()
    {
        kanjiImage = null;
    }
    public void OpenKanji()
    {
        bool kanjiIsActive = KanjiInit.activeSelf;
        bool infoIsActive = KanjiInfoInit.activeSelf;

        if (!kanjiIsActive && !infoIsActive)
        {  
            MovePanel(Kanji, KanjiInit, -350f, 0f, 0.1f);
        }

        else if (kanjiIsActive)
        {  
            MovePanel(Kanji, KanjiInit, -350f, 0f, 0.1f);
        }

        else if (infoIsActive)
        {  
            MovePanel(KanjiInfo, KanjiInfoInit, -350f, 0f, 0.1f);
        }
    }

    public void OpenDialog()
    {
        MovePanel(DialogBox, DialogBoxInit, 0f, 280f, 0.1f);

        bool isActive = TranslationInit.activeSelf;
        if (isActive == true)
        {  
            OpenTranslation();
        }
    }

    public void OpenTranslation()
    {
        MovePanel(Translation, TranslationInit, 0f, 330f, 0.1f);
    }

    public void OpenKanjiInfo()
    {
        MovePanel(KanjiInfo, KanjiInfoInit, -350f, 0f, 0.1f);

        bool isActive = KanjiInit.activeSelf;
        if (isActive == true)
        {  
            OpenKanji();
        }

    }

    public void MovePanel(GameObject Panel, GameObject Initialiter, float x, float y, float Speed)
    {
        bool isActive = Initialiter.activeSelf;
        if (isActive == false)
        {
            Initialiter.SetActive(true);
            iTween.MoveBy(Panel, iTween.Hash("amount", new Vector3 (x, y, 0), "easeType", "easeOutExpo", "delay", Speed));
        }
        else
        {
            Initialiter.SetActive(false);
            iTween.MoveBy(Panel, iTween.Hash("amount", new Vector3 (-x, -y, 0), "easeType", "easeOutExpo", "delay", Speed));
        }
    }

    public void SetKanjiImage()
    {
        clickedButtonName = EventSystem.current.currentSelectedGameObject.name;
        kanjiImage = GameObject.Find(clickedButtonName).GetComponent<Image>().sprite;
        selectedKanji = GameObject.Find("SelectedKanji").GetComponent<Button>();
        selectedKanji.image.sprite = kanjiImage;
    }

    public void SetKanjiContent()
    {
        clickedButtonName = EventSystem.current.currentSelectedGameObject.name;
        kanjiReading = GameObject.Find(clickedButtonName).GetComponent<kanjiDetails>().Readings;
        selectedReading = GameObject.Find("SelectedReading").GetComponent<TextMeshProUGUI>();
        selectedReading.text = kanjiReading;

        clickedButtonName = EventSystem.current.currentSelectedGameObject.name;
        kanjiDescription = GameObject.Find(clickedButtonName).GetComponent<kanjiDetails>().Description;
        selectedDescription = GameObject.Find("SelectedDescription").GetComponent<TextMeshProUGUI>();
        selectedDescription.text = kanjiDescription;
    }
    public void MoveGuiElement()
    {
        print("update");
    }

}
