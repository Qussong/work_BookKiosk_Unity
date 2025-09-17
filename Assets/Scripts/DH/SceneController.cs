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
                    // ���õ� ���� �ε�Ǿ� ���� ������ �ε�
                    if (!scene.isLoaded)
                        SceneManager.LoadSceneAsync(sceneDict[i], LoadSceneMode.Additive);
                }
                else
                {
                    // ���õ��� ���� ���� �ε�Ǿ� �ִ� ��쿡�� ��ε�
                    if (scene.isLoaded)
                        SceneManager.UnloadSceneAsync(sceneDict[i]);
                }
            }
        }
    }
}