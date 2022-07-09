using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    public void OnPressStartButton()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
