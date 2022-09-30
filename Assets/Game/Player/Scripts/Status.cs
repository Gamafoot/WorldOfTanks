using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Photon.Pun;

public class Status : MonoBehaviourPun, IPunObservable
{
    [Header("Status settings")]

    [Tooltip("Текущее кол-во здоровья игрока")]
    [SerializeField] private float current_health;

    [Tooltip("Максимальное кол-во здоровья игрока")]
    [SerializeField] private float max_heath;

    private Image healthImage;

    private bool isRespawning;

    private void Start()
    {
        isRespawning = false;
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

    public float GetHealthPlayer(){
        // Просто возвращает кол-во хп

        return current_health;
    }

    private void CheckDeath()
    {
        if (current_health == 0 && !isRespawning)
        {
            GetComponent<PhotonView>().RPC("RPC_Death", RpcTarget.AllBuffered);
        }
    }

    private void UpdateHealthUI(){
        // Обновляет состояние здоровье для UI

        healthImage.fillAmount = current_health / max_heath;
    }

    [PunRPC]
    public void RPC_TakeDamage(float damage){
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
        PlayerComponents.spawner.RespawnPlayer(gameObject);
        current_health = max_heath;
    }

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
