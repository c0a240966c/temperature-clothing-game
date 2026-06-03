using UnityEngine;
//服のパラメータを「データ」として持つ
[CreateAssetMenu(menuName = "Clothing/Clothing Data")]
public class ClothingData : ScriptableObject
{
    public string clothingName;
    public ClothingType clothingType;

    [Header("Movement")]
    public float speedMultiplier = 1.0f;
    public float mistakeRate = 0.05f;

    public int minTemperature;
    public int maxTemperature;

    [Header("Temperature")]
    public int suitableMinTemp;
    public int suitableMaxTemp;
}
