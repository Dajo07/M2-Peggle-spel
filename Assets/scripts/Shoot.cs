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

    [SerializeField] private float lineSpeed = 10f;
    private LineRenderer _line;
    private bool _lineActive = false;


    //Luister naar het onBallsDepleted event
    private void Start()
    {
        CountBalls.onBallsDepleted += DisableShot;
        _line = GetComponent<LineRenderer>();
        _line.SetPosition(1, Vector3.zero);
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
            _lineActive = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _launchForce = _pressTimer * forceBuild;
            GameObject ball = Instantiate(prefab, transform.parent);
            ball.transform.rotation = transform.rotation;
            ball.GetComponent<Rigidbody2D>().AddForce(ball.transform.right * _launchForce, ForceMode2D.Impulse);
            ball.transform.position = transform.position;

            _lineActive = false;
            _line.SetPosition(1, Vector3.zero);

            //Invoke de action event bij het schieten
            onShootBall?.Invoke();
        }
        if (_pressTimer < maximumHoldTime)
        {
            _pressTimer += Time.deltaTime;
        }
        if (_lineActive)
        {
            _line.SetPosition(1, Vector3.right * _pressTimer * lineSpeed);
        }

    }
    //Zorg dat je niet meer kunt schieten als de ballen op zijn
    private void DisableShot()
    {
        _shotEnabled = false;
    }
}