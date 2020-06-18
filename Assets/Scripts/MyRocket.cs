using UnityEngine;
using System.Collections;

public class MyRocket : MonoBehaviour {
    public float m_speed = 1;
    public float m_power = 1;


    void OnBecameInvisible()
    {
        if (this.enabled)  // 防止重复删除
        {
            Destroy(this.gameObject);  // 当离开屏幕后销毁
        }
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, 0, m_speed * Time.deltaTime));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
