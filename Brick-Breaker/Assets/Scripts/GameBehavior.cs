using UnityEngine;
using TMPro;
using Utilities; 

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    public GameplayState State; 

    [SerializeField] private TextMeshProUGUI _scoreTextUI;
    [SerializeField] private TextMeshProUGUI _pauseMessage;

    private int _score = 0;
    public float PaddleSpeed = 4.0f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText();
        _pauseMessage.enabled = false;
        State = GameplayState.Play;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            State = State == GameplayState.Play ? GameplayState.Pause : GameplayState.Play;
            _pauseMessage.enabled = !(_pauseMessage.enabled);
            Time.timeScale = (State == GameplayState.Pause) ? 0 : 1;
        }
    }

    public void IncreaseScore(int points)
    {
        _score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        _scoreTextUI.text = "Score: " + _score.ToString();
    }
}
