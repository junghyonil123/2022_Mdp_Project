using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportation : MonoBehaviour
{
    public Transform teleportspot;
    public GameObject XrOrigin;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("�ھҾ��");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("�÷��̾��");
            collision.gameObject.transform.Translate(teleportspot.position);
        }
            
       
    }
}
