using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    public float Force = 10;
    public float Radius = 10;
    public GameObject explotion;


    void OnTriggerEnter(Collider other)
    {
        if (other.GetType() == typeof(SphereCollider))
            return;
    
        Rigidbody impact = other.GetComponent<Rigidbody>();

        if (impact)
        {
            impact.AddExplosionForce(100f * Force, transform.position, 100f * Radius);
            other.GetComponent<EnemyAI>().OnHitByFireBall();
        }

        Destroy(gameObject);
        //create fireball explotion after collides
        GameObject fireballexplotion = Instantiate(explotion);
        fireballexplotion.transform.position = transform.position;

        Destroy(fireballexplotion, 2f);
    }
    
}
