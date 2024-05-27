using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBrick : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform collcheck;
    [SerializeField] private LayerMask characterLayer;
    [SerializeField] public float delayBrick = 1.0f;

    private Vector3 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding())
        {
            StartCoroutine(FallSequence()); 
        }
    }

    private bool isColliding()
    {
        return Physics2D.OverlapCircle(collcheck.position, 0.2f, characterLayer);
    }

    IEnumerator FallSequence()
    {
        yield return new WaitForSeconds(delayBrick);
        rb.isKinematic = true;
        rb.velocity = new Vector2(0, -30);
        yield return new WaitForSeconds(5.0f);
        transform.position = spawnPosition;
        rb.velocity = new Vector2(0, 0);
    }
}
