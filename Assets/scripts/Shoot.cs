using UnityEngine;
using System;
public class Shoot : MonoBehaviour
{
    //Maak een nieuw Action Event
    public static event Action onShootBall;

    [SerializeField] private GameObject prefab;
    [SerializeField] private float forceBuild = 20f;
    [SerializeField] private float maximumHoldTime = 5f;
    private float _pressTimer = 0f;
    private float _launchForce = 0f;
    private bool _shotEnabled = true;

    //Luister naar het onBallsDepleted event
    private void Start()
    {
        CountBalls.onBallsDepleted += DisableShot;
    }
    //Verwijder altijd netjes alle events weer
    private void OnDisable()
    {
        CountBalls.onBallsDepleted -= DisableShot;
    }
    private void Update()
    {
        //Zorg dat je alleen kunt schieten als _shotEnabled true is
        if (_shotEnabled) HandleShot();
    }
    private void HandleShot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _pressTimer = 0;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _launchForce = _pressTimer * forceBuild;
            GameObject ball = Instantiate(prefab, transform.parent);
            ball.transform.rotation = transform.rotation;
            ball.GetComponent<Rigidbody2D>().AddForce(ball.transform.right * _launchForce, ForceMode2D.Impulse);
            ball.transform.position = transform.position;

            //Invoke de action event bij het schieten
            onShootBall?.Invoke();
        }
        if (_pressTimer < maximumHoldTime)
        {
            _pressTimer += Time.deltaTime;
        }
    }
    //Zorg dat je niet meer kunt schieten als de ballen op zijn
    private void DisableShot()
    {
        _shotEnabled = false;
    }
}