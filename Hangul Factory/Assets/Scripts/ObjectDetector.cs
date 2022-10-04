using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField] private FactorySpawner factorySpawner;

    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;

    private void Awake()
    {
        // MainCamera 태그를 갖고 있는 오브젝트를 탐색하고 Camera 컴포넌트로 전달한다.
        // ray.origin은 광선의 시작점, ray.direction은 광선의 진행방향을 나타낸다.
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // 마우스 왼쪽 버튼을 눌렀을 때
        if (Input.GetMouseButtonDown(0))
        {
            // 2D 모니터를 통해 3D의 오브젝트를 마우스로 선택한다.
            // 광선에 부딪힌 오브젝트를 hit에 저장한다.
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            // 광선에 부딪힌 오브젝트의 태그가 "Tile"일 때
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // 공장을 건설하는 spawnFactory 함수를 호출한다.
                if (hit.transform.CompareTag("Tile"))
                    factorySpawner.spawnFactory(hit.transform);
            }
        }
    }
}
