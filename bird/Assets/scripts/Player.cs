using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigibodyBird;

    public float force;

    public Animator ani;

    private bool Death = false;

    public delegate void DeathNotify();

    public event DeathNotify OnDeath;

    public UnityAction<int> Onscore;

    public Vector3 Initpos;
    public Vector3 Initrot;
    // Start is called before the first frame update
    void Start()
    {
        this.Idle();
        Initpos = this.transform.position;
        Initrot = this.transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Death) return;
        if (Input.GetMouseButtonDown(0))
        {
            rigibodyBird.velocity = Vector2.zero;
            rigibodyBird.AddForce(new Vector2(0, force),ForceMode2D.Force);
            rigibodyBird.velocity = new Vector2(0,-0.5f);
        }
    }

    public void Init()
    {
        this.transform.position = Initpos;
        this.transform.localEulerAngles = Initrot;
        this.Idle();
        this.Death = false;
    }

    public void Die()
    {
        this.Death = true;
        if (this.OnDeath != null)
        {
            this.OnDeath();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("scorearea")) { }
        else
            this.Die();
    } 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("scorearea"))
        {
            if (this.Onscore != null)
            {
                this.Onscore(1);
            }
        }
    }

    public void Idle()
    {
        this.rigibodyBird.Sleep();
        this.rigibodyBird.simulated = false;
        this.ani.SetTrigger("Idle");
    }
    public void Fly()
    {
        this.rigibodyBird.WakeUp();
        this.rigibodyBird.simulated = true;
        this.ani.SetTrigger("Fly");
    }
}
