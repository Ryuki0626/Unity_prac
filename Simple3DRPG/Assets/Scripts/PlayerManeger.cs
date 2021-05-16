using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManeger : MonoBehaviour
{
  float x;
  float z;
  Rigidbody rb;
  Animator animator;
  int hp = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         x = Input.GetAxisRaw("Horizontal");
         z = Input.GetAxisRaw("Vertical");
         if(Input.GetKeyDown(KeyCode.Space))
         {
           animator.SetTrigger("Attack");
         }

    }
    private void FixedUpdate()
    {
      Vector3 direction = transform.position + new Vector3(x,0,z);
      transform.LookAt(direction);
      rb.velocity = new Vector3(x,0,z)*3f;
      animator.SetFloat("Speed", rb.velocity.magnitude);
    }

    void Damage(){
      hp  -= 0;
      if(hp <= 0){
        animator.SetTrigger("Die");
      }
    }

    private void OnTriggerEnter(Collider other)
    {
      Damager damager = other.GetComponent<Damager>();
      if(damager != null)
      {
         animator.SetTrigger("Hurt");
         Damage();
      }
    }
}
