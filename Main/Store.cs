using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] GameObject store_panel;
    [SerializeField] GameObject room;
    [SerializeField] GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        store_panel.SetActive(false);
        room.SetActive(true);
        button.SetActive(true);
    }

    // Update is called once per frame
    public void OnStoreOpenButton()
    {
        store_panel.gameObject.SetActive(true);
        room.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
    }

    public void OnStoreCloseButton()
    {
        store_panel.gameObject.SetActive(false); 
        room.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
    }
}
