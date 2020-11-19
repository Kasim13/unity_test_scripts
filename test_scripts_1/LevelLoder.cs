using System.Collections;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoder : MonoBehaviour
{
    public Slider slider;
    public GameObject loadingscreen;
    int sceneIndex;
    public void LoadLevel()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingscreen.SetActive(true);
        //slider = GameObject.Find("LoadSlider").gameObject.GetComponent<Slider>();
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);
            //slider.value = progress;
            yield return null;
        }
    }
}
