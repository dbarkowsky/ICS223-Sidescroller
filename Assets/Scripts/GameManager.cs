using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Background background;
    [SerializeField] private SpawnManager spawnManager;

    public void EndGame()
    {
        background.enabled = false;
        spawnManager.enabled = false;
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        spawnManager.DestroyObjects();
        spawnManager.enabled = true;
        background.enabled = true;
        playerController.reset();
    }
}
