using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���ݺ��� ¥�� ������ �ڵ�� ����Ƽ �������� ���ư� = �����ٷ�
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody; // Rigidbody2D�� ����
    float axisH = 0.0f; // ���� �Է�
    float axisV = 0.0f; // ���� �Է�
    public float speed  = 18.0f;
    // 1���� ����Ǵ� �Լ��� Update �Լ����� �켱������ �����
    void Start()
    {
        // Rigidbody2D ��������
        rbody = this.GetComponent<Rigidbody2D>();
    }

    // �����Ӹ��� �� ��
    // ȭ�鿡�� ������ ���ִ� ��ġ
    // ȭ�� ����,���� ��ǲ ó��
    // �����Ӹ��� �ݺ��ǹǷ� update�� ���ϰ� ����ϸ� ������ ���ϵ� �� ����
    void Update()
    {
        // ����, ���� ����Ű �Է� Ȯ��()
        axisH = Input.GetAxisRaw("Horizontal");
        axisV = Input.GetAxisRaw("Vertical");
        // ���� ��ȯ
        if(axisH > 0.0f){
            // ������ �̵�
            Debug.Log("������ �̵�");
            transform.localScale = new Vector2(2,2);
        } else if(axisH < 0.0f){
            // ���� �̵�
            Debug.Log("���� �̵�");
            transform.localScale = new Vector2(-2,2); // �¿� ���� ��Ű��
        }
    }

    // Ư�� �ð����� �� �� ȣ�� ��
    // Ư�� �ð��� �⺻ �� = 0.02��
    // �ݵ�� ������ �ð��� ȣ�� �� = ������Ʈ���� �켱 ����
    // ������ ����� �����ϱ� ���� ��ġ = ���� 0.02�ʸ��� ȣ���� �ȵ� ��� ���� �ý��� ��ü�� ���ߴ� ��Ȳ �߻� ���ɼ� ����
    // ȭ�鿡�� �������� �����ŷ��� ������ �۵��ϰ� ������ ȭ���� �������� ����ϴ� �κ��� ������Ʈ
    void FixedUpdate()
    {

        Debug.Log(rbody.velocity.y);
        // Vector(�ӵ�,����)����
        // Vector2 = x,y Vector3 = x,y,z
        // rbody.velocity.y = y���� �߷��� ���� �״�� �������� ���ڴٴ� ��
         rbody.velocity = new Vector2(speed * axisH, speed * axisV);
    }
}
