using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public static string lastClickedButtonName;

    public void Awake()
    {
        // �N���b�N���ꂽ�{�^���̏���ۑ����邽�߂̃��X�i�[��ݒ�
        List<Button> buttons = new List<Button>(FindObjectsOfType<Button>());
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => 
            {
                lastClickedButtonName = button.name;
            });
        }
    }
    public void OnClickTitle2Main()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnClickMain2Game()
    {
        SceneManager.LoadScene("Game");
    }

    public void Main2Option()
    {
        SceneManager.LoadScene("Option");
    }

    public void Title2Option()
    {
        SceneManager.LoadScene("Option");
    }

}
