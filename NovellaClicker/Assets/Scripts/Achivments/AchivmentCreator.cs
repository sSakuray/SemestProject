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
        string filapath = Path.Combine(Application.dataPath, "Data/AchivmentSys.cs"); // ��� ���� � ���� �����.
        string Code = "public enum AchivmentsEnum {"; // ������ ���� ��� ������� �������
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
        Code += "} // ������������ ��� ������� �� ������ ������ AchivmentsDataSO";
        File.WriteAllText(filapath, Code); // ����� ������.
        
        AssetDatabase.ImportAsset("Assets/Data/AchivmentSys.cs"); // ��������� � ����� ������
    }
}
#endif