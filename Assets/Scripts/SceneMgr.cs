using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    public Animator anim;
    public float transitionTime;

    private void Start()
    {
        if (transitionTime <= 0)
            transitionTime = 1f;
    }

    public void LoadNextScene(int sceneIndex)
    {
        StartCoroutine(LoadLevel(sceneIndex));
    }
    public void CloseGame()
    {
        StartCoroutine(QuitGame());
    }

    IEnumerator LoadLevel(int sceneIndex)
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneIndex);
    }

    IEnumerator QuitGame()
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        Application.Quit();
    }

}
