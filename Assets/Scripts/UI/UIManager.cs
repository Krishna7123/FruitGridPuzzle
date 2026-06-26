using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI References")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text moveText;
    [SerializeField] private TMP_Text fruitText;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateUI(int score, int moves, int collected, int total)
    {
        scoreText.text = "Score : " + score;
        moveText.text = "Moves : " + moves;
        fruitText.text = "Fruits : " + collected + " / " + total;
    }
}