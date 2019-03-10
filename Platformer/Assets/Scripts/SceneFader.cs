using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneFader : MonoBehaviour {

    public Image img;
    public AnimationCurve fadeCurve;
    [SerializeField]
    private float autoLoadNextLevelAfter;
    public GameObject StartLevel;
    public GameObject socialIcons;
    private void Start()
    {
        StartCoroutine(FadeIn());
        StartLevel.SetActive(false);
        img.enabled = true;
    }


    public void FadeToLevel(string scene)
    {
        StartCoroutine(FadeOutLevel(scene));
    }
    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0f)
         {
            t -= Time.deltaTime;
            float a = fadeCurve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
         }
    }
    IEnumerator FadeOutLevel(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = fadeCurve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
        socialIcons.SetActive(false);
        StartLevel.SetActive(true);
        img.enabled = false;
        yield return new WaitForSeconds(autoLoadNextLevelAfter);
        SceneManager.LoadScene(scene);
       
    }
    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = fadeCurve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
 
        SceneManager.LoadScene(scene);

    }
}

