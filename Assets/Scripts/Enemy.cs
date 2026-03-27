using System.Collections;
using System.Runtime.ExceptionServices;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody rb;
    private GameObject player;
    public bool isStuned = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(isStuned)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }
        
        Vector3 dir = player.transform.position - transform.position;
        dir.Normalize();
        rb.AddForce(dir * speed);
    }

    public IEnumerator EnemyStuned()
    {   
        Debug.Log($"{this.gameObject.name} is stuned");
        isStuned = true;
        yield return new WaitForSeconds(5f);
        isStuned = false;
    }
    public void Stun()
    {
        StartCoroutine(EnemyStuned());
    }
}
