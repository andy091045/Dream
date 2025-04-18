using Unity.Netcode;
using UnityEngine;

public class NetworkUI : MonoBehaviour
{
    private void OnGUI()
    {
        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            // 顯示主機和客戶端連線選項
            if (GUI.Button(new Rect(10, 10, 100, 30), "Host"))
            {
                NetworkManager.Singleton.StartHost();
            }

            if (GUI.Button(new Rect(10, 50, 100, 30), "Client"))
            {
                NetworkManager.Singleton.StartClient();
            }
        }
        else if (NetworkManager.Singleton.IsHost)
        {
            // 顯示主機正在運行
            GUI.Label(new Rect(10, 10, 200, 30), "Hosting...");
        }
        else if (NetworkManager.Singleton.IsClient)
        {
            // 顯示客戶端正在連線
            GUI.Label(new Rect(10, 10, 200, 30), "Connected as Client...");
        }
    }
}
