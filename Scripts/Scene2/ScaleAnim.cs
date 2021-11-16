using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ScaleAnim : MonoBehaviour,IBeatable
{
    public float time;
    //��������
    public AnimationCurve scaleCurve;

    //�Ƿ���������
    bool _isScaling;

    //����������ţ�ʲô������
    public void Beat()
    {
        if (_isScaling)
            return;
        StartCoroutine(ScaleCor());
    }

    private void Update()
    {

    }
    //���Ŷ���
    IEnumerator ScaleCor()
    {
        _isScaling = true;

        float _t = 0;
        float start = transform.localScale.x;
        //��timeʱ����
        while(_t< time)
        {
            //������������
            transform.localScale = start* Vector3.one * scaleCurve.Evaluate(_t / time);
            _t += Time.deltaTime;
            yield return 0;
        }
        //���ջص�������С
        transform.localScale =start* Vector3.one;
        _isScaling = false;

    }
}
public interface IBeatable
{
    public void Beat();
}