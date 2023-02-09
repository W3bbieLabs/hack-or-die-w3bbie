using UnityEngine;
using UnityEngine.UIElements;
using Mirror;
using Thirdweb;
using System;

public class UI2Network : NetworkBehaviour
{
    VisualElement root;

    GameObject UIObject;

    public bool isWallet = false;

    public void setWallet(bool state)
    {
        isWallet = state;
    }

    [SerializeField] String tokenAddress;

    public override void OnStartClient()
    {
        //Debug.Log("OnStartClient");
        base.OnStartClient();
        //root = GetComponent<UIDocument>().rootVisualElement;
        // Hide UI
        UIObject = GameObject.FindGameObjectWithTag("UIDoc");
        root = UIObject.GetComponent<UIDocument>().rootVisualElement;
        root.Q<VisualElement>("container").visible = false;

        // Show BLK by default
        //GameObject.FindGameObjectWithTag("blu_c").SetActive(false);
        //GameObject.FindGameObjectWithTag("blk_c").SetActive(true);
        checkTokenBalance();
    }

    public async void checkTokenBalance()
    {
        var isConnected = await ThirdwebManager.Instance.SDK.wallet.IsConnected();

        if (isConnected)
        {
            Contract contract = ThirdwebManager.Instance.SDK.GetContract(tokenAddress);
            var balance = await contract.ERC721.Balance();
            //Debug.Log("Balance: " + balance);
            //int balance_int = 0;
            //Int32.TryParse(balance, out balance_int);
            if (balance == "0")
            {

                // Show BLK Character
                GameObject.FindGameObjectWithTag("blu_c").SetActive(false);
                GameObject.FindGameObjectWithTag("blk_c").SetActive(true);
                Debug.Log("Hide BLU");

            }
            else
            {
                // Show BLU Character
                GameObject.FindGameObjectWithTag("blk_c").SetActive(false);
                GameObject.FindGameObjectWithTag("blu_c").SetActive(true);
                Debug.Log("Hide BLK");
            }

        }
        else
        {
            //Show BLK by default
            GameObject.FindGameObjectWithTag("blu_c").SetActive(false);
            GameObject.FindGameObjectWithTag("blk_c").SetActive(true);
        }

    }
}
