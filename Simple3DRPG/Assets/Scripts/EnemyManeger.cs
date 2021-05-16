using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManeger : MonoBehaviour
{
  NavMeshAgent agent;
  public Transform target;
  Animator animator;
  int hp;
    // Start is called before the first frame update
    void Start()
    {
      agent = GetComponent<NavMeshAgent>();
      agent.destination = target.position;
      animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
  agent.destination = target.position;
  float distance = Vector3.Distance(target.position, transform.position);
  if(distance < 2)
  {
    agent.speed = 0;
  }
  else if(distance < 7)
  {
    agent.speed = 2;
  }else
  {
    agent.speed = 0;
  }
  animator.SetFloat("distance", distance);
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
