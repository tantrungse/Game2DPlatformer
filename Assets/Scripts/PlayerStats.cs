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
    private PlayerAttackControls attackControls;
    void Start()
    {
        //health = maxHealth;
        playerMove = GetComponentInParent<PlayerMoveControls>();
        anim = GetComponentInParent<Animator>();
        attackControls = GetComponentInParent<PlayerAttackControls>();
        health = PlayerPrefs.GetFloat("HealthKey", maxHealth);
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
            attackControls.ResetAttack();
            anim.SetBool("Damage", true);
            playerMove.hasControl = false;
            UpdateHealthUI();
            if (health <= 0)
            {
                GetComponent<PlayerStats>().enabled = false;
                GetComponentInParent<GatherInput>().DisableControls();
                PlayerPrefs.SetFloat("HealthKey", maxHealth);

                GameManager.ManagerRestartLevel();
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

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("HealthKey");
    }
}
