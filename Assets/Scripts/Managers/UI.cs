using UnityEngine.UIElements;
using UnityEngine;
using Mirror;

public class UI : MonoBehaviour
{
    VisualElement root;

    [SerializeField] NetworkManager networkManager;

    [SerializeField] string networkAddress;
    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        Button start = root.Q<Button>("start");
        Button mint = root.Q<Button>("mint");
        start.clicked += () => onStartButtonClicked();
        mint.clicked += () => onClientConnectButtonClicked();
    }
    private void ConnectClient(string address)
    {
        networkManager.networkAddress = networkAddress;
        networkManager.StartClient();
    }

    private void StartServer(string address)
    {
        networkManager.networkAddress = networkAddress;
        networkManager.StartServer();
    }

    public void onStartButtonClicked()
    {
        Debug.Log("onStartButtonClicked()");
        StartServer(networkAddress);
    }

    public void onClientConnectButtonClicked()
    {
        Debug.Log("onClientConnectButtonClicked()");
        ConnectClient(networkAddress);
        //root.Q<VisualElement>("container").visible = false;
    }
}
