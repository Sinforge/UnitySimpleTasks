using UnityEngine;
using UnityEngine.UI;

namespace ScrollBar
{
    public class ScrollBarHandler : MonoBehaviour
    {
        public Scrollbar scrollbar;

        void Start()
        {
            // Подписываемся на событие изменения значения полосы прокрутки
            scrollbar.onValueChanged.AddListener(OnScrollbarValueChanged);
        }

        // Метод, который вызывается при изменении значения полосы прокрутки
        public void OnScrollbarValueChanged(float value)
        {
            // Здесь вы можете совершать любое действие при изменении значения
            Debug.Log("Scrollbar value changed: " + value);
        
        }
    }
}