using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * file: FactorySpawner.cs
 * description: ���� ������ �Ǽ��մϴ�.
 * function: spawnFactory() �Ű� ������ ��ġ�� ������ �Ǽ��Ѵ�.
 */

public class FactorySpawner : MonoBehaviour
{
    [SerializeField] private FactoryTemplate[] factoryTemplate;
    [SerializeField] private PlayerGold playerGold;                 // ������ �Ǽ��� �� ������ �����Ѵ�.
    [SerializeField] private SystemTextViewer systemTextViewer;     // ������ ������ �� �޽����� ����Ѵ�.

    private bool isOnFactoryButton = false;                         // ���� �Ǽ� ��ư�� �������� Ȯ���ϴ� ����.
    private int factoryType;                                        // ���� �������� �����ϴ� ����.
    private GameObject followFactoryClone = null;                   // �ӽ� ���� ��� �� �����ϴ� ����.

    public void readyToSpawnFactory(int type)
    {
        factoryType = type;
        if (isOnFactoryButton == true)
        {
            return;
        }
        
        isOnFactoryButton = true;
        followFactoryClone = Instantiate(factoryTemplate[factoryType].followingFactoryPrefab);
        
        // ���� �Ǽ��� ����� �� �ִ� �ڷ�ƾ �Լ��̴�.
        StartCoroutine("FollowingFactoryCancelSystem");
    }

    public void spawnFactory(Transform tileTransform)
    {
        /* ������ �Ǽ��� �� �ִ��� Ȯ���Ѵ�. */
        // 1. ���� ��ư�� ������ ������ �Ǽ��� �� ����.
        if (isOnFactoryButton == false)
        {
            return;
        }

        // 2. ������ �����ϸ� �Ǽ��� �� ����.
        if (factoryTemplate[factoryType].build[0].factoryCost > playerGold.CurrentGold)
        {
            // ������ �����ϴٴ� �޽����� ����Ѵ�.
            systemTextViewer.printText(SystemType.Money);
            return;
        }

        Tile tile = tileTransform.GetComponent<Tile>();

        // 3. ������ Ÿ���� ��ġ�� �̹� ������ �Ǽ��������� �Ǽ��� �� ����.
        if (tile.isSpawnFactory == true)
        {
            systemTextViewer.printText(SystemType.Build);
            return;
        }

        // ������ Ÿ�� ��ġ�� ������ �Ǽ��Ǿ� �ִٰ� �����Ѵ�.
        tile.isSpawnFactory = true;

        // �ٽ� ���� ��ư�� ������ ������ �Ǽ��� �� �ֵ��� �����Ѵ�.
        // isOnFactoryButton = false;

        playerGold.CurrentGold -= factoryTemplate[factoryType].build[0].factoryCost;

        // ������ Ÿ���� ��ġ�� ������ �Ǽ��Ѵ�.
        Vector3 position = tileTransform.position + Vector3.back;
        Instantiate(factoryTemplate[factoryType].factoryPrefab, position, Quaternion.identity);

        // ���� �Ǽ� �� ���콺�� ����ٴϴ� �ӽ� ������ �����Ѵ�.
        // Destroy(followFactoryClone);
    }

    /*
    public void destroyFactory()
    {
        //Tile tile = tileTransform.GetComponent<Tile>();
        while (true)
        {
            if (Input.GetMouseButton(0))
            {
                //tile.isSpawnFactory = false;
                playerGold.CurrentGold += factoryTemplate[factoryType].build[0].factorySale;
                Destroy(gameObject);
                break;
            }
        }
    }
    */

    private IEnumerator FollowingFactoryCancelSystem()
    {
        while (true)
        {
            // esc �Ǵ� ���콺 ��Ŭ���� ���� �� ���� �Ǽ��� ����Ѵ�.
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButton(1))
            {
                isOnFactoryButton = false;
                // ���콺�� ����ٴϴ� �ӽ� ������ �����Ѵ�.
                Destroy(followFactoryClone);
                break;
            }
            yield return null;
        }
    }
}
