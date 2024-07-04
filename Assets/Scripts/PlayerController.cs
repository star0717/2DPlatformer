using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 지금부터 짜는 본인의 코드는 유니티 엔진에서 돌아감 = 스케줄러
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody; // Rigidbody2D형 변수
    float axisH = 0.0f; // 수평 입력
    float axisV = 0.0f; // 수직 입력
    public float speed  = 18.0f;
    // 1번만 실행되는 함수로 Update 함수보다 우선적으로 실행됨
    void Start()
    {
        // Rigidbody2D 가져오기
        rbody = this.GetComponent<Rigidbody2D>();
    }

    // 프레임마다 한 번
    // 화면에서 렌더링 해주는 장치
    // 화면 변경,유저 인풋 처리
    // 프레임마다 반복되므로 update를 과하게 사용하면 성능이 저하될 수 있음
    void Update()
    {
        // 수평, 수직 방향키 입력 확인()
        axisH = Input.GetAxisRaw("Horizontal");
        axisV = Input.GetAxisRaw("Vertical");
        // 방향 전환
        if(axisH > 0.0f){
            // 오른쪽 이동
            Debug.Log("오른쪽 이동");
            transform.localScale = new Vector2(2,2);
        } else if(axisH < 0.0f){
            // 왼쪽 이동
            Debug.Log("왼쪽 이동");
            transform.localScale = new Vector2(-2,2); // 좌우 반전 시키기
        }
    }

    // 특정 시간마다 한 번 호출 됨
    // 특정 시간의 기본 값 = 0.02초
    // 반드시 지정된 시간에 호출 됨 = 업데이트보다 우선 순위
    // 프레임 드롭을 방지하기 위한 장치 = 만약 0.02초마다 호출이 안될 경우 게임 시스템 전체가 멈추는 상황 발생 가능성 있음
    // 화면에서 프레임이 버벅거려도 실제론 작동하고 있지만 화면의 프레임을 담당하는 부분은 업데이트
    void FixedUpdate()
    {

        Debug.Log(rbody.velocity.y);
        // Vector(속도,방향)갱신
        // Vector2 = x,y Vector3 = x,y,z
        // rbody.velocity.y = y값에 중력의 힘을 그대로 가져가서 쓰겠다는 뜻
         rbody.velocity = new Vector2(speed * axisH, speed * axisV);
    }
}
