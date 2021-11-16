using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class Test : MonoBehaviour
{
    public void Debug(HoverEnterEventArgs a)
    {
        print(a);
    }
}
