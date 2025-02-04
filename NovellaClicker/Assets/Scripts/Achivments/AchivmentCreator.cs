using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(AchivmentsDataSO))]
public class AchivmentCreator : Editor
{
    private AchivmentsDataSO Database;

    private void OnEnable()
    {
            Database = target as AchivmentsDataSO;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Generate Enum"))
        {
            GenerateEnum();
        }
    }
    private void GenerateEnum()
    {
        string filapath = Path.Combine(Application.dataPath, "Data/AchivmentSys.cs"); // даёт путь к этой папке.
        string Code = "public enum AchivmentsEnum {"; // создаёт енум для легково доступа
        Code += "none,";
        foreach (Achivment achiv in Database.Achivments) 
        {
            string addition = achiv.ID;
            if (addition.Contains(' '))
            {
                addition.Replace(' ', '_');
            }
            // TODO: more checks
            Code+= addition+',';
        }
        Code += "} // Генерируется при нажатие по кнопке внутри AchivmentsDataSO";
        File.WriteAllText(filapath, Code); // Задаёт скрипт.
        
        AssetDatabase.ImportAsset("Assets/Data/AchivmentSys.cs"); // добавляет в юнити едитор
    }
}
#endif