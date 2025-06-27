using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    NavMeshAgent agent; //NavMeshAgent 컴포넌트 선언
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position;//agent의 목적지는 target의 트랜스폼
        anim.SetFloat("Speed", agent.velocity.magnitude);
    }


    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player"){
            Player player = other.GetComponent<Player>();


            player.getDamaged();
        }
    }
}
