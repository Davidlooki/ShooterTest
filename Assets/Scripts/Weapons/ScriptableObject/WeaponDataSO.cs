using System.Collections;
using UnityEngine;


[CreateAssetMenu(menuName = "Shooter Test/Weapon/Weapon Data")]
public class WeaponDataSO : ScriptableObject
{   
    [SerializeField]
    private float forceSpeed;

    [SerializeField]
    private float fireIntervalTime = .2f;
    
    [SerializeField]
    private Bullet bulletObject;
    
    #region GETTERS
    public Bullet GetBullet => bulletObject;
    public float FireIntervalTime => fireIntervalTime;
    public float ForceSpeed => forceSpeed;
    
    #endregion
}
