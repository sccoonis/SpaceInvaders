using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject UIRoot;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public void LoadScene(string scene)
    {
        UIRoot.SetActive(false);
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
    }
}
