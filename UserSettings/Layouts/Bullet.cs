using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 50;
    public float speed = 20;
    public GameObject explosionEffectPrefeb;
    private Transform target;
    public void SetTarget(Transform _target)
    {
        this.target = _target;
    }
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Die();
            return;
        }
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            col.GetComponent<Enemy>().TakeDamage(damage);
            GameObject effect = GameObject.Instantiate(explosionEffectPrefeb, transform.position, transform.rotation);
            Destroy(effect, 1);
            Destroy(this.gameObject);
        }
    }
    void Die()
    {
        GameObject effect = GameObject.Instantiate(explosionEffectPrefeb, transform.position, transform.rotation);
        Destroy(effect, 1);
        Destroy(this.gameObject);
    }
}
