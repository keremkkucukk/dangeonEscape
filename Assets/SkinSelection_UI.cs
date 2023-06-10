using UnityEngine;
using TMPro;

public class SkinSelection_UI : MonoBehaviour
{
    [SerializeField] private GameObject buyButton;
    [SerializeField] private GameObject equipButton;
    [SerializeField] private Animator anim;
    [SerializeField] private int skind_Id;

    [SerializeField] private bool[] skinPurchased;
    [SerializeField] private int [] priceForSkin;

    [SerializeField] private TextMeshProUGUI bankText;
    private void Start()
    {
        skinPurchased[0] = true;

        bankText.text = PlayerPrefs.GetInt("TotalFruitsCollected").ToString();
    }

    private void SetupSkinInfo()
    {

        equipButton.SetActive(skinPurchased[skind_Id]);
        buyButton.SetActive(!skinPurchased[skind_Id]);

        if (!skinPurchased[skind_Id])
         buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Price" + priceForSkin[skind_Id];

        anim.SetInteger("skinId", skind_Id);
    }

    public void NextSkin()
    {
        skind_Id++;

        if (skind_Id > 3)
            skind_Id = 0;
        SetupSkinInfo();

    }
    public void PreviousSkin()
    {
        skind_Id--;

        if (skind_Id < 0)
            skind_Id = 3;

        SetupSkinInfo();
    }

    public void Buy()
    {
        skinPurchased[skind_Id] = true;

        SetupSkinInfo();
    }

    public void Select()
    {
        PlayerManager.instance.choosenSkinId = skind_Id;
        Debug.Log("Skin was equiped");
    }
}
