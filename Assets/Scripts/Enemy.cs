using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // particle object
    [SerializeField] GameObject Particle;

    #region  food eating field
    Food Pos;
    float Timer = 3f;
    float Tiktak = 0f;
    #endregion


    NavMeshAgent Agent;
    int numa = 0;
    int PlusValu;
    public int Numa { get { return numa; } set {  value=PlusValu;         }
    }
  playerMovement Players;
  [SerializeField]  LayerMask layerFood;
    private bool locked = false;
    bool PlayerOnArea = false;
    Vector3 plus = new Vector3(0.001f, 0.001f, 0.001f);
    float LockTimer,lockTİme = 3f;
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Players = FindObjectOfType<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Distance(Players.transform.position, transform.position) < 4f)
        {
            PlayerOnArea = true;
            if (Players.GetComponent<playerMovement>().yumiyumi > numa)
            {
                Vector3 directionPlayer = transform.position - Players.transform.position;
                Vector3 newPos = transform.position + directionPlayer;
                Agent.SetDestination(newPos);

            }
            else if (Players.GetComponent<playerMovement>().yumiyumi <numa) {

                Agent.SetDestination(Players.transform.position);
               
            }
}else
        {
            PlayerOnArea = false;
        }


        LockTimer += Time.deltaTime;

        if (LockTimer > lockTİme)
        {
            locked = false;
            LockTimer = -4f;

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (PlayerOnArea == false)
        {
            if (!locked)
            {
                if (other.gameObject.tag == "Food")
                {
                    locked = true;


                    Agent.SetDestination(other.transform.position);

                }
            }
        }

        if (other.gameObject.tag == "enemy")
        {
            if(Vector3.Distance(other.gameObject.transform.position, transform.position) < 3f)
            {
                PlayerOnArea = true;
                if (other.gameObject.GetComponent<Enemy>().Numa > numa)
                {
                    Vector3 directionPlayer = transform.position - other.gameObject.transform.position;
                    Vector3 newPos = transform.position + directionPlayer;
                    Agent.SetDestination(newPos);
                }
                else
                {
                    Vector3 directionPlayer = transform.position - other.gameObject.transform.position;
                    Vector3 newPos = transform.position + directionPlayer;
                    Agent.SetDestination(-newPos);

                  
                }
            }
            else
            {
                PlayerOnArea = false;

            }


        }
    }
    #region collision check
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Food")
        {

            numa++;
            transform.localScale += numa * plus/5;

            locked = false;
        }
        if(collision.gameObject.tag== "Player")
        {
            if (numa < collision.gameObject.GetComponent<playerMovement>().yumiyumi)
            {
                Instantiate(Particle, transform.position, Quaternion.identity);
              //  collision.gameObject.GetComponent<playerMovement>().yumiyumi += numa/5;
                Destroy(this.gameObject);
            }
            
        }
        if (collision.gameObject.tag == "enemy")
        {

            if (numa < collision.gameObject.GetComponent<Enemy>().Numa)
            {
                collision.gameObject.GetComponent<Enemy>().Numa += numa;

                Destroy(this.gameObject);

            }else if((numa > collision.gameObject.GetComponent<Enemy>().Numa)){

                transform.localScale += collision.gameObject.GetComponent<Enemy>().Numa * plus/5;

            }

        }
    }
    #endregion
}
