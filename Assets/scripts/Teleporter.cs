using System.Collections;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private float teleportTime = 1f;

    void OnCollisionEnter(Collision collision)
    {
        blackScreen.SetActive(true);
        GameManager.Instance.playerCanMove = false;
        StartCoroutine(DoBlackScreen());
        collision.gameObject.transform.position = spawnPoint.transform.position;
    }

    private IEnumerator DoBlackScreen()
    {
        yield return new WaitForSeconds(teleportTime);
        blackScreen.SetActive(false);
        GameManager.Instance.playerCanMove = true;
    }
}
