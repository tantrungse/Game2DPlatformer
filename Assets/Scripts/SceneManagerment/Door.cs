using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int levelToLoad;
    public Sprite unlockedSprite;
    private BoxCollider2D boxCol;
    void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
        GameManager.RegisterDoor(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boxCol.enabled = false;
            collision.GetComponent<GatherInput>().DisableControls();

            PlayerStats playerStats = collision.GetComponentInChildren<PlayerStats>();
            PlayerPrefs.SetFloat("HealthKey", playerStats.health);

            PlayerCollectibles playerCollectibles = collision.GetComponent<PlayerCollectibles>();
            PlayerPrefs.SetInt("GemNumber", playerCollectibles.gemNumber);

            GameManager.ManagerLoadLevel(levelToLoad);
        }
    }

    public void UnlockDoor()
    {
        GetComponent<SpriteRenderer>().sprite = unlockedSprite;
        boxCol.enabled = true;
    }
}
