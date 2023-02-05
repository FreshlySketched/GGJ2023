using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomBullet : MonoBehaviour
{
    public Vector2 m_Movement;
    private bool destroy = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeathTimer());
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = m_Movement;
    }

    public void SetMovement(Vector2 movement)
    {
        m_Movement = movement;
    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(8f);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            destroy = true;
    }

    public void LateUpdate()
    {
       if(destroy)
            Destroy(gameObject);
    }
}
