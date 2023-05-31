using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Codice.CM.Client.Differences.Graphic;

[CustomEditor(typeof(CsvImporter))]
public class csvImporterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var csvImporter = target as CsvImporter;
        DrawDefaultInspector();

        if (GUILayout.Button("マリモデータの作成")) 
        {
            //Debug.Log("マリモデータの作成ボタンが押された");
            SetCsvDatToScriptableObject(csvImporter);
        }
    }

    void SetCsvDatToScriptableObject(CsvImporter csvImporter) 
    {
        //ボタンを押されたらバース実行
        if(csvImporter.csvFile == null) 
        {
            Debug.LogWarning(csvImporter.name + " : 読み込みcsvファイルがセットされていません。");
            return;
        }

        //csvファイルをstring形式に変換
        string csvText = csvImporter.csvFile.text;

        //改行ごとにバース
        string[] afterParse = csvText.Split(',');

        //ヘッダー行を除いてインポート
        for(int i = 1; i < afterParse.Length; i++) 
        {
            string[] parseByComma = afterParse[i].Split(',');

            int column = 0;

            //先頭の列が空であればその行は読み込まない。
            if (parseByComma[column] == "") 
            {
                continue;
            }

            //行数をIDとしてファイルを作成
            string fileName = "marimoData_" + i.ToString("D4") + ".asset";
            string path = "Assets/Script/Editor" + fileName;

            //EnemyDataのインスタンスをメモリ上に作成
            var marimoData = CreateInstance<M_St_database>();

            //名前
            marimoData.levelName = parseByComma[column];

            //最大値
            column += 1;
            marimoData.limitValue = int.Parse(parseByComma[column]);

            //初期値
            column += 1;
            marimoData.startValue = int.Parse(parseByComma[column]);

            //クリア値
            column += 1;
            marimoData.clearValue = int.Parse(parseByComma[column]);

            //餌での上昇値
            column += 1;
            marimoData.giveFoodValue = int.Parse(parseByComma[column]);

            //インスタンス化したものをアセットとして保存
            var asset = (M_St_database)AssetDatabase.LoadAssetAtPath(path, typeof(M_St_database));
            if(asset == null) 
            {
                //指定のパスにファイルが存在しない場合は新規作成
                AssetDatabase.CreateAsset(marimoData, path);
            }
            else
            {
                //指定のパスにファイルが存在する場合は更新
                EditorUtility.CopySerialized(marimoData, asset);
                AssetDatabase.SaveAssets();
            }
            AssetDatabase.Refresh();
        }
        Debug.Log(csvImporter.name + " : マリモデータの作成が完了しました。");
    }
}
