using UnityEngine;
using TMPro;

public class TemperatureManager : MonoBehaviour
{
    public int currentTemperature;
    public TextMeshProUGUI tempText;

    void Start()
    {
        currentTemperature = Random.Range(-5, 35);
        UpdateUI();
    }

    public void UpdateUI()
    {
        tempText.text = $"KIONN : {currentTemperature}°C";

        // ===== 色変更 =====
        if (currentTemperature <= 0)
        {
            tempText.color = Color.cyan; // 寒い
        }
        else if (currentTemperature <= 19)
        {
            tempText.color = new Color(0.4f, 0.6f, 1f); // 青寄り
        }
        else if (currentTemperature <= 27)
        {
            tempText.color = Color.green; // 快適
        }
        else
        {
            tempText.color = Color.red; // 暑い
        }
    }

    // ゴール時の正誤判定用（見た目とは別）
    public bool IsSuitable(ClothingData clothing)
    {
        if (clothing == null) return false;

        return currentTemperature >= clothing.minTemperature
            && currentTemperature <= clothing.maxTemperature;
    }
}
