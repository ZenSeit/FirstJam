using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private CharacterStatsScriptableObject characterStats;

    int health;

    int remainingLives;


    private void Start()
    {
        health = characterStats.maxHealth;
        remainingLives = characterStats.lifes;
    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health<0){
            GameManager.Instance.PlayerDied();
            RestoreHealth();
            remainingLives--;
            if(remainingLives<=0){
                GameManager.Instance.GameOver();
            }
        }
    }


    private void RestoreHealth(){
        health = characterStats.maxHealth;
    }


}
