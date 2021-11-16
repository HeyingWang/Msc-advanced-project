using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ScaleAnim : MonoBehaviour,IBeatable
{
    public float time;
    //缩放曲线
    public AnimationCurve scaleCurve;

    //是否正在缩放
    bool _isScaling;

    //如果正在缩放，什么都不做
    public void Beat()
    {
        if (_isScaling)
            return;
        StartCoroutine(ScaleCor());
    }

    private void Update()
    {

    }
    //缩放动画
    IEnumerator ScaleCor()
    {
        _isScaling = true;

        float _t = 0;
        float start = transform.localScale.x;
        //在time时间内
        while(_t< time)
        {
            //物体缩放设置
            transform.localScale = start* Vector3.one * scaleCurve.Evaluate(_t / time);
            _t += Time.deltaTime;
            yield return 0;
        }
        //最终回到正常大小
        transform.localScale =start* Vector3.one;
        _isScaling = false;

    }
}
public interface IBeatable
{
    public void Beat();
}