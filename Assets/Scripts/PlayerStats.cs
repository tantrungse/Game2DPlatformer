using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public bool canTakeDamage = true;
    private PlayerMoveControls playerMove;
    private Animator anim;
    public Image healthUI;
    void Start()
    {
        health = maxHealth;
        playerMove = GetComponentInParent<PlayerMoveControls>();
        anim = GetComponentInParent<Animator>();
        UpdateHealthUI();
    }

    public void IncreaseHealth(float heal)
    {
        health += heal;
        if (health > maxHealth)
            health = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(float damage)
    {
        if(canTakeDamage)
        {
            health -= damage;
            anim.SetBool("Damage", true);
            playerMove.hasControl = false;
            UpdateHealthUI();
            if (health <= 0)
            {
                Debug.Log("The player is dead");
                GetComponent<PlayerStats>().enabled = false;
                GetComponentInParent<GatherInput>().DisableControls();
            }

            StartCoroutine(DamagePrevention());
        }
    }

    private IEnumerator DamagePrevention()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.15f);
        if(health > 0)
        {
            canTakeDamage = true;
            playerMove.hasControl = true;
            anim.SetBool("Damage", false);
        } else
        {
            anim.SetBool("Death", true);
        }
    }

    public void UpdateHealthUI()
    {
        healthUI.fillAmount = health / maxHealth;
    }
}
