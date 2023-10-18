using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(gameUI))]
public class GameController : MonoBehaviour
{
    public static GameController Instace {  get; private set; }
    [SerializeField]
    private int knifeCount;
    [Header("Knife Spawning")]
    [SerializeField]
    private Vector2 knifeSpawnPos;
    [SerializeField]
    private GameObject knifeObj;

    public gameUI GameUI { get; private set; }

    private void Awake()
    {
        Instace = this;
        GameUI=GetComponent<gameUI>();
    }

    private void Start()
    {
        GameUI.KnifeCount(knifeCount);
        spawnKnife();
    }

    public void OnSuccessfullKnifeHit()
    {
        if(knifeCount>0)
        {
            spawnKnife();
        }
        else
        {
            StartGameoverSequence(true);
        }
    }

    private void spawnKnife()
    {
        knifeCount--;
        Instantiate(knifeObj, knifeSpawnPos, Quaternion.identity);

    }

    public void StartGameoverSequence(bool win)
    {
        StartCoroutine("GameoverSequenceCoroutine", win);
    }

    private IEnumerator GameoverSequenceCoroutine(bool win)
    {
        if(win)
        {
            yield return new WaitForSeconds(0.3f);
            RestartGame();

        }
        else
        {
            GameUI.ShowRestartButton();
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

}
