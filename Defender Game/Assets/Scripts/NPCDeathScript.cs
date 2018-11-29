using UnityEngine;

public class NPCDeathScript : MonoBehaviour
{
    private float deathScore;
    private NPCSpawner nPCSpawner;

    private void Start()
    {
        deathScore = gameObject.GetComponent<NPC>().score;
        nPCSpawner = GameObject.FindGameObjectWithTag("Scripts").GetComponent<NPCSpawner>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            GameObject.FindGameObjectWithTag("Scripts").GetComponent<PlayerStats>().addScore((int)deathScore);
            nPCSpawner.StartCoroutine(GameObject.FindGameObjectWithTag("Scripts").GetComponent<NPCSpawner>().ClearDeadNPC());
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            GameObject.FindGameObjectWithTag("Scripts").GetComponent<PlayerStats>().addLife(-1);
            nPCSpawner.StartCoroutine(GameObject.FindGameObjectWithTag("Scripts").GetComponent<NPCSpawner>().ClearDeadNPC());
        }
    }
}
