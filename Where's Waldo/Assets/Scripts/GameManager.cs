using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private bool isPaused;
    private int score;
    private float timer;

    public int initialTimeBonus = 10;
    public int levelTimer = 20;
    public float timeBonus = 0.3f;

    private string wantedCharacter;
    private string[] characterNames = {
        "TY",
        "Granny",
        "Timmy",
        "Jackie",
        "Elvis",
        "TheBoss",
        "Kaya",
        "AJ"
    };

    public AudioSource soundtrack;
    public AudioClip foundSound, wrongSound;

    public bool IsPaused {
        get { return isPaused; }
    }

    public int Score {
        get { return score; }
    }

    public float Timer {
        get { return timer; }
    }

    private void Start() {
        isPaused = false;
        timer = levelTimer + initialTimeBonus;
        PlayGameTrack();
        ChangeWantedCharacter();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) PlayPause();

        if(!isPaused)
            UpdateTimer();
    }

    void UpdateTimer() {
        if (isPaused) return;
        timer -= Time.deltaTime;
        if (timer <= 0) GameOver();
        Debug.Log("Wanted Character: " + wantedCharacter + ", Score: " + score + ", Timer: " + timer);
    }

    public void PlayPause() {
        if (isPaused) ResumeGame();
        else PauseGame();
    }

    private void PauseGame() {
        isPaused = true;
    }

    private void ResumeGame() {
        isPaused = false;
    }

    private void GameOver() {
        Restart();
    }

    public void EndGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit() {
        Application.Quit();
    }

    public void CatchCharacter(string characterName) {
        bool isCharacterName = false;
        foreach(string name in characterNames)
            if (name == characterName)
                isCharacterName = true;

        if (!isCharacterName) return;

        if (characterName == wantedCharacter)
            SelectedCorrectCharacter();
        else
            SelectedWrongCharacter();
    }

    private void SelectedCorrectCharacter() {
        score += Mathf.CeilToInt(timer);
        timer = levelTimer + (timer * timeBonus);
        PlayFoundSound();
        ChangeWantedCharacter();
    }

    private void SelectedWrongCharacter() {
        PlayWrongSound();
    }

    private void ChangeWantedCharacter() {
        if (isPaused) return;
        int randomCharacterIndex = Random.Range(0, characterNames.Length);
        wantedCharacter = characterNames[randomCharacterIndex];
    }

    private void PlayGameTrack() {
        soundtrack.loop = true;
        soundtrack.Play();
    }

    private void PlayFoundSound() {
        soundtrack.PlayOneShot(foundSound);
    }

    private void PlayWrongSound() {
        soundtrack.PlayOneShot(wrongSound);
    }
}
