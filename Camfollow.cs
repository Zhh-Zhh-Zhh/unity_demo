using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camfollow : MonoBehaviour
{
    public GameObject Player1;
    public GameObject MainCam;
    public float smooth;
    // Start is called before the first frame update
    float Cam_x;
    float Cam_y;
    Vector3 CamPos;
    Vector3 PlayerPos;
    Vector3 Follow;
    void Start()
    {
        //Cam_x = MainCam.transform.position.x; 
        CamPos = MainCam.transform.position;
        PlayerPos = Player1.transform.position;
        Follow = CamPos - PlayerPos;
    }
    // Update is called once per frame
    void Update()
    {
        MainCam.transform.position = Vector3.Lerp(MainCam.transform.position, Follow + Player1.transform.position, smooth * Time.deltaTime);
        //Cam_x = Mathf.Lerp(Cam_x, Player1.transform.position.x, Time.deltaTime * smooth);
        //Cam_y = Mathf.Lerp(Cam_y, Player1.transform.position.y, Time.deltaTime * smooth);
        //MainCam.transform.position = new Vector3(Cam_x, Cam_y, -10);

        //new Vector3(Player1.transform.position.x, Player1.transform.position.y, -10);
    }
}
