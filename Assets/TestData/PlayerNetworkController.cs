using Unity.Netcode;
using UnityEngine;

public class PlayerNetworkController : NetworkBehaviour
{
    private string playerName = "";
    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            // 根據 OwnerClientId 設定命名
            playerName = "player" + OwnerClientId;
            gameObject.name = playerName;

            Debug.Log($"玩家名稱設定為: {playerName}");
        }
    }
    
    private void Update()
    {
        
        if (!IsOwner) return;
        Debug.Log("我是這個物件的擁有者，可以控制！" + playerName);

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(moveX, 0, moveZ) * Time.deltaTime * 5);
    }
}
