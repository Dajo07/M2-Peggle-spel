using UnityEngine;
using System;   //nodig voor Action
public class BumperHit : MonoBehaviour
{
    [SerializeField] private int scoreValue = 100;

    private ParticleSystem ps;
    public static event Action<string, int> onBumperHit;

    private void Start()
    {
        //Vraag het Particle System Component op als de game start en bewaar hem in je variabele, zodat je er later dingen mee kunt doen
        ps = GetComponent<ParticleSystem>();

        //zet je particle system stil! (? checkt of er wel een particle system is.)
        ps?.Stop();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            onBumperHit?.Invoke(gameObject.tag, scoreValue);
            ps?.Stop();
            ps?.Play();
        }
    }
}