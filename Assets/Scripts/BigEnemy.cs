using UnityEngine;
using System.Collections;

public class BigEnemy : Enemy
{
    public Transform m_enemyRocket;
    public float m_fireInteval = 2;
    public Transform m_player;

    private float m_fireTime = 2;

    protected override void hitMyPlane(Collider other)
    {
       // throw new System.NotImplementedException();
    }

    protected override void hitMyRocket(Collider other)
    {
        MyRocket rocket = other.GetComponent<MyRocket>();
        if (rocket != null)
        {
           // Instantiate(m_explosionFX, transform.position, Quaternion.identity);

            m_life -= rocket.m_power;
            if (m_life <= 0)
            {
                 Destroy(this.gameObject);
            }
        }
    }

    protected override void move()
    {
        transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));

        m_fireTime -= Time.deltaTime;
        if (m_fireTime <= 0)
        {
            m_fireTime = m_fireInteval;
            if(m_player != null)
            {
                Vector3 relaPos = m_player.position - transform.position;
                Instantiate(m_enemyRocket, transform.position, Quaternion.LookRotation(relaPos));
            }
        }
    }
}
