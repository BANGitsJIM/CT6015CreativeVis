using UnityEngine;
using UnityEngine.SceneManagement;

public class FactFader : MonoBehaviour
{
    public Animator animator;

    public void FadeOutLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }
}