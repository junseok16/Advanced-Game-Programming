using UnityEngine;

[CreateAssetMenu]
public class FactoryTemplate : ScriptableObject
{
    public GameObject factoryPrefab;
    public GameObject followingFactoryPrefab;
    public Build[] build;

    [System.Serializable]
    public struct Build
    {
        public int factoryCost;
        public int factorySale;
    }
}
