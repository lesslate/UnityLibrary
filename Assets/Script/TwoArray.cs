using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoArray : MonoBehaviour
{

    // 인스펙터 창에 표시되는 2차원 배열 선언법
    [System.Serializable]
    public class TextArray
    {
        public Text[] textHorizon;
    }

    public TextArray[] textVertical;

    void Start()
    {
        int count = 1;
        for (int i = 0; i < 3; i++)  // 3*3 배열에 1~9 입력
        {
            for (int j = 0; j < 3; j++)
            {
                textVertical[i].textHorizon[j].text = count.ToString();

                count++;
            }
        }
    }
}
