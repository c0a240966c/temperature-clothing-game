using UnityEngine;
using TMPro; // UIを操作するために追加

public class PlayerClothingController : MonoBehaviour
{
    [Header("Base Speed")]
    public float baseWalkSpeed = 2.0f;
    public float baseRunSpeed = 5.5f;

    private StarterAssets.ThirdPersonController controller;

    // 現在着ている服
    public ClothingData currentTop;
    public ClothingData currentBottom;

    [Header("UI")]
    public TextMeshProUGUI statusText; // 追加: WEIGHTとSPEEDを表示するテキスト

    void Start()
    {
        controller = GetComponent<StarterAssets.ThirdPersonController>();
        ApplySpeed();
    }

    // 服を装備
    public void EquipClothing(ClothingData data)
    {
        Debug.Log("data = " + data);
        if (data.clothingType == ClothingType.Top)
        {
            currentTop = data;
        }
        else if (data.clothingType == ClothingType.Bottom)
        {
            currentBottom = data;
        }

        ApplySpeed();

        GameManager.Instance.temperatureManager.UpdateUI();
    }

    void ApplySpeed()
    {
        float speedMultiplier = 1f;

        if (currentTop != null)
            speedMultiplier *= currentTop.speedMultiplier;

        if (currentBottom != null)
            speedMultiplier *= currentBottom.speedMultiplier;

        controller.MoveSpeed   = baseWalkSpeed * speedMultiplier;
        controller.SprintSpeed = baseRunSpeed  * speedMultiplier;

        // 速度が変更されたらUIも更新する
        UpdateStatusUI(speedMultiplier);
    }

    // 追加: UIのテキストを更新するメソッド
    void UpdateStatusUI(float speedMultiplier)
    {
        if (statusText == null) return;

        // 倍率によって重さの状態を決定
        string weightStatus = "NORMAL";
        if (speedMultiplier < 1.0f)
        {
            weightStatus = "HEAVY";
        }
        else if (speedMultiplier > 1.0f)
        {
            weightStatus = "LIGHT";
        }

        // テキストに反映 (KIONNの下に配置しやすいように改行を含める)
        statusText.text = $"WEIGHT : {weightStatus}\nSPEED : {controller.MoveSpeed:F1}";
    }

    // 2着そろっているか
    public bool HasBothClothes()
    {
        return currentTop != null && currentBottom != null;
    }
}