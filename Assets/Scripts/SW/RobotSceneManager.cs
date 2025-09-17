using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static RobotSceneManager;

public class RobotSceneManager : MonoBehaviour
{
    public enum ESCENENAME
    {
        Title,
        PromotionalVideo,
        Max
    }

    public static RobotSceneManager instance;

    [SerializeField] GameObject[] dontDestroyObjects;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        foreach (var item in dontDestroyObjects)
        {
            DontDestroyOnLoad(item);
        }
    }

    public async void LoadScene(ESCENENAME scenename) 
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(scenename.ToString());

        while (!op.isDone)
        {
            await System.Threading.Tasks.Task.Yield();
        }
    }

    public async void LoadTitle() 
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(ESCENENAME.Title.ToString());

        while (!op.isDone)
        {
            await System.Threading.Tasks.Task.Yield();
        }
    }
}
