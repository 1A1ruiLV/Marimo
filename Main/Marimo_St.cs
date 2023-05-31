using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Marimo_St : MonoBehaviour
{
    [SerializeField] private GameObject friendry;
    [SerializeField] private GameObject vessel;
    [SerializeField] private GameObject hanger;

    TextAsset csvFile;
    List<string[]> _csvDate = new List<string[]>();

    
    private void Start()
    {
        DontDestroyOnLoad(friendry);
        DontDestroyOnLoad (vessel);
        DontDestroyOnLoad(hanger);
        loadCSVdata();
    }
   
    public void loadCSVdata()
    {
        TextAsset textasset = new TextAsset();
        csvFile = Resources.Load("Marimo_Dt") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            _csvDate.Add(line.Split(','));
        }
        for (int i = 0; i < _csvDate.Count; i++)
        {
            Debug.Log("–¼‘O::::" + _csvDate[i][0] + ", limitValue " + _csvDate[i][1]
               + ", startValue " + _csvDate[i][2] + ", clearValue " + _csvDate[i][3]
               + ", giveFoodValue " + _csvDate[i][4]);
        }

    }
}
