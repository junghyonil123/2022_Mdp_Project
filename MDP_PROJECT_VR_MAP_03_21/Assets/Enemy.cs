using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent navAgent;
    public Transform player_kill_pos;
    private Rigidbody rigid;
    private Animator animator;
    private AudioSource audiosourece;
    public AudioClip catch_audio;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        audiosourece = GetComponent<AudioSource>();
        target = GameObject.Find("Player").transform;
        navAgent = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        freezevelocity();
        navAgent.SetDestination(target.position);
    }

    void freezevelocity()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    void navstop()
    {
        this.navAgent.isStopped = true;
    }

    void navgo()
    {
        this.navAgent.isStopped = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("CATCH");
            audiosourece.clip = catch_audio;
            audiosourece.Play();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("¿‚æ“¥Á");
            kill_player();
        }
    }

    public void kill_player()
    {
        
        Camera.main.transform.position = player_kill_pos.position;
        Camera.main.transform.eulerAngles = new Vector3(0, player_kill_pos.eulerAngles.y -200.0f, 0);
        Camera.main.GetComponent<Player_Camera>().camera_can_move = false;
    }
}
