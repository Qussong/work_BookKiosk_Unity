using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DH
{
    public class SceneController : MonoBehaviour
    {
        Dictionary<int, string> sceneDict = new Dictionary<int, string>();
        int maxPageNum = 4;

        // Start is called before the first frame update
        void Start()
        {
            SetSceneDictionary();
        }

        public void SetSceneDictionary()
        {
            for (int i = 0; i < maxPageNum; i++)
            {
                sceneDict[i] = $"SubScene{i}";
            }
        }

        public void OpenScene(int index)
        {
            for (int i = 0; i < sceneDict.Count; i++)
            {
                //string sceneName = sceneDict[i];
                Scene scene = SceneManager.GetSceneByName(sceneDict[i]);

                if (i == index)
                {
                    // 선택된 씬은 로드되어 있지 않으면 로드
                    if (!scene.isLoaded)
                        SceneManager.LoadSceneAsync(sceneDict[i], LoadSceneMode.Additive);
                }
                else
                {
                    // 선택되지 않은 씬은 로드되어 있는 경우에만 언로드
                    if (scene.isLoaded)
                        SceneManager.UnloadSceneAsync(sceneDict[i]);
                }
            }
        }
    }
}