using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private GameObject _targetSelf;

    [SerializeField] private float _lifetime = 2f;

    [SerializeField] private int _cost = 1;

    private FPSMode _fpsMode;

    private void Awake()
    {
        _fpsMode = FindObjectOfType<FPSMode>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
            ShootDead();   
    }

    private void Update()
    {
        if (_lifetime > 0)
            _lifetime -= Time.deltaTime;
        else
            LifetimeEndDead();
    }

    private void ShootDead()
    {
        _fpsMode.ChangeScore(_cost);
        Destroy(_targetSelf.gameObject);
    }

    private void LifetimeEndDead()
    {
        _fpsMode.ChangeScore(-_cost);
        Destroy(_targetSelf.gameObject);
    }
}