using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [Tooltip("How long the player has to survive for. (In seconds)")]
    public float TotalGameTime = 300f;

    [Tooltip("The amount of energy needed to trigger a game-over event.")]
    public float TargetEnergy = 10000f;

    [Tooltip("How much energy has been wasted until now.")]
    public float EnergyWastage = 0f;

    [Tooltip("Modifier that influences how much energy will be wasted.")]
    public float EnergyWasteMultiplier = 1f;

    [Tooltip("Time between each enemy spawn event.")]
    public float EnemySpawnTime = 5f;

    [Tooltip("How many enemies can be in the scene at once.")]
    public float MaxEnemyCount = 10f;

    [HideInInspector]
    public bool GamePlayStarted = false;


    public static GameManager Instance;

    public GameObject[] EnableOnGameplayStart;
    public AudioSource WinGameSource;
    public AudioClip WinGameClip;

    public Transform CameraAnchor;
    public Transform HandAnchor;
    public bool pointerIsRemote;

    public float TotalTime = 0f;

    public GameObject Player;

    void Awake () {
        SetGameStarted(false);

        Player = GameObject.FindGameObjectWithTag("Player");

        var gameManagers = FindObjectsOfType<GameManager>();

        if (gameManagers.Length > 1) {
            Debug.LogError("More than 1 GameManager in scene");
        } else {
            Instance = this;
        }

        if (GameObject.FindGameObjectWithTag("IntroSequence") == null) SetGameStarted(true);
    }

    void Update() {
        if (GamePlayStarted) {
            TotalTime += Time.deltaTime;

            if (TotalTime > TotalGameTime) {
                DoWinEvent();
            }
        }
    }

    public void AddEnergyWaste (float amount) {
        if (GamePlayStarted) {
            EnergyWastage += amount * EnergyWasteMultiplier;

            if (EnergyWastage >= TargetEnergy && TotalTime < TotalGameTime) {
                DoGameOverEvent();
            }
        }
    }

    public void SetGameStarted (bool started) {
        GamePlayStarted = started;

        foreach (var obj in EnableOnGameplayStart) {
            obj.SetActive(GamePlayStarted);
        }
    }

    void DoGameOverEvent () {
        SetGameStarted(false);
        print("GAME OVER");

        StartCoroutine(doFade());
    }

    IEnumerator doFade ()
    {
        float fadeLevel = 0;

        while (fadeLevel < 1)
        {
            yield return null;
            fadeLevel += 1.5f * Time.deltaTime;
            fadeLevel = Mathf.Clamp01(fadeLevel);

            OVRInspector.instance.fader.SetFadeLevel(fadeLevel);
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }

    void DoWinEvent() {
        SetGameStarted(false);
        print("WIN");

        WinGameSource.clip = WinGameClip;
        WinGameSource.Play();
    }
}
