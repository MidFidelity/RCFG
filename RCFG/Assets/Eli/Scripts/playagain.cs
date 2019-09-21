using nvp.events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playagain : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex(0));
        button.onClick.AddListener(restart);
        EventManager.EventHandlers.Clear();
    }

    void restart()
    {
        SceneManager.LoadScene("main");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
