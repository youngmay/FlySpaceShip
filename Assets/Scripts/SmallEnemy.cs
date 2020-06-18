using UnityEngine;
using System.Collections;

public class SmallEnemy : Enemy {

    protected override void hitMyPlane(Collider other)
    {
        m_life = 0;
        Instantiate(m_explosionFX, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    protected override void hitMyRocket(Collider other)
    {
        MyRocket rocket = other.GetComponent<MyRocket>();
        if (rocket != null)
        {
            m_life -= rocket.m_power;
            if (m_life <= 0)
            {
                Instantiate(m_explosionFX, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }

        }
    }

    protected override void move()
    {
        float rx = Mathf.Sin(Time.time) * Time.deltaTime;
        transform.Translate(new Vector3(rx, 0, -m_speed * Time.deltaTime), Space.World);
    }
}
