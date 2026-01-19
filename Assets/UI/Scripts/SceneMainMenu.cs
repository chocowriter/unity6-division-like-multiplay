using System.Collections;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DivisionLike
{
    public class SceneMainMenu : MonoBehaviour
    {
        [SerializeField] private Button m_SinglePlayButton;
        [SerializeField] private Button m_MultiPlayButton;
        [SerializeField] private Button m_TrainingButton;
        [SerializeField] private Button m_SettingsButton;
        [SerializeField] private Button m_GithubButton;
        [SerializeField] private Button m_QuitButton;
        
        [SerializeField] private GameObject m_LoadingScreen;

        private void Awake()
        {
            m_SinglePlayButton.onClick.AddListener(OnClickSinglePlayButton);
            m_MultiPlayButton.onClick.AddListener(OnClickMultiButton);
            m_TrainingButton.onClick.AddListener(OnClickTrainingButton);
            m_SettingsButton.onClick.AddListener(OnClickSettingsButton);
            m_GithubButton.onClick.AddListener(OnClickGithubButton);
            m_QuitButton.onClick.AddListener(OnClickQuitButton);
        }

        private void OnClickSinglePlayButton()
        {
            LoadSinglePlayScene();
        }

        private bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        private void OnClickMultiButton()
        {
            LoadMultiPlayScene();
        }

        private void OnClickTrainingButton()
        {
            m_LoadingScreen.SetActive(true);
            SceneManager.sceneLoaded += LoadedSceneComplete;
            StartCoroutine(LoadScene(SceneName.Training));
        }

        private void OnClickSettingsButton()
        {
            m_LoadingScreen.SetActive(true);
            SceneManager.sceneLoaded += LoadedSceneComplete;
            StartCoroutine(LoadScene(SceneName.Settings));
        }

        private void OnClickGithubButton()
        {
            Application.OpenURL("https://github.com/chocowriter/unity6-division-like-multiplay");
        }

        private void OnClickQuitButton()
        {
            Application.Quit();
        }

        public void LoadSinglePlayScene()
        {
            m_LoadingScreen.SetActive(true);
            SceneManager.sceneLoaded += LoadedSceneComplete;
            StartCoroutine(LoadScene(SceneName.SinglePlay));
        }

        public void LoadMultiPlayScene()
        {
            m_LoadingScreen.SetActive(false);
            SceneManager.sceneLoaded += LoadedSceneComplete;
            StartCoroutine(LoadScene(SceneName.MultiPlay));
        }

        IEnumerator LoadScene(SceneName _scene)
        {
            AsyncOperation operation = SceneController.instance.LoadSceneAsyn(_scene);
            operation.allowSceneActivation = false;

            float timer = 0f;
            while (operation.isDone == false)
            {
                yield return null;
                timer += Time.deltaTime;

                if (operation.progress < 0.9f)
                {
                }
                else
                {
                    operation.allowSceneActivation = true;

                    yield break;
                }
            }

            yield break;
        }

        /// <summary>
        /// 씬을 불러들이는 작업이 완료되면 처리할 작업들
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="loadSceneMode"></param>
        private void LoadedSceneComplete(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (scene.name == SceneController.instance.CurrentScene.ToString())
            {
                SceneManager.sceneLoaded -= LoadedSceneComplete;
            }
        }
    }
}