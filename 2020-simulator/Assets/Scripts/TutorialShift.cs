using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialShift : MonoBehaviour
{
    // Start is called before the first frame update
    public void Next1()

    {
        SceneManager.LoadScene("TutorialPage_2");
    }

    public void Next2()

    {
        SceneManager.LoadScene("TutorialPage_3");
    }

    public void Next3()

    {
        SceneManager.LoadScene("TutorialPage_4");
    }

    public void Done()

    {
        SceneManager.LoadScene("StartMenu");
    }

    public void Prev2()
    {
        SceneManager.LoadScene("TutorialPage_1");
    }

    public void Prev3()
    {
        SceneManager.LoadScene("TutorialPage_2");
    }

    public void Prev4()
    {
        SceneManager.LoadScene("TutorialPage_3");
    }

}
