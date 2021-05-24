using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SelectScene : MonoBehaviour
{
    public void NextScene(string selectedSscene)
    {
        SceneManager.LoadScene(selectedSscene);
    }
}