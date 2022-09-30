using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Photon.Pun;
using System;

public class Status : MonoBehaviourPun, IPunObservable
{
    [Header("Status settings")]

    [Tooltip("Текущее кол-во здоровья игрока")]
    [SerializeField] private float current_health;

    [Tooltip("Максимальное кол-во здоровья игрока")]
    [SerializeField] private float max_heath;

    [SerializeField] private float respawnTime;

    private Image healthImage;

    // Ивенты
    public static Action onPlayerRespawn;
    public static Action onPlayerDead;

    private void Start()
    {
        if (!photonView.IsMine)
            return;

        current_health = max_heath;
        healthImage = PlayerComponents.healthImage;
    }

    private void Update(){
        if (!photonView.IsMine)
            return;

        UpdateHealthUI();
        CheckDeath();
    }

    #region Health

    public float GetHealthPlayer(){
        // Просто возвращает кол-во хп

        return current_health;
    }

    private void CheckDeath()
    {
        if (current_health == 0)
        {
            GetComponent<PhotonView>().RPC("RPC_Death", RpcTarget.AllBuffered);
        }
    }

    private void UpdateHealthUI(){
        // Обновляет состояние здоровье для UI

        healthImage.fillAmount = current_health / max_heath;
    }

    #endregion

    #region Damage

    public void TakeDamage(float damage){
        // Метод для принятия домага

        if (photonView.IsMine)
        {
            current_health -= damage;
            current_health = Mathf.Clamp(current_health, 0, max_heath);
        }
    }

    [PunRPC]
    private void RPC_Death(){
        gameObject.SetActive(false);
    }

    #endregion

    #region Respawn

    private void OnEnable()
    {
        if (GetComponent<PhotonView>().IsMine)
        {
            onPlayerRespawn?.Invoke();
        }
    }

    private void OnDisable()
    {
        Invoke("RespawnPlayer", respawnTime);

        if (GetComponent<PhotonView>().IsMine)
        {
            onPlayerDead?.Invoke();
        }
    }

    private void RespawnPlayer()
    {
        Vector3 spawnPosition = PlayerComponents.spawner.GetFreeSpawn();

        current_health = max_heath;
        gameObject.transform.position = new Vector3(spawnPosition.x, gameObject.transform.position.y, spawnPosition.z);
        gameObject.SetActive(true);
    }

    private IEnumerator IERepawnPlayer()
    {
        yield return new WaitForSeconds(respawnTime);

        Vector3 spawnPosition = PlayerComponents.spawner.GetFreeSpawn();

        gameObject.transform.position = new Vector3(spawnPosition.x, gameObject.transform.position.y, spawnPosition.z);
        gameObject.SetActive(true);
    }

    #endregion

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(current_health);
        }
        else
        {
            current_health = (float)stream.ReceiveNext();
        }
    }
}
