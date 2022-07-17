using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{

    public Button continueButton;
    public string nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        continueButton.onClick.AddListener(OnClickTask);
    }

    void OnClickTask() {
        SceneManager.LoadScene(nextLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
