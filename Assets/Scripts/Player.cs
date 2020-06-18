using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    protected Transform my_transform;
    public float m_speed = 1;
    public float m_fireInteval = 0.1f;
    private float m_firetime = 0;
    public Transform rocket;
    public float m_myLife = 100;

    public AudioClip m_shootClip;
    protected AudioSource m_audioSource;
    public Transform m_explosionFX;

    // Use this for initialization
    void Start () {
        my_transform = this.transform;
        m_audioSource = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        float moveV = 0;
        float moveH = 0;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveV += m_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveV -= m_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveH -= m_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveH += m_speed * Time.deltaTime;
        }
        if(moveV != 0 && moveH != 0)
        {
            moveH = moveH / 1.4f;
            moveV = moveV / 1.4f;
        }

        my_transform.Translate(new Vector3(moveH, 0, moveV));

        m_firetime -= Time.deltaTime;
        if (m_firetime <= 0)
        {
            m_firetime = m_fireInteval;
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                Instantiate(rocket, my_transform.position, my_transform.rotation);
                m_audioSource.PlayOneShot(m_shootClip);
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemyRocket")
        {
            EnemyRocket rocket = other.GetComponent<EnemyRocket>();
            if (rocket != null)
            {
                m_myLife -= rocket.m_power;
            }
        }
        else if (other.tag == "enemy")
        {
            m_myLife -= 10;
        }
        if (m_myLife <= 0)
        {
            Instantiate(m_explosionFX, my_transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
