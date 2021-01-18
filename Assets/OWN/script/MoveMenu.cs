using UnityEngine;

public class MoveMenu : MonoBehaviour
{
    Vector3 lastPosition;
    Rect screenRect;
    GameObject MovingPanel;

    double destination = 0f;

    void Start()
    {
        lastPosition = this.transform.position;
        screenRect = new Rect(0f, 0f, Screen.width, Screen.height);
    }
    public void OpenKana(string order)
    {
        GameObject Kana = GameObject.FindWithTag("Kana");
        if (!IsVisible(Kana))
        {
            destination = -210;
        }
        else
        {
            destination = 210;
        }        
        iTween.MoveBy(Kana, iTween.Hash("x", destination, "easeType", "easeOutExpo", "delay", 0.1f));
    }

    public void OpenDialog(string order)
    {
        GameObject DialogBox = GameObject.FindWithTag("DialogBox"); 
        if (!IsVisible(DialogBox))
        {
            destination = -100;
        }
        else
        {
            destination = 100;
        }        
        iTween.MoveBy(DialogBox, iTween.Hash("y", destination, "easeType", "easeOutExpo", "delay", 0.1f));
    }

    public void OpenTranslation(string order)
    {
        GameObject Translation = GameObject.FindWithTag("Translation");
        if (!IsVisible(Translation))
        {
            destination = -300;
        }
        else
        {
            destination = 300;
        }        
        iTween.MoveBy(Translation, iTween.Hash("y", destination, "easeType", "easeOutExpo", "delay", 0.1f));
    }

    public bool IsVisible(GameObject panel)
    {
        int i = 0;
        Vector3[] objectCorners = new Vector3[4];

        foreach (Vector3 corner in objectCorners)
        {
            if (screenRect.Contains(corner))
            {
                i++;
            }
        }
        if (i>=4)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

}
