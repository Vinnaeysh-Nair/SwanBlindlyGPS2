using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firecracker : MonoBehaviour
{
    [SerializeField] private AudioClip explodeSFX;

    public GameObject exp;
    public float expForce, radius;
    
    private void OnCollisionEnter(Collision other)
    {
        GameObject _exp = Instantiate(exp, transform.position, transform.rotation);
        AudioManager.Instance.PlaySFX(explodeSFX, 0.2f);
        Destroy(_exp, 3);
        knockBack();
        Destroy(gameObject);
    }

    void knockBack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearyby in colliders)
        {
            Rigidbody rigg = nearyby.GetComponent<Rigidbody>();
            if(rigg != null && rigg.tag!= "Player")
            {
                rigg.AddExplosionForce(expForce, transform.position, radius);
            }
        }
    }
}
