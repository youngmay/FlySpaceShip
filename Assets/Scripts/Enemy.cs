using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

    public Transform m_explosionFX;

    public float m_speed = 1;
    public float m_life = 10;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "myRocket")
        {
            hitMyRocket(other);
        }
        else if (other.tag == "player")
        {
            hitMyPlane(other);
        }
    }

    protected abstract void hitMyRocket(Collider other);
    protected abstract void hitMyPlane(Collider other);
    protected abstract void move();

    void OnBecameInvisible()
    {
        if (this.enabled)  // 防止重复删除
        {
            Destroy(this.gameObject);  // 当离开屏幕后销毁
        }
    }
}
