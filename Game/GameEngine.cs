using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    [SerializeField] GameObject mainwindow;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject clearwindow;

    private int any;
    // Start is called before the first frame update
    void Start()
    {
        mainwindow.SetActive(true);
        panel.SetActive(false);
        clearwindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anythig();
        }
    }

    public void anythig()
    {
        any = Random.Range(1, 3);
        Random.InitState(System.DateTime.Now.Millisecond);
        if (any == 1)
        {
            mainwindow.SetActive(false);
            panel.SetActive(true);
            clearwindow.SetActive(false);
        }
        if (any == 2)
        {
            mainwindow.SetActive(false);
            panel.SetActive(false);
            clearwindow.SetActive(true);
        }
        Debug.Log("1 Or 2" +  any);
    }
}
