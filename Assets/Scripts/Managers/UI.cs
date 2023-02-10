using UnityEngine.UIElements;
using UnityEngine;
using Mirror;
//using Thirdweb;

public class UI : MonoBehaviour
{
    VisualElement root;

    //private ThirdwebSDK sdk;

    [SerializeField] NetworkManager networkManager;

    [SerializeField] string networkAddress;
    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        Button connectWallet = root.Q<Button>("connect_wallet");
        Button playGuest = root.Q<Button>("play_guest");
        connectWallet.clicked += () => onConnectWalletClicked();
        playGuest.clicked += () => onPlayGuestClicked();
        
       
        //sdk = new ThirdwebSDK("mumbai");
    }
    public AudioSource mainMenu;

    void Start()
    {
        SoundManager.instance.PlayMainMenu();
    }

    public void ConnectClient(bool isWallet)
    {
        networkManager.networkAddress = networkAddress;
        networkManager.StartClient();
        //GameObject.FindGameObjectWithTag("blu_c").SetActive(false);
        mainMenu.Stop();
    }

    private void StartServer(string address)
    {
        networkManager.networkAddress = networkAddress;
        networkManager.StartServer();
    }

    public void MetamaskLogin()
    {
        //ConnectWallet(WalletProvider.MetaMask);
    }

    /*
    private async void ConnectWallet(WalletProvider provider)
    {
        string address = await sdk.wallet.Connect();
        Debug.Log("Address " + address);
    }
    */

    public void onConnectWalletClicked()
    {
        Debug.Log("onConnectWalletClicked()");
        MetamaskLogin();
        //string address = await sdk.wallet.Connect();
        //StartServer(networkAddress);
    }

    public void onPlayGuestClicked()
    {
        Debug.Log("onClientConnectButtonClicked()");
        ConnectClient(false);
        //root.Q<VisualElement>("container").visible = false;
        SoundManager.instance.PlayStartNewGame();
    }
}
