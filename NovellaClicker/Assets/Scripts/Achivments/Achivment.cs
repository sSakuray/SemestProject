using UnityEngine;

[System.Serializable]
public class Achivment
{
    [SerializeField] public string ID = "test_id";
    [SerializeField] public string Title  = "Test Achivment";
    [SerializeField] public string Descrpt = "Test Description";
    [SerializeField] public Sprite icon;
    [SerializeField] internal bool AUnlocked  = false; // короче говоря, что-бы игрок не считерил ачивку тут стоит Internal
    [SerializeField] internal string Type = "click";
    [SerializeField] internal int ammount = 10;
}
