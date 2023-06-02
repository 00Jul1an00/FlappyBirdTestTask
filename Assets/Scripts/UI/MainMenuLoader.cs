using UnityEngine;

public class MainMenuLoader : MonoBehaviour
{
    private void Start()
    {
        GameSceenManager.Instance.LoadMainMenuSceen();
    }
}
