using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Status : MonoBehaviourPun, IPunObservable
{
    [Header("Status settings")]

    [Tooltip("Текущее кол-во здоровья игрока")]
    [SerializeField] private float current_health;

    [Tooltip("Максимальное кол-во здоровья игрока")]
    [SerializeField] private float max_heath;

    private Image healthImage;

    private void Start()
    {
        current_health = max_heath;

        if (photonView.IsMine)
        {
            healthImage = FindObjectOfType<PlayerSetup>().healthImage;
        }
    }

    private void Update(){
        if (!photonView.IsMine)
            return;

        UpdateHealth();
    }

    public float GetHealthPlayer(){
        // Просто возвращает кол-во хп
        return current_health;
    }

    private void UpdateHealth(){
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

    private void Death(){
        // Тут как-то что-то надо написать
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
