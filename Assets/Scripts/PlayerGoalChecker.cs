using UnityEngine;

public class PlayerGoalChecker : MonoBehaviour
{
    private bool isGoal = false;

    void Update()
    {
        if (isGoal) return;

        if (transform.position.z >= 4.02f)
        {
            isGoal = true;
            Debug.Log("GOAL Z=4.02 PASSED"); //z座標4.02を通ったらゴール
            GameManager.Instance.OnGoal();
        }
    }
}
