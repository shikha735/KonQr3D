using UnityEngine;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class Move : MonoBehaviour
{
    [SerializeField, HideInInspector]
    NavMeshAgent agent;
    [SerializeField, HideInInspector]
    Animator animator;

    void Reset()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        animator.SetFloat("Speed", agent.velocity.sqrMagnitude);
    }
}