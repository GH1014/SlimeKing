using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeedx;
    public float maxSpeedy;
    public float jumpPower;
    public PhysicsMaterial2D Player_jump, Player_idle;
    public bool isGrounded;

    public bool inputLeft;
    public bool inputRight;
    public bool inputJump;

    public AudioClip AudioJump;
    public AudioClip AudioCharge;
    public AudioClip AudioCollision;

    AudioSource AudioSource;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    BoxCollider2D bc;

    float time = 1;
    float move;

    void Awake()
    {
        inputLeft = false;
        inputRight = false;
        inputJump = false;

        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        AudioSource = GetComponent<AudioSource>();

        ButtonManager buttonManager = GameObject.FindGameObjectWithTag("ButtonManager").GetComponent<ButtonManager>();
        buttonManager.Init();
    }

    void Update()
    {
        //차징
        if (inputJump && !anim.GetBool("isJumping"))
        {
            if (AudioSource.isPlaying == false)
            {
                AudioChange(AudioCharge, AudioSource);
            }
            
            time += Time.deltaTime;

            rigid.velocity = new Vector2(0, rigid.velocity.y);

            anim.SetBool("isChar", true);
        }

        //점프
        if (!inputJump && !anim.GetBool("isJumping") && anim.GetBool("isChar"))
        {
            AudioChange(AudioJump, AudioSource);

            rigid.AddForce(Vector2.up * jumpPower * Mathf.Clamp(time, 1, 2.5f), ForceMode2D.Impulse);

            if (inputLeft)
            {
                rigid.AddForce(Vector2.left * jumpPower/2 * Mathf.Clamp(time, 1, 2.5f), ForceMode2D.Impulse);

            }
            else if(inputRight)
            {
                rigid.AddForce(Vector2.right * jumpPower/2 * Mathf.Clamp(time, 1, 2.5f), ForceMode2D.Impulse);
            }

            anim.SetBool("isChar", false);
            anim.SetBool("isJumping", true);

            rigid.sharedMaterial = Player_jump;
            bc.sharedMaterial = Player_jump;

            time = 1;
        }
        
        //방향 바꾸기
        if (inputLeft)
        {
            move = -1;
            spriteRenderer.flipX = true;
        }
        else if (inputRight)
        {
            move = 1;
            spriteRenderer.flipX = false;
        }

        //애니메이션
        if (Mathf.Abs(rigid.velocity.x) < 0.3)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }

        //랜딩 플랫폼 변수 선언
        isGrounded = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 0.6f), 0.4f, LayerMask.GetMask("Platform"));

        //랜딩 플랫폼
        if (rigid.velocity.y < -0.01)
        {
            anim.SetBool("isJumping", true);

            rigid.sharedMaterial = Player_jump;
            bc.sharedMaterial = Player_jump;

            if (isGrounded)
            {
                anim.SetBool("isJumping", false);

                rigid.sharedMaterial = Player_idle;
                bc.sharedMaterial = Player_idle;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //버튼 업 이벤트 시 초기화
        if(!(inputLeft || inputRight))
        {
            move = 0;
        }

        //움직임 구현
        if (!anim.GetBool("isChar") && !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.right * move, ForceMode2D.Impulse);
        }

        //최대속도 설정
        if (!anim.GetBool("isJumping"))
        {
            if (rigid.velocity.x > maxSpeedx)
            {
                rigid.velocity = new Vector2(maxSpeedx, rigid.velocity.y);
            }
            else if (rigid.velocity.x < maxSpeedx * (-1))
            {
                rigid.velocity = new Vector2(maxSpeedx * (-1), rigid.velocity.y);
            }
        }
        else
        {
            if (rigid.velocity.y > maxSpeedy)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, maxSpeedy);
            }
            else if (rigid.velocity.y < maxSpeedy * (-1))
            {
                rigid.velocity = new Vector2(rigid.velocity.x, maxSpeedy * (-1));
            }
        }
    }

    //충돌 시 사운드 재생
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioChange(AudioCollision, AudioSource);

        //마지막 씬 넘기기
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("Ending");
        }
    }
    //효과음 변경
    void AudioChange(AudioClip audioClip, AudioSource audioSource)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    //볼륨 조절
    public void SetMusicVolume(float volume)
    {
        AudioSource.volume = volume;
    }
}
