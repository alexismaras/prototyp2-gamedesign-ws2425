using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    [SerializeField] GameObject fish;
    [SerializeField] float movementSpeed;
    [SerializeField] float playerSize;
    [SerializeField] Animator fishAnimator;
    [SerializeField] HudControler hud;
    [SerializeField] FishSoundSystem fishSoundSystem;
    [SerializeField] AudioSource pickupSound;
    [SerializeField] AudioSource bookChoir1;
    [SerializeField] AudioSource bookChoir2;
    [SerializeField] AudioSource bookChoir3;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDir;
    bool borderHitLeft;
    bool borderHitRight;
    float screenWidth;
    float screenHeight;   
    bool moving;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        moveDir = new Vector3(horizontalInput, 0, 0);
        if (horizontalInput != 0)
        {
            moving = true;
            fishSoundSystem.idleSound.Stop();
        }
        else
        {
            moving = false;
        }
        fishAnimator.SetBool("moving", moving);
        RotateFish();
        GetScreenSize();
        ScreenBorder();
        
    }

    void FixedUpdate()
    {
        
        if(borderHitLeft && horizontalInput == (-1))
        {

        }
        else if(borderHitRight && horizontalInput == 1)
        {

        }
        else
        {
            rigidbody2D.MovePosition(transform.position + moveDir * movementSpeed);
            // transform.Translate(moveDir * movementSpeed);
        }
    }

    void RotateFish()
    {
        if (moveDir != Vector3.zero)
        {
            fish.transform.right = moveDir.normalized;
        }
    }

    void GetScreenSize()
    {
        screenWidth = Screen.width * 0.02f;
        screenHeight = Screen.height * 0.02f;
    }

    void ScreenBorder()
    {
        if ((transform.position.x + (playerSize * 0.5f)) > (screenWidth * 0.5f))
        {
            borderHitRight = true;
            borderHitLeft = false;
        }
        else if((transform.position.x - (playerSize * 0.5f)) < (screenWidth * 0.5f * (-1)))
        {
            borderHitLeft = true;
            borderHitRight = false;
        }
        else
        {
            borderHitLeft = false;
            borderHitRight = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Even")
        {
            PickupBehaviour pickupBehaviour = collision.gameObject.GetComponent<PickupBehaviour>();
            pickupBehaviour.isBeingDestroyed = true;
            pickupSound.Play();
            hud.score += 1;
            Debug.Log("LOLOL" + hud.score);
        }
        else if (collision.gameObject.tag == "Odd")
        {
            pickupSound.Play();
            hud.score -= 1;
            Debug.Log("biggo");
        }
        else if (collision.gameObject.tag == "Book")
        {
            if (hud.booksCollected == 0)
            {
                bookChoir1.Play();
                
            }
            else if (hud.booksCollected == 1)
            {
                bookChoir2.Play();
            
            }
            else if(hud.booksCollected == 2)
            {
                bookChoir3.Play();
            }
            hud.booksCollected += 1;
            hud.ChangeBookScoreboard();
        }
        Destroy(collision.gameObject);
    }

    
}
