using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyObject : MonoBehaviour
{
    // Ready 스크립트가 Start! 텍스트가 작성이 되면, Square오브젝트의 색깔을 기존 색깔과 다른 색으로 변경해보세요.
    // Start함수를 코루틴으로 변경하여서 구현해보세요.

    // 바꾸고 싶은 오브젝트를 변수로 선언.
    [SerializeField] SpriteRenderer sr;

    // void Start -> IEnumerator Start 변경해서 사용하기
    IEnumerator Start()
    {
        yield return new WaitForSeconds(6f);
        sr.color = Color.red;
    }

}
