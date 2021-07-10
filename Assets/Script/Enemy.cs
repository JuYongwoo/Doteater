using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent; //NavMeshAgent 컴포넌트 선언
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>(); //플레이어에 썼던 애니메이션 넣어놨으므로 모션같음
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position;//agent의 목적지는 target의 트랜스폼
        anim.SetFloat("Speed", agent.velocity.magnitude);
    }
}
