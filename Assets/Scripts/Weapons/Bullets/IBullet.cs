using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{   
    IEnumerator CoroutineLifespan();
    void Move();
    void ApplyDamage();
    void DestroyBullet();
}
