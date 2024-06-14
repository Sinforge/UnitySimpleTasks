using UnityEngine;
using UnityEngine.SceneManagement;

public class Switcher : MonoBehaviour
{
    public string sceneName;

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
