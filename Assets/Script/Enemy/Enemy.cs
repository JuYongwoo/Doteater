using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    private NavMeshAgent agent; //NavMeshAgent 컴포넌트 선언
    private Animator anim;

    private void Start()
    {
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        agent.destination = target.transform.position;
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
