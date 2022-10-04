using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // 타일에 공장이 이미 건설되어 있는지 확인하는 변수
    // 자동 구현 프로퍼티
    public bool isSpawnFactory { set; get; }

    private void Awake()
    {
        isSpawnFactory = false;
    }
}
