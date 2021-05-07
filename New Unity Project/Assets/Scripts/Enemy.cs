using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float StartHealth = 100;
    private float health;

    public int worth = 50;

    //DONT DO public GameObject deathEffect;
    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;


    void Start()
    {
        speed = startSpeed;
        health = StartHealth; 
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / StartHealth;

        if (health <= 0 && ! isDead)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    
    }
        void Die()
        {

        // DONT DO GameObject effct = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        // DONT DO Destroy(effect, 5f);
        isDead = true;
        PlayerStats.Money += worth;
        WaveSpawner.EnemiesAlive--;
            Destroy(gameObject);
    }

  

}
