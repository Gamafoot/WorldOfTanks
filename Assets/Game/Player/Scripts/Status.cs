using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
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
        healthImage = FindObjectOfType<PlayerSetup>().healthImage;
    }

    private void Update(){
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

    public void TakeDamage(float damage){
        // Метод для принятия домага

        current_health -= damage;
        current_health = Mathf.Clamp(current_health, 0, max_heath);
    }

    private void Death(){
        // Тут как-то что-то надо написать
    }
}
