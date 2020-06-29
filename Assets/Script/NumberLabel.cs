using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NumberLabel : MonoBehaviour
{

    void Start()
    {
        print(CovertNumberKorean(100000013023));
        // ex) 1000/0001/3023 -> 1000, 1001, 3023 -> 1000억, 1만 , 3023-> 1000억 1만 3023
    }


    private string CovertNumberKorean(long inputNum)
    {
        string[] koreanUnit = new string[] { "", "만", "억", "조", "경", "해" }; // 단위 배열
        string inputString = inputNum.ToString();

        int expLength = (int)Math.Ceiling((double)inputString.Length / 4.0); // 4칸씩 잘랐을때 잘린 횟수


        string resultString = inputString;
        for (int i = 1; i < expLength; i++)  // 4칸마다 '/'추가
        {
            resultString = resultString.Insert(inputString.Length - 4 * i, "/");
        }

        string[] words = resultString.Split('/'); // '/'로 나누어 각 배열에 저장


        int wordLength = words.Length;


        for (int i = 0; i < wordLength; i++)
        {
            int removeZeroTemp = Convert.ToInt32(words[wordLength - 1 - i]); // to Int를 통해 0001 0002 같이 앞에 0이 붙은 숫자 제거
            words[wordLength - 1 - i] = removeZeroTemp.ToString(); // 다시 string으로 변환

            if (words[wordLength - 1 - i] != "0") // 0이면 단위를 붙이지않음
            {
                words[wordLength - 1 - i] = words[wordLength - 1 - i] + koreanUnit[i]; // 각 배열마다 맞는 단위 붙이기 
            }
        }

        resultString = string.Join(" ", words); // 배열들 다시 합치기

        return resultString;
    }

    private string ConvertNumberAllKorean(long input) // 모든 숫자 한글로하는 함수
    {
        string[] koreanNum = { "", "일", "이", "삼", "사", "오", "육", "칠", "팔", "구" };
        string[] koreanNum2 = { "천", "백", "십", "" };
        string[] koreanNumUnit = new string[] { "", "만", "억", "조", "경", "해" };

        string inputString = input.ToString();
        string resultString = "";

        int expLength = (int)Math.Ceiling((double)inputString.Length / 4.0);


        string zeroString = "";
        string inputCalculetedString = "";
        string RtnString = "";

        if (inputString.Length < (expLength * 4))
        {
            for (int i = 0; i < (expLength * 4) - inputString.Length; i++)
            {
                zeroString += "0";
            }
        }
        inputCalculetedString = zeroString + inputString; // 100000 -> 00100000

        int index = 0;

        for (int i = 0; i < expLength; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                string tempString = inputCalculetedString.Substring(index, 1);

                if (koreanNum[int.Parse(tempString)] != "")
                {
                    RtnString += koreanNum[int.Parse(tempString)] + koreanNum2[j];
                }
                index++;
            }
            RtnString += koreanNumUnit[expLength - (i + 1)];
        }
        return resultString;
    }






}
