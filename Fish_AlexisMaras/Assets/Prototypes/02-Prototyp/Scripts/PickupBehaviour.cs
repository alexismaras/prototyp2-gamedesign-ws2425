using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{

    [SerializeField] HudControler hud;
    float screenHeight;
    float screenWidth;
    float pickupObjectHeight = 0.8f;
    float pickupObjectWidth = 0.8f;

    SpriteRenderer spriteRenderer;
    CircleCollider2D circleCollider2D;
    float numberMovementSpeed = 0.05f;
    Vector3 moveDown = new Vector3(0, 1, 0);

    public bool isBeingDestroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        GetScreenSize();
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        if (tag == ("Odd") || tag == ("Even") || tag == ("Book"))
        {
            transform.position = GetRandomSpawnPosition();
            spriteRenderer.enabled = true;
            circleCollider2D.enabled = true;
        }
        else if (tag == "InstanceBlueprint")
        {
            spriteRenderer.enabled = false;
            circleCollider2D.enabled = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePickupObject();
    }
    
    void Update()
    {

    }

    void MovePickupObject()
    {
        if (tag == ("Odd") || tag == ("Even") || tag == ("Book"))
        {
            transform.Translate(moveDown * numberMovementSpeed * (-1));
        }
    }

    void GetScreenSize()
    {
        screenWidth = Screen.width * 0.02f;
        screenHeight = Screen.height * 0.02f;
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 randomSpawnPosition = new Vector3(
                (Random.Range((screenWidth * (-1) * 0.5f) + pickupObjectWidth, (screenWidth * 0.5f) - pickupObjectWidth)),
                screenHeight * 0.5f + pickupObjectHeight * 0.5f,
                0);
        return randomSpawnPosition;
    }

    void OnBecameInvisible()
    {
        if (isBeingDestroyed)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            if (tag == "Even")
            {
                hud.score -= 1;
            }
            
        }

    }

}
