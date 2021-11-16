using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader : MonoBehaviour
{
    public static Leader Instance { get; private set; }
    //·����ĸ�����
    public Transform wayPointParent;
    //�ƶ��ٶ�
    public float moveSpeed;
    //����·����
   WayPoint[] wayPoints;
    //Ŀ��λ��
    Vector3 _targetPos;
    private void Awake()
    {
        //��ʼ��
        Instance = this;
        _targetPos = transform.position;
        wayPoints = new WayPoint[wayPointParent.childCount];
    }
    private void Start()
    {
        //�Ӹ������ȡ����·����
        for(int i =0;i<wayPointParent.childCount;i++)
        {
            wayPoints[i] = wayPointParent.GetChild(i).GetComponent<WayPoint>();
        }
    }
    //��ҽ���ĳ��·����
    public void OnPlayerEnterPoint(WayPoint p)
    {
        //��������·�����λ��
        int index = 0;
        for(int i =0;i<wayPoints.Length;i++)
        {
            if (wayPoints[i] == p)
                index = i + 1;
        }
        //����Ŀ��Ϊ��һ��λ��
        if(index <wayPoints.Length)
        {
            print(index);
            _targetPos = wayPoints[index].transform.position;
        }

    }
    //���û��Ŀ�꣬����Ŀ���ƶ�
    private void Update()
    {
      
        if(Vector3.SqrMagnitude(transform.position - _targetPos)>0.1f)
        {
            var dir = (_targetPos - transform.position).normalized;
            transform.position += dir * Time.deltaTime * moveSpeed;
        }

    }
}
