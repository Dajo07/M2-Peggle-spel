
using UnityEngine;

public class Peggle : MonoBehaviour
{
    public int hitsToDestroy = 3;     // totaal aantal hits dat deze peg aankan
    public int pointsPerHit = 10;     // aantal punten dat één hit waard is


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // score toekennen
        ScoreManager.Instance.AddScore(pointsPerHit);

        // aftellen
        hitsToDestroy--;

        // check of de peg nu op is
        if (hitsToDestroy <= 0)
        {
            Destroy(gameObject, 0.25f);
        }
    }
}
