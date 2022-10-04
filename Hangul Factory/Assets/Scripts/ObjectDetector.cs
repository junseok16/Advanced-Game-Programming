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
        // MainCamera �±׸� ���� �ִ� ������Ʈ�� Ž���ϰ� Camera ������Ʈ�� �����Ѵ�.
        // ray.origin�� ������ ������, ray.direction�� ������ ��������� ��Ÿ����.
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // ���콺 ���� ��ư�� ������ ��
        if (Input.GetMouseButtonDown(0))
        {
            // 2D ����͸� ���� 3D�� ������Ʈ�� ���콺�� �����Ѵ�.
            // ������ �ε��� ������Ʈ�� hit�� �����Ѵ�.
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            // ������ �ε��� ������Ʈ�� �±װ� "Tile"�� ��
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // ������ �Ǽ��ϴ� spawnFactory �Լ��� ȣ���Ѵ�.
                if (hit.transform.CompareTag("Tile"))
                    factorySpawner.spawnFactory(hit.transform);
            }
        }
    }
}
