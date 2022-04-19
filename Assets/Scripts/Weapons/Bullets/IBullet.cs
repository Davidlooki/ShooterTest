using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
    void SetTarget(Vector3 _target);
    float GetLifespan();
    
    void Hit();
}
