using UnityEngine;

namespace CloseDialogWindow
{
    public class DialogManager : MonoBehaviour
    {
        public GameObject dialogPanel;

        void Start()
        {
            // Убедитесь, что диалоговое окно активно в начале (можно скрыть в Start() если нужно)
            dialogPanel.SetActive(true);
        }

        public void CloseDialog()
        {
            dialogPanel.SetActive(false);
        }
    }
}