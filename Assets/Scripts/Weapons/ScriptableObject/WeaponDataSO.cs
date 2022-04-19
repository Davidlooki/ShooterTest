using System.Collections;
using UnityEngine;


[CreateAssetMenu(menuName = "Shooter Test/Weapon/Weapon Data")]
public class WeaponDataSO : ScriptableObject
{
    [SerializeField]
    private int fireRange;
    
    [SerializeField]
    private float forceSpeed;

    [SerializeField]
    private int maxAmmo = 10;

    [SerializeField]
    private float fireIntervalTime = .2f;
    
    [SerializeField]
    private Bullet bulletObject;

    public Bullet GetBullet => bulletObject;
    
    public float FireIntervalTime => fireIntervalTime;
    public float ForceSpeed => forceSpeed;

    public int FireRange => fireRange;
}
