using UnityEngine;
using TMPro;

public class TextGoldViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textPlayerGold;// �÷��̾� ��� �ؽ�Ʈ.
    [SerializeField] private PlayerGold playerGold;// �÷��̾� ��� ����.

    private void Update()
    {
        textPlayerGold.text = playerGold.CurrentGold.ToString();
    }
}
