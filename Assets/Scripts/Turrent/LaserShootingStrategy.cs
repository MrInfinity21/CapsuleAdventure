using UnityEngine;

[CreateAssetMenu(fileName = "Laser Strategy", menuName = "Shooting Strategies/Laser")]
public class LaserShootingStrategy : ShootingStrategy
{
    public float _shootForce;

    public override void Shoot(Transform _shootPoint)
    {
        //Debug.Log(ShootingStrategyName);

        var fireBullet = Instantiate(shootingObject, _shootPoint.position, _shootPoint.rotation);
        fireBullet.GetComponent<Rigidbody>()?.AddForce(_shootForce * _shootPoint.forward, ForceMode.Impulse);
        Destroy(fireBullet, 5);
    }
}


