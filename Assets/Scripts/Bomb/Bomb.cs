using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField, Range(0, 16)]
    private int laserCount = 4;
    
    [SerializeField, Range(0.0f, 60.0f)]
    private float timeBeforeExplode = 3.0f;

    [SerializeField]
    private Vector3 spawnOffset = Vector3.zero;
    
    [SerializeField]
    private GameObject laser = null;
    
    private void Start()
    {
        // Explose après quelque temps
        Invoke(nameof(Explode), timeBeforeExplode);
    }
    private void Explode()
    {
        if (!laser) return;
        
        // Spawn 4 lasers
        for (int _laserIndex = 0; _laserIndex < laserCount; _laserIndex++)
        {
            float _angle = _laserIndex * 360.0f / laserCount;
            Instantiate(laser, transform.position + spawnOffset, Quaternion.Euler(0.0f, _angle, 0.0f));
        }
        
        Destroy(gameObject);
    }
}
