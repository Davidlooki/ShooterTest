using System.Collections;
using UnityEngine;

public abstract class Bullet : MonoBehaviour, IBullet
{
    private Vector3 target;

    private float lifespan = 1;

    public void SetTarget(Vector3 _target)
    {
        target = _target;
    }

    public IEnumerator StartLifespanCounter()
    {
        float currLifespan = GetLifespan();
        while(currLifespan != 0)
        {
            Move(currLifespan);
            currLifespan -= Time.deltaTime;
            yield return null;
        }

        DestroyBullet();
        StopCoroutine(StartLifespanCounter());
    }

    private void Move(float _t)
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target, _t);
    }
    public float GetLifespan()
    {
        return lifespan;
    }

    public void Hit()
    {
        //TODO - NOTIFY the Observer object with the object got hit
        StopCoroutine(StartLifespanCounter());
        DestroyBullet();
    }

    public virtual void DestroyBullet()
    {
        DestroyImmediate(this);
    }
    private void OnCollisionEnter(Collision other) 
    {
        //TODO - if the OTHER is different from PARENT
        Hit();
    }
}