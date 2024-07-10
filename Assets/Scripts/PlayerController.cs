using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rbody; // Rigidbody2D형의 변수
    float axisH = 0.0f;// 입력
    public float speed = 3.0f; // 이동 속도

    public float jump = 9.0f; // 점프력
    public LayerMask groundLayer; // 착지할 수 있는 레이어
    bool goJump = false; // 점프 개시  플래그
    bool onGround = false; // 지면에 서 있는 플래그

    Animator animator; //애니메이터
    public string stopAnime = "PlayerStop";
    public string moveAnime = "PlayerMove";
    public string jumpAnime = "PlayerJump";
    public string goalAnime = "PlayerGoal";
    public string deadAnime = "PlayerOver";
    string nowAnime = "";
    string oldAnime = "";

    public static string gameState = "playing"; //게임 상태

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody2D 가져오기
        rbody = this.GetComponent<Rigidbody2D>();
        //Animator 가져오기
        animator = GetComponent<Animator>();
        nowAnime = stopAnime;
        oldAnime = stopAnime;

        gameState = "playing"; //게임 중
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState != "playing")
        {
            return;
        }
        //수평 방향의 입력 확인
        axisH = Input.GetAxisRaw("Horizontal");
        if (axisH > 0.0f)
        {
            //오른쪽 이동
            Debug.Log("오른쪽 이동");
            transform.localScale = new Vector2(1, 1);
        }
        else if (axisH < 0.0f)
        {
            //왼쪽 이동
            Debug.Log("왼쪽 이동");
            transform.localScale = new Vector2(-1, 1); // 좌우 반전시키기
        }
        //캐릭터 점프하기
        if (Input.GetButtonDown("Jump"))
        {
            Jump(); //점프
        }

    }

    void FixedUpdate()
    {
        if (gameState != "playing")
        {
            return;
        }
        //착지 판정
        onGround = Physics2D.Linecast(transform.position, transform.position - (transform.up * 0.1f), groundLayer);
        Debug.DrawRay(transform.position, transform.up * -0.1f, Color.red);
        //Debug.Log("착지댐?"+onGround);
        if (onGround || axisH != 0)
        {
            //지면 위 or 속도가 0 아님
            //속도 갱신하기
            rbody.velocity = new Vector2(speed * axisH, rbody.velocity.y);
        }
        if (onGround && goJump)
        {
            // 지면 위에서 점프 키 눌림
            // 점프하기
            Debug.Log(" 점프! ");
            Vector2 jumpPW = new Vector2(0, jump); // 점프를 위한 벡터 생성
            rbody.AddForce(jumpPW, ForceMode2D.Impulse); // 순간적인 힘 가하기
            goJump = false; //점프 플래그 끄기
        }

        if (onGround)
        {
            // 지면 위
            if (axisH == 0)
            {
                nowAnime = stopAnime; //정지
            }
            else
            {
                nowAnime = moveAnime; //이동
            }
        }
        else
        {
            nowAnime = jumpAnime;
        }

        if (nowAnime != oldAnime)
        {
            oldAnime = nowAnime;
            animator.Play(nowAnime); // 애니메이션 재생
        }
    }
    //점프
    public void Jump()
    {
        goJump = true; // 점프 플래그 켜기
        Debug.Log("점프 버튼 눌림!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Goal();
        }
        else if (collision.gameObject.tag == "Dead")
        {
            GameOver();
        }
    }
    public void Goal()
    {
        animator.Play(goalAnime);
        gameState = "gameclear";
        GameStop(); //게임 중지
    }
    public void GameOver()
    {
        animator.Play(deadAnime);

        gameState = "gameover";
        GameStop(); //게임중지
        GetComponent<CapsuleCollider2D>().enabled = false;
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }

    void GameStop()
    {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        rbody.velocity = new Vector2(0, 0);

        //보통 아래의 속성들을 게임이 멈출때 함께 사용함, 하지만 이 게임에서는
        //게임 오버시 튀어 오르는 연출이 있으므로 사용하지 않음.
        //1.collier 비활성화
        //CapsuleCollider2D collider = GetComponent1<Rigidbody2D>();
        //Collider.enabled = false;
        //2. Rigidbody 물리속성 해제
        //rbody.bodyType = RigidbodyType2D.Static;
    }
}
