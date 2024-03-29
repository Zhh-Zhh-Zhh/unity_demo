﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Vector3 MousePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    Vector2 mouse;
    Vector2 obj;
    Vector2 direction;
    // Update is called once per frame
    void Update()
    {
        //MousePosition.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        //MousePosition.y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        //this.transform.position = new Vector3(MousePosition.x, MousePosition.y, this.transform.position.z);
        
            //获取鼠标的坐标，鼠标是屏幕坐标，Z轴为0，这里不做转换
            mouse = Input.mousePosition;
            //获取物体坐标，物体坐标是世界坐标，将其转换成屏幕坐标，和鼠标一直
            obj = Camera.main.WorldToScreenPoint(transform.position);
            //屏幕坐标向量相减，得到指向鼠标点的目标向量，即黄色线段
            direction = mouse - obj;
            //将Z轴置0,保持在2D平面内
            //direction.z = 0f;
            //将目标向量长度变成1，即单位向量，这里的目的是只使用向量的方向，不需要长度，所以变成1
            direction = direction.normalized;
        //当目标向量的Y轴大于等于0.4F时候，这里是用于限制角度，可以自己条件
            //if (direction.x >=0.2f)
            //{
            //物体自身的Y轴和目标向量保持一直，这个过程XY轴都会变化数值
            this.transform.up = direction*-1;
            //}
        
    }
}
