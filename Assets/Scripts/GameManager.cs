using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager GM;
    private Fader fader;
    private Door door;
    private List<Gem> gems;
    private void Awake()
    {
        if (GM == null)
        {
            GM = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
        gems = new List<Gem>();
    }
    void Start()
    {
        
    }

    public static void RegisterFader(Fader fader)
    {
        if (GM == null)
            return;
        GM.fader = fader;
    }

    public static void RegisterDoor(Door door)
    {
        if (GM == null)
            return;
        GM.door = door;
    }

    public static void ManagerLoadLevel(int index)
    {
        if (GM == null)
            return;
        GM.fader.SetLevel(index);
    }

    public static void ManagerRestartLevel()
    {
        if (GM == null)
            return;
        GM.gems.Clear();
        GM.fader.RestartLevel();
    }

    public static void RegisterGem(Gem gem)
    {
        if (GM == null)
            return;
        if (!GM.gems.Contains(gem))
            GM.gems.Add(gem);
    }

    public static void RemoveGemFromList(Gem gem)
    {
        if (GM == null)
            return;
        GM.gems.Remove(gem);
        if (GM.gems.Count == 0)
            GM.door.UnlockDoor();
    }
}
