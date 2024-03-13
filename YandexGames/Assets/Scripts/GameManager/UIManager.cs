using UnityEngine;

public class UIManager : MonoBehaviour, IInilization
{
    public enum UIState
    {
        MainMenu,
        GameHud,
        EndGamePanel
        // Добавьте другие состояния по мере необходимости
    }

    public GameObject mainMenuUI;
    public GameObject endGamePanel;
    public GameObject gameHud;

    private UIState currentState = UIState.MainMenu;
    private bool isPaused = false;

    private static UIManager _instance;
    public static UIManager Instance => _instance;

    private void Awake( )
    {
        if ( _instance != null && _instance != this )
        {
            Destroy ( this.gameObject );
        }
        else
        {
            _instance = this;
        }
    }

    public void Inilization( )
    {
        SwitchUIState ( UIState.MainMenu );
    }

    private void SwitchUIState( UIState newState )
    {
        isPaused = newState == UIState.EndGamePanel;

        mainMenuUI.SetActive ( false );
        endGamePanel.SetActive ( false );
        gameHud.SetActive ( false );

        switch ( newState )
        {
            case UIState.MainMenu:
                mainMenuUI.SetActive ( true );
                break;

            case UIState.EndGamePanel:
                endGamePanel.SetActive ( true );
                Time.timeScale = isPaused ? 0f : 1f; // Pause or unpause the game
                break;

            case UIState.GameHud:
                gameHud.SetActive ( true );
                Time.timeScale = 1f; // Unpause the game in GameHud state
                break;

                // Добавляйте другие случаи по мере добавления состояний
        }

        currentState = newState;
    }

    public void SetUIStateMainMenu( )
    {
        SwitchUIState ( UIState.MainMenu );
    }

    public void SetUIStateGameHud( )
    {
        SwitchUIState ( UIState.GameHud );
    }

    public void SetUIStateEndGamePanel( )
    {
        SwitchUIState ( UIState.EndGamePanel );
        //endGamePanel.EndGameTextChange ( stateEnd );
    }

    public void StartGame( )
    {
        mainMenuUI.SetActive ( false );
        endGamePanel.SetActive ( false );
        gameHud.SetActive ( true );
    }

    public void Restart( )
    {
        SwitchUIState ( UIState.GameHud );
    }
}
