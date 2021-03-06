﻿using UnityEngine;
using System.Collections;

public class BackgroundRepeat : MonoBehaviour
{
    public const float scrollSpeed = 0.2f;
    //스크롤할 속도를 상수로 지정
    private Material thisMaterial;
    //Quad의 Material 데이터를 받아올 객체를 선언
    void Start()
    {
        //객체가 생성될때 최초 1회만 호출 되는 함수
        thisMaterial = GetComponent<Renderer>().material;
        //현재 객체의 Component들을 참조해 Renderer라는 컴포넌트의 Material정보를 받아옴
    }

    void Update()
    {
        Vector2 newOffset = thisMaterial.mainTextureOffset;
        // 새롭게 지정해줄 OffSet 객체를 선언
        newOffset.Set(0, newOffset.y + (scrollSpeed * Time.deltaTime));
        // Y부분에 현재 x값에 속도에 프레임 보정
        //newOffset.Set(newOffset.x, 0 - (scrollSpeed * Time.deltaTime));
        // 반대 부분 적용
        thisMaterial.mainTextureOffset = newOffset;
        //그리고 최종적으로 Offset값을 지정해
    }
}