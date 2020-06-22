using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TimeComplexity : MonoBehaviour
{

    // 실행 시간 측정방법
    void Start()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();


        sw.Stop();

        print(sw.ElapsedMilliseconds.ToString() + "ms");
    }


}
