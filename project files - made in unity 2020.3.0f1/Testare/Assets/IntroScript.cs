using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    public CanvasGroup[] groups;

    void Awake()
    {
        Screen.fullScreen = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        StartCoroutine(FadeInUI());
    }

    public string characterType;

    IEnumerator FadeInUI()
    {
        for (int i = 0; i < groups.Length; i++)
        {
            yield return new WaitForSeconds(2.5f);

            while (groups[i].alpha < 1)
            {
                yield return null;
                groups[i].alpha += Time.deltaTime * 3;
            }
        }
    }

    public void ChooseYbot()
    {
        characterType = "Y";
        SceneManager.LoadScene(1);
    }

    public void ChooseXbot()
    {
        characterType = "X";
        SceneManager.LoadScene(1);
    }
}
