using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackScene : MonoBehaviour
{
    public void CloseOption()
    {
        if (SceneChanger.lastClickedButtonName == "2Option")
        {
            SceneManager.LoadScene("Title");
        }

        if(SceneChanger.lastClickedButtonName == "option_Button")
        {
            SceneManager.LoadScene("Main");
        }
    }
}
