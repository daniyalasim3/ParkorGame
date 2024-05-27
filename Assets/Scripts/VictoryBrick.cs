using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class VictoryBrick : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform collcheck;
    [SerializeField] private LayerMask characterLayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding())
        {
            StartCoroutine(VictorySequence());
        }
    }

    private bool isColliding()
    {
        return Physics2D.OverlapCircle(collcheck.position, 0.2f, characterLayer);
    }

    IEnumerator VictorySequence()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadSceneAsync(3);
    }
}
