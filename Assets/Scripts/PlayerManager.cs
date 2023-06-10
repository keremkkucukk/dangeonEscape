using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public int fruits;
    public Transform respawnPoint;
    public GameObject currentPlayer;
    public int choosenSkinId;

    [SerializeField] private GameObject playerPrefab;
    //internal object fruits;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        // instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            PlayerRespawn();
    }

    public void PlayerRespawn()
    {
        if (currentPlayer == null)
            currentPlayer = Instantiate(playerPrefab, respawnPoint.position, transform.rotation);
    }





}
