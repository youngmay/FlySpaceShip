using UnityEngine;
using System.Collections;

public class EnemyRocket : MonoBehaviour {
    public float m_speed = 1;
    public float m_power = 1;

    void OnBecameInvisible()
    {
        if (this.enabled)
        {
            Destroy(this.gameObject);
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
        if (other.tag == "player")
        {
            Destroy(this.gameObject);
        }
    }
}
