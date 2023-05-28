using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10;
    public Transform[] positions;
    private int index = 0;
    public float hp = 150;
    private float maxHp;
    public Slider hpSlider;
    public GameObject explosionEffect;
    // Start is called before the first frame update
    void Start()
    {
        positions = RoadSign.positions;
        maxHp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        if(index > positions.Length - 1) return;
        transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * speed);
        if(Vector3.Distance(positions[index].position, transform.position) < 0.2f)
        {
            index++;
        }
        if(index > positions.Length - 1)
        {
            ReachDestination();
        }
    }
    void ReachDestination()
    {
        GameManager.Instance.Lose();
        GameObject.Destroy(this.gameObject);
        OnDestory();
    }
    void OnDestory()
    {
        EnemySpawner.EnemySurvive--;
    }
    public void TakeDamage(float damage)
    {
        if (hp <= 0) return;
        hp -= damage;
        hpSlider.value = (float)hp / maxHp;
        if (hp <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        GameObject effect = GameObject.Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(effect, 1.5f);
        Destroy(this.gameObject);
        EnemySpawner.EnemySurvive--;
    }
}
