using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePanel : MonoBehaviour
{
    public Button _restartButton;
    public TextMeshProUGUI _scoreText;
    public TextMeshProUGUI _scorePanel;
    public Image _scoreImage;
    [SerializeField] private GameManager _gameManager;

    private void Start( )
    {
        _restartButton.onClick.AddListener ( Restart );
    }

    private void OnEnable( )
    {
        UpdateScoreDisplay ();
    }
    private void OnDisable( )
    {
        UpdateScoreDisplay ();
    }

    private void UpdateScoreDisplay( )
    {
        int currentScore = ScoreManager.Instance.GetCurrentScore ();
        _scoreText.text = currentScore.ToString ();

        if ( currentScore >= ScoreManager.Instance.maxScore )
        {
            _scoreImage.gameObject.SetActive ( true );
            _scorePanel.gameObject.SetActive ( false );
        }
        else
        {
            _scoreImage.gameObject.SetActive ( false );
            _scorePanel.gameObject.SetActive ( true );
        }
    }


    public void Restart( )
    {
        _gameManager.Restart ();
    }
}
