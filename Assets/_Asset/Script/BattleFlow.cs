using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleFlow : MonoBehaviour
{
    [SerializeField] GameObject gameWinUI, gameOverUI;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] GameObject bgMusic;

    private void Start()
    {
        playerHealth.OnDead += OnGameOver;
    }
    // Update is called once per frame
    void Update()
    {
        if(EnemyHealth.LivingEnemyCount <= 0)
        {
            OnGameWin();
        }
    }

    void OnGameWin()
    {
        gameWinUI.SetActive(true);
        bgMusic.SetActive(false);
        playerHealth.gameObject.SetActive(false);
    }

    void OnGameOver()
    {
        gameOverUI.SetActive(true);
        bgMusic.SetActive(false);
    }
}
