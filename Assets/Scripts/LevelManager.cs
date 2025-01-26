using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int currentLevel = 0;
    public int nScenes = 1;

    void Start()
    {
        DontDestroyOnLoad(this);
        LoadLevel(0);
    }

    public void LoadLevel(int levelToLoad)
    {
        if(levelToLoad < 0 || levelToLoad >= nScenes)
        {
            Debug.LogError("Invalid level index");
            return;
        }

        SceneManager.LoadSceneAsync("Scenes/Levels/Level" + levelToLoad);
    }








}
