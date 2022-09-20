using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    [Header("Status settings")]
    [Tooltip("Текущее кол-во здоровья игрока")]
    [SerializeField] private int current_health;

    [Range(0, 100)]
    [Tooltip("Максимальное кол-во здоровья игрока")]
    [SerializeField] private int max_heath;

    [Tooltip("Текст для отображения хп")]
    [SerializeField] private Text health_text;

    void Start()
    {
        current_health = max_heath;
    }

    private void Update(){
        // Проверка на кол-во хп, а потом смэрть
    }

    public int GetPlayerHealth(){
        return current_health;
    }

    public void TakeDamage(int damage){
        current_health -= damage;
        current_health = Mathf.Clamp(current_health, 0, max_heath);
        // UpdateHealth();
    }

    private void UpdateHealth(){
        health_text.text = current_health.ToString();
    }

    private void Death(){
        // Тут как-то что-то надо написать
    }
}
