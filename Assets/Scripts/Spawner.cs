using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    [SerializeField] private Transform _spawnerTransform;

    [SerializeField] private Vector3 _leftUpperPoint;
    [SerializeField] private Vector3 _rightUpperPoint;
    [SerializeField] private Vector3 _leftLowerPoint;
    [SerializeField] private Vector3 _rightLowerPoint;

    [ContextMenu("Spawn")]
    public void Spawn()
    {
        Instantiate(_target, CalculateRandomPosition(), _target.transform.rotation);
    }
    
    private Vector3 CalculateRandomPosition()
    {
        var spawnPoint = new Vector3(Random.Range(_leftLowerPoint.x, _rightLowerPoint.x), 0 , Random.Range(_leftLowerPoint.z, _rightUpperPoint.z));

        return spawnPoint;
    }

}
