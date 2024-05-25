using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI inputScore;
    [SerializeField]
    private TMP_InputField inputName;

    public UnityEvent<string, int> submitScoreEvent;

    public void SubmitScore()
    {
        int score;
        string trimmedInput = inputScore.text.Trim();
        bool parseSuccess = int.TryParse(inputScore.text, out score);

        Debug.Log("inputName.text: " + inputName.text);
        Debug.Log("inputScore.text (trimmed): " + trimmedInput);

        if (parseSuccess)
        {
            submitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));
        }
        else
        {
            Debug.LogError("Invalid score format. Please enter a valid integer.");
        }
    }
}
