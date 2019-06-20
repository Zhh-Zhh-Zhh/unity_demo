using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public GameObject Player;
    public float movespeed = 8;
    public Animator Player_ani;
    public Player_condition player_Condition;
    Vector3 mouse;
    Vector3 direction1, direction2, direction3;
    public Transform left_hand;
    public Transform left_forearm;
    public Transform left_swordpoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Player_Walk();
        SwordOut();
        NomalAttack();
    }

    public void Player_Walk() {
        Vector3 pos = this.transform.position;
        if (Input.GetKey(KeyCode.D))
        {
            if(Player.transform.rotation.y < 0)
            {
                Player.transform.Rotate(new Vector3(0, 180, 0));
            }
            Player_ani.SetBool("IsWalk", true);
            Player_ani.SetBool("IsSwordWalk", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (Player.transform.rotation.y >= 0)
            {
                Player.transform.Rotate(new Vector3(0, -180, 0));
            }
            Player_ani.SetBool("IsWalk", true);
            Player_ani.SetBool("IsSwordWalk", true);
        }
        else if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            Player_ani.SetBool("IsWalk", true);
            Player_ani.SetBool("IsSwordWalk", true);
        }
        else{
            Player_ani.SetBool("IsWalk", false);
            Player_ani.SetBool("IsSwordWalk", false);
        }
        pos.x += Input.GetAxis("Horizontal") * Time.deltaTime * movespeed;
        pos.z += Input.GetAxis("Vertical") * Time.deltaTime * movespeed;
        this.transform.position = pos;

    }

    public void SwordOut()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Player_ani.GetBool("IsSwordOut") == true)
            {
                Player_ani.SetBool("IsSwordOut", false);
            }
            else if (Player_ani.GetBool("IsSwordOut") == false)
            {
                Player_ani.SetBool("IsSwordOut", true);
            }
        }
        
    }

    public void NomalAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Player_ani.SetTrigger("IsNormalAttack");
            
        }
    }
}
