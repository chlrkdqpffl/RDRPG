using UnityEngine;

[System.Serializable]
public struct CharacterInfo
{
    public string Name;
    public int HP;
    public int AP;
    public int DP;

    [Range(0, 30.0f)] public float Speed;
    [Range(0.1f, 3.0f)] public float AttackSpeed;
}