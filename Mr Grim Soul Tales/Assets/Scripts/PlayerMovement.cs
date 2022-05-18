using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public string keyMoveUp;
    public string keyMoveDown;
    public string keyMoveRight;
    public string keyMoveLeft;

    public Joystick joystick;

    public GameObject slashHitRight;
    public GameObject slashHitLeft;

    public GameObject inGameSettings;
    public HealthBarScript HealthBar;


    public GameObject inGamePanel;
    public GameObject gameOverPanel;
    public Animation startGame;

    public Animator animController;

    public SpriteRenderer spriteGrimm;
    public Image fillBar;

    public Rigidbody2D myRigidBody;
    public Collider2D myCollider;
    public Transform myTransform;
    public PolygonCollider2D col;
    public List<Vector2> physicsShape = new List<Vector2>();

    //   public bool spriteFlip;
    public bool isJumping;
    public bool jump;
    public bool lookLeft;
    public bool lookRight;
    public bool isGrounded;
    public bool isControlEnb;
    public bool isPlayerDead;
    public bool gameStart;

    public LayerMask whatIsGround;
    public float speed = 1.2f;
    public float jumpcd = 1f;

    public int jumpforce = 20;
    public int maxHp = 100;
    public int tempHp;
    public int obstacleDmg = 10;
    public int enemyHitDmg = 8;
    
   
   
    void Start()
    {

    
       
        tempHp = maxHp;

        HealthBar.SetHealth(maxHp);
        col = GetComponent<PolygonCollider2D>();
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        spriteGrimm = GetComponent<SpriteRenderer>();
        myTransform = GetComponent<Transform>();
    }
    void Update()
    {
       
        if (isControlEnb)
        {
          
            PlayerControl();
            spriteGrimm.sprite.GetPhysicsShape(0, physicsShape);
            col.SetPath(0, physicsShape);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Invoke("HitBox", .25f);
                Invoke("SlashAttack", .1f);
                Invoke("SlashAttackDone", .4f);
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                inGameSettings.SetActive(true);
                isControlEnb = false;
            }

        }
        if(tempHp <=0)
        {
            isControlEnb = false;
            gameStart = false;
            animController.SetBool("isDead", true);
            inGameSettings.SetActive(false);
            inGamePanel.SetActive(false);

            Invoke("delayGameOver", .9f);
        }
        if (tempHp > 75) { FillColorChange(0, 255, 0, 255); }
        if (tempHp <= 75) { FillColorChange(255, 255, 0, 255);  }
        if (tempHp <= 20){ FillColorChange(255, 0, 0, 255); }
    }
   public void FillColorChange(int r, int g, int b, int a)
    {
        fillBar.color = new Color(r, g, b, a);

    }
    public void SlashAttackDone()
    {
        animController.SetBool("isAttackRight", false);
        animController.SetBool("isAttackLeft", false);
        slashHitRight.SetActive(false);
        slashHitLeft.SetActive(false);
    }
    public void HitBox()
    {
        if (lookRight == true)
        {
            
            slashHitRight.SetActive(true);

        }

        if (lookLeft == true)
        {
            slashHitLeft.SetActive(true);

        }
       
   
    }
    public void SlashAttack()
    {
        if (lookRight == true)
        {
          
            animController.SetBool("isAttackRight", true);
          
        }

        if (lookLeft == true)
        {
            animController.SetBool("isAttackLeft", true);
           
        }

    }

    void JumpingAnim()
    {
      
        if (lookRight == true)
        {
            animController.SetBool("isJumpingRight", true);

        }

        if (lookLeft == true)
        {
            animController.SetBool("isJumpingLeft", true);

        }
    }
    public void ButtonAtk()
    {
        Invoke("HitBox", .25f);
        Invoke("SlashAttack", .1f);
        Invoke("SlashAttackDone", .4f);
    }
 
    public void resetIsJumping()
    {
        isJumping = false;
        animController.SetBool("isJumpingRight", false);
        animController.SetBool("isJumpingLeft", false);
    }
    void PlayerControl()
    {
       
            isGrounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
            if (isGrounded)
            {
                if (Input.GetKey(keyMoveRight) || joystick.Horizontal >= .2f)
                {
                    animController.SetBool("isWalkRight", true);
                    lookRight = true;
                    lookLeft = false;
                    myRigidBody.velocity = new Vector2(speed, myRigidBody.velocity.y);

                }
                else
                {


                    animController.SetBool("isWalkRight", false);

                }
                if (Input.GetKey(keyMoveLeft) || joystick.Horizontal <= -.2f)
                {
                    animController.SetBool("isWalkLeft", true);
                    myRigidBody.velocity = new Vector2(-speed, myRigidBody.velocity.y);
                    lookLeft = true;
                    lookRight = false;
                    /*   if (spriteFlip == false)
                       {
                           transform.Rotate(0, 180, 0);
                           spriteFlip = true;
                       */

                }
                else
                {

                    animController.SetBool("isWalkLeft", false);
                }
                if (Input.GetKey(KeyCode.Space))
                {
                    if (!isJumping)
                    {
                        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpforce);
                        JumpingAnim();
                        isJumping = true;
                        Invoke("resetIsJumping", jumpcd);
                    }


                }

            
                /*   if(Input.touchCount == 1)
                   {
                       myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpforce);

                   }*/

            }
        
    }
    public void Jumping()
    {
        if (!isJumping)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpforce);
            JumpingAnim();
            isJumping = true;
            Invoke("resetIsJumping", jumpcd);
        }
       
    }
    void takeDamage(int damage)
    {
       
        tempHp -= damage;
        HealthBar.SetHealth(tempHp);
        Invoke("TakeDamageColor", 0.1f);
        Invoke("NormalizeColor", 0.2f);

    }
  
    public void TakeDamageColor()
    {
        spriteGrimm.color = new Color(183, 0, 0, 255);
    }
    public void NormalizeColor()
    {
        spriteGrimm.color = new Color(255, 255, 255,255);
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Plant"))
        {
            takeDamage(obstacleDmg);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            takeDamage(enemyHitDmg);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Death"))
        {
            isControlEnb = false;
            animController.SetBool("isDead", true);
            inGameSettings.SetActive(false);
            inGamePanel.SetActive(false);

            Invoke("delayGameOver", .9f);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            takeDamage(enemyHitDmg);
        }
        if (collision.gameObject.CompareTag("End"))
        {
            takeDamage(enemyHitDmg);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            takeDamage(enemyHitDmg);
        }


    }
    public void delayGameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
/*  
      > Not compatible with the current code.
        [SerializeField] PolygonCollider2D[] grimPoly;
        private int currentColliderIndex = 0;
        public void SetColliderForSprite (int spriteNum)
        {
            grimPoly[currentColliderIndex].enabled = false;
            currentColliderIndex = spriteNum;

            grimPoly[currentColliderIndex].enabled = true;

        }*/
