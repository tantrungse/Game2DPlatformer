using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    private Animator anim;
    private int levelToLoad;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SetLevel(int level)
    {
        levelToLoad = level;
        anim.SetTrigger("Fade");
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    private void Restart()
    {
        SetLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartLevel()
    {
        Invoke("Restart", 1.5f);
    }
}
