using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public int m_PlayerNumber;
    public float m_Speed = 10f;

    public int m_Health = 100;
    public int m_MaxHealth = 100;

    private string m_MovementAxisName;
    private Rigidbody2D m_Rigidbody;
    private Vector2 m_Movement;
    private SpriteRenderer m_Renderer;

    private Animator m_Animator;


    // Start is called before the first frame update
    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        m_Renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        m_MovementAxisName = "Vertical" + m_PlayerNumber;
        if (m_PlayerNumber == 1)
            m_Renderer.flipX = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (m_Animator.GetBool("Explode"))
            return;

        m_Movement.y = Input.GetAxisRaw(m_MovementAxisName);
        if (m_Movement.y != 0)
        {
            m_Animator.SetBool("Moving", true);
        }
        else
            m_Animator.SetBool("Moving", false);

         StartCoroutine(Explode());
    }


    private IEnumerator Explode()
    {
       yield return new WaitForSeconds(5f);

        m_Animator.SetBool("Explode", true);
        yield return new WaitForSeconds(.7f);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Speed * Time.fixedDeltaTime);
    }

    public void Damage(int dmg)
    {
        if (m_Health <= dmg)
        {

            m_Health = 0;
            Explode();
            return;
        }
        m_Health -= dmg;
    }
}
