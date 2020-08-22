
public interface GameStateListener
{
    void OnGameStarted();

    void OnGameStopped();

    void OnGamePaused();

    void OnGameUnpaused();

    void OnGameOver();
}
