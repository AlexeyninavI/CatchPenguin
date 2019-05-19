using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimatorSpeed : MonoBehaviour
{
    public GameObject objectTarget;
    public float minSpeed = 0.4f;
    public float maxSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Animator animator = objectTarget.GetComponent<Animator>();
        animator.speed = Random.Range(minSpeed, maxSpeed);
    }
}
