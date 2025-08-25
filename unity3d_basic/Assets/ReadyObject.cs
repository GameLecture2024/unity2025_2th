using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyObject : MonoBehaviour
{
    // Ready ��ũ��Ʈ�� Start! �ؽ�Ʈ�� �ۼ��� �Ǹ�, Square������Ʈ�� ������ ���� ����� �ٸ� ������ �����غ�����.
    // Start�Լ��� �ڷ�ƾ���� �����Ͽ��� �����غ�����.

    // �ٲٰ� ���� ������Ʈ�� ������ ����.
    [SerializeField] SpriteRenderer sr;

    // void Start -> IEnumerator Start �����ؼ� ����ϱ�
    IEnumerator Start()
    {
        yield return new WaitForSeconds(6f);
        sr.color = Color.red;
    }

}
