using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersitentUI : MonoBehaviour
{

    public static PersitentUI Instance;
    public FadePanel fadePanel;

    public void Awake()
    {
        Instance = this;
    }



    public void ChangeScene(string sceneName)
    {
        StartCoroutine(SceneTransition(sceneName));
    }

    private IEnumerator SceneTransition(string sceneName)
    {
        // Fade In (pantalla negra, bloquea input)
        fadePanel.FadeIn();

        yield return new WaitForSeconds(fadePanel.fadeTime);

        // Cargar escena
        AsyncOperation load = SceneManager.LoadSceneAsync(sceneName);
        while (!load.isDone)
            yield return null;

        // Fade Out (libera input)
        fadePanel.FadeOut();
    }
}
