using UnityEngine;

[CreateAssetMenu(fileName = "FrostBall Strategy", menuName = "Shooting Strategies/FrostBall")]
public class FrostShootingStrategy : ShootingStrategy
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

