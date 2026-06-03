using UnityEngine;
using TMPro;
using System.Collections;

public class ResultUI : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    void Start()
    {
        resultText.gameObject.SetActive(false);
    }

    public void ShowResult(bool isCorrect)
    {
        resultText.gameObject.SetActive(true);

        if (isCorrect)
        {
            resultText.text = "Correct!";
            resultText.color = Color.green;
        }
        else
        {
            resultText.text = "Wrong...";
            resultText.color = Color.red;
        }

        StartCoroutine(HideAfterSeconds(2f));
    }

    IEnumerator HideAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        resultText.gameObject.SetActive(false);
    }
}
