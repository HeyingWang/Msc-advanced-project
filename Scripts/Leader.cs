using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader : MonoBehaviour
{
    public static Leader Instance { get; private set; }
    //路径点的父物体
    public Transform wayPointParent;
    //移动速度
    public float moveSpeed;
    //所有路径点
   WayPoint[] wayPoints;
    //目标位置
    Vector3 _targetPos;
    private void Awake()
    {
        //初始化
        Instance = this;
        _targetPos = transform.position;
        wayPoints = new WayPoint[wayPointParent.childCount];
    }
    private void Start()
    {
        //从父物体获取所有路径点
        for(int i =0;i<wayPointParent.childCount;i++)
        {
            wayPoints[i] = wayPointParent.GetChild(i).GetComponent<WayPoint>();
        }
    }
    //玩家进入某个路径点
    public void OnPlayerEnterPoint(WayPoint p)
    {
        //计算出这个路径点的位置
        int index = 0;
        for(int i =0;i<wayPoints.Length;i++)
        {
            if (wayPoints[i] == p)
                index = i + 1;
        }
        //设置目标为下一个位置
        if(index <wayPoints.Length)
        {
            print(index);
            _targetPos = wayPoints[index].transform.position;
        }

    }
    //如果没到目标，则向目标移动
    private void Update()
    {
      
        if(Vector3.SqrMagnitude(transform.position - _targetPos)>0.1f)
        {
            var dir = (_targetPos - transform.position).normalized;
            transform.position += dir * Time.deltaTime * moveSpeed;
        }

    }
}
