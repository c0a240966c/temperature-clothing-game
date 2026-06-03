using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TemperatureManager temperatureManager;
    public PlayerClothingController playerClothing;
    public ResultUI resultUI;
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void OnGoal()
    {   
        //  2着そろっているか
        if (!playerClothing.HasBothClothes())
        {
            Debug.Log("服が足りない！");
            return;
        }

        bool topOK = temperatureManager.IsSuitable(playerClothing.currentTop);
        bool bottomOK = temperatureManager.IsSuitable(playerClothing.currentBottom);

        bool isCorrect = topOK && bottomOK;

    // 正解/不正解をUIに表示
        resultUI.ShowResult(isCorrect);

        if (topOK && bottomOK)
        {
            Debug.Log("正解！");
        }
        else
        {
            Debug.Log("不正解…");
        }
    }
}
