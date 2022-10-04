using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * file: FactorySpawner.cs
 * description: 생성 공장을 건설합니다.
 * function: spawnFactory() 매개 변수의 위치에 공장을 건설한다.
 */

public class FactorySpawner : MonoBehaviour
{
    [SerializeField] private FactoryTemplate[] factoryTemplate;
    [SerializeField] private PlayerGold playerGold;                 // 공장을 건설할 때 코인을 감소한다.
    [SerializeField] private SystemTextViewer systemTextViewer;     // 코인이 부족할 때 메시지를 출력한다.

    private bool isOnFactoryButton = false;                         // 공장 건설 버튼을 눌렀는지 확인하는 변수.
    private int factoryType;                                        // 무슨 공장인지 저장하는 변수.
    private GameObject followFactoryClone = null;                   // 임시 공장 사용 후 삭제하는 변수.

    public void readyToSpawnFactory(int type)
    {
        factoryType = type;
        if (isOnFactoryButton == true)
        {
            return;
        }
        
        isOnFactoryButton = true;
        followFactoryClone = Instantiate(factoryTemplate[factoryType].followingFactoryPrefab);
        
        // 공장 건설을 취소할 수 있는 코루틴 함수이다.
        StartCoroutine("FollowingFactoryCancelSystem");
    }

    public void spawnFactory(Transform tileTransform)
    {
        /* 공장을 건설할 수 있는지 확인한다. */
        // 1. 공장 버튼을 누르지 않으면 건설할 수 없다.
        if (isOnFactoryButton == false)
        {
            return;
        }

        // 2. 코인이 부족하면 건설할 수 없다.
        if (factoryTemplate[factoryType].build[0].factoryCost > playerGold.CurrentGold)
        {
            // 코인이 부족하다는 메시지를 출력한다.
            systemTextViewer.printText(SystemType.Money);
            return;
        }

        Tile tile = tileTransform.GetComponent<Tile>();

        // 3. 선택한 타일의 위치에 이미 공장이 건설돼있으면 건설할 수 없다.
        if (tile.isSpawnFactory == true)
        {
            systemTextViewer.printText(SystemType.Build);
            return;
        }

        // 선택한 타일 위치에 공장이 건설되어 있다고 설정한다.
        tile.isSpawnFactory = true;

        // 다시 공장 버튼을 눌러서 공장을 건설할 수 있도록 설정한다.
        // isOnFactoryButton = false;

        playerGold.CurrentGold -= factoryTemplate[factoryType].build[0].factoryCost;

        // 선택한 타일의 위치에 공장을 건설한다.
        Vector3 position = tileTransform.position + Vector3.back;
        Instantiate(factoryTemplate[factoryType].factoryPrefab, position, Quaternion.identity);

        // 공장 건설 후 마우스를 따라다니는 임시 공장을 삭제한다.
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
            // esc 또는 마우스 우클릭을 했을 때 공장 건설을 취소한다.
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButton(1))
            {
                isOnFactoryButton = false;
                // 마우스를 따라다니는 임시 공장을 삭제한다.
                Destroy(followFactoryClone);
                break;
            }
            yield return null;
        }
    }
}
