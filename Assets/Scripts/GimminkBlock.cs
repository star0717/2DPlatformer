using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimminkBlock : MonoBehaviour
{
    public float length = 0.0f; //�ڵ� ���� Ž�� �Ÿ�
    public bool isDelete = false; // ���� �� ������ �� ����

    bool isFell = false;
    float fadeTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

    // ���� �ù����̼� ����
    Rigidbody2D rbody = GetComponent<Rigidbody2D>();
    rbody.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); //�÷��̾� ã��
        if (player != null)
        {
            //�÷��̾�������� �Ÿ� ���
            float d = Vector2.Distance(transform.position, player.transform.position);
            if(length >= d)
            {
                Rigidbody2D rbody = GetComponent<Rigidbody2D>();
                if (rbody.bodyType == RigidbodyType2D.Static)
                {
                    //���� �ù����̼� ����
                    rbody.bodyType = RigidbodyType2D.Dynamic;
                }
            }
        }

        if (isFell)
        {
            // ����
            // ������ �����Ͽ� ���̵� �ƿ� ȿ��
            fadeTime -= Time.deltaTime;
            Color col = GetComponent<SpriteRenderer>().color; //�÷��� ��������
            col.a = fadeTime; //���� ����
            GetComponent<SpriteRenderer>().color = col; //�÷��� �缳��
            if(fadeTime <= 0.0f)
            {
                // 0���� ������ ����ȿ�� ����
                Destroy(gameObject);
            }
        }
    }

    //���� ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDelete)
        {
            isFell = true; //���� �÷���
        }
    }
}
