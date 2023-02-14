using UnityEngine.UIElements;
using UnityEngine;
using Mirror;
//using Thirdweb;

public class UI : MonoBehaviour
{
    VisualElement root;
    [SerializeField] AudioSource mainMusic;

    //private ThirdwebSDK sdk;

    [SerializeField] NetworkManager networkManager;

    [SerializeField] string networkAddress;

    GameObject gameOverUI;

    VisualElement gameOverRoot;

    private void Awake()
    {

        mainMusic.Play();
    }

    public void onRestartClicked()
    {
        Debug.Log("onRestartClicked");
        gameOverRoot.Q<VisualElement>("gameovercontainer").visible = false;
    }

    public void showGameOver()
    {
        gameOverRoot.Q<VisualElement>("gameovercontainer").visible = true;
    }

    public void hideGameOver()
    {
        gameOverRoot.Q<VisualElement>("gameovercontainer").visible = false;
    }

    private void OnEnable()
    {


        // Game Over

        gameOverUI = GameObject.FindGameObjectWithTag("GameOverUI");
        gameOverRoot = gameOverUI.GetComponent<UIDocument>().rootVisualElement;
        //Button restartButton = gameOverRoot.Q<Button>("restart");
        //restartButton.clicked += () => onRestartClicked();
        hideGameOver();





        // Main Menu 
        root = GetComponent<UIDocument>().rootVisualElement;
        Button connectWallet = root.Q<Button>("connect_wallet");
        Button playGuest = root.Q<Button>("play_guest");
        connectWallet.clicked += () => onConnectWalletClicked();
        playGuest.clicked += () => onPlayGuestClicked();

        //sdk = new ThirdwebSDK("mumbai");
    }
    public void ConnectClient(bool isWallet)
    {
        networkManager.networkAddress = networkAddress;
        networkManager.StartClient();
        mainMusic.Stop();
        //GameObject.FindGameObjectWithTag("blu_c").SetActive(false);
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
    }
}
