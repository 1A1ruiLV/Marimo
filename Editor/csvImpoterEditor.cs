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

        if (GUILayout.Button("�}�����f�[�^�̍쐬")) 
        {
            //Debug.Log("�}�����f�[�^�̍쐬�{�^���������ꂽ");
            SetCsvDatToScriptableObject(csvImporter);
        }
    }

    void SetCsvDatToScriptableObject(CsvImporter csvImporter) 
    {
        //�{�^���������ꂽ��o�[�X���s
        if(csvImporter.csvFile == null) 
        {
            Debug.LogWarning(csvImporter.name + " : �ǂݍ���csv�t�@�C�����Z�b�g����Ă��܂���B");
            return;
        }

        //csv�t�@�C����string�`���ɕϊ�
        string csvText = csvImporter.csvFile.text;

        //���s���ƂɃo�[�X
        string[] afterParse = csvText.Split(',');

        //�w�b�_�[�s�������ăC���|�[�g
        for(int i = 1; i < afterParse.Length; i++) 
        {
            string[] parseByComma = afterParse[i].Split(',');

            int column = 0;

            //�擪�̗񂪋�ł���΂��̍s�͓ǂݍ��܂Ȃ��B
            if (parseByComma[column] == "") 
            {
                continue;
            }

            //�s����ID�Ƃ��ăt�@�C�����쐬
            string fileName = "marimoData_" + i.ToString("D4") + ".asset";
            string path = "Assets/Script/Editor" + fileName;

            //EnemyData�̃C���X�^���X����������ɍ쐬
            var marimoData = CreateInstance<M_St_database>();

            //���O
            marimoData.levelName = parseByComma[column];

            //�ő�l
            column += 1;
            marimoData.limitValue = int.Parse(parseByComma[column]);

            //�����l
            column += 1;
            marimoData.startValue = int.Parse(parseByComma[column]);

            //�N���A�l
            column += 1;
            marimoData.clearValue = int.Parse(parseByComma[column]);

            //�a�ł̏㏸�l
            column += 1;
            marimoData.giveFoodValue = int.Parse(parseByComma[column]);

            //�C���X�^���X���������̂��A�Z�b�g�Ƃ��ĕۑ�
            var asset = (M_St_database)AssetDatabase.LoadAssetAtPath(path, typeof(M_St_database));
            if(asset == null) 
            {
                //�w��̃p�X�Ƀt�@�C�������݂��Ȃ��ꍇ�͐V�K�쐬
                AssetDatabase.CreateAsset(marimoData, path);
            }
            else
            {
                //�w��̃p�X�Ƀt�@�C�������݂���ꍇ�͍X�V
                EditorUtility.CopySerialized(marimoData, asset);
                AssetDatabase.SaveAssets();
            }
            AssetDatabase.Refresh();
        }
        Debug.Log(csvImporter.name + " : �}�����f�[�^�̍쐬���������܂����B");
    }
}
