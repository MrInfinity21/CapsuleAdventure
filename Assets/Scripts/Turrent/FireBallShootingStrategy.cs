using UnityEngine;

[CreateAssetMenu(fileName = "FireBall Strategy", menuName = "Shooting Strategies/FireBall")]
public class FireBallShootingStrategy : ShootingStrategy
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
