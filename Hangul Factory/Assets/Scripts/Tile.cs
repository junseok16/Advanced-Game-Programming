using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Ÿ�Ͽ� ������ �̹� �Ǽ��Ǿ� �ִ��� Ȯ���ϴ� ����
    // �ڵ� ���� ������Ƽ
    public bool isSpawnFactory { set; get; }

    private void Awake()
    {
        isSpawnFactory = false;
    }
}
