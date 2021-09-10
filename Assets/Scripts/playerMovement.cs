using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{

    //movement
    Rigidbody Rb;
    Vector3 Movement;
    float InputX, InputZ;
    [SerializeField] float Speed = 3f;
    float NegatifSpeed = .000001f;
    [SerializeField] float Gravity = 2f;
    [SerializeField] Joystick stick;

//soundfx

    AudioSource source;
   [SerializeField] AudioClip food;
    [SerializeField] AudioClip EnemyEat;

   //boyut büyütme
    float YumYUmPoint = 0;
    float YumiYumiartıs; 
    Vector3 plus = new Vector3(0.0001f, 0.0001f, 0.0001f);

    // skor
    int skor = 0;
  [SerializeField]  Text skorsis;

 
    //scalepoint up Getter&setter
    public float yumiyumi
    {
        get
        {
            return YumYUmPoint;

        }
        set
        {
            YumiYumiartıs = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //pc        movemeny
        //   InputX = Input.GetAxis("Horizontal")*-Speed;
        // InputZ = Input.GetAxis("Vertical")*-Speed;

        // ios&android movement
        InputX = stick.Horizontal* -Speed;
        InputZ = stick.Vertical * -Speed;

        //rb movement
        Movement = new Vector3(InputX, -Gravity, InputZ);
        Rb.velocity = Movement;

        //skorUı
       skorsis.text ="SKOR :"+ skor.ToString();
       

    }

   
  
    private void OnCollisionEnter(Collision collision)
    { //collisionController for enemy
        if (collision.gameObject.tag == "enemy")
        {
          if(  collision.gameObject.GetComponent<Enemy>().Numa < yumiyumi)
            {
                skor  += collision.gameObject.GetComponent<Enemy>().Numa;
                YumYUmPoint += collision.gameObject.GetComponent<Enemy>().Numa;
                transform.localScale = transform.localScale + plus*YumYUmPoint/5;
                source.PlayOneShot(EnemyEat);
                NegatifSpeed += skor * .001f;

            }
            else if(collision.gameObject.GetComponent<Enemy>().Numa > yumiyumi)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }
    } 
    //collisionController for Food
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Food")
        {

           
            YumYUmPoint++;
            transform.localScale = transform.localScale + plus*YumYUmPoint/5 ;
            source.PlayOneShot(food);
            skor++;
            NegatifSpeed += skor * .00001f;
            Speed -=Speed*NegatifSpeed ;
        }
    }
}
