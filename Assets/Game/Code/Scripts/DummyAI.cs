using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DummyAI : Dummy
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(MoveCoroutine());

        SetCurrentMoveSpeed(baseMoveSpeed);
    }

    private IEnumerator MoveCoroutine()
    {
        float intervals = 1f;
        float goal = 1f;
        float progress = 0;

        while(true)
        {
            while (progress < goal)
            {
                progress += Time.deltaTime;
                yield return new WaitForFixedUpdate();
                rb.AddForce(transform.forward * currentMoveSpeed);
            }
            yield return new WaitForSeconds(intervals);
            transform.Rotate(transform.up, 180);
            progress = 0;
        }
    }
}
