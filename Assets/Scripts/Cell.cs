using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace BingoFriends
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Image rightImage;

        public void Reset()
        {
            text.text = string.Empty;
            rightImage.enabled = false;
        }

        public void SetText(string text)
        {
            this.text.text = text;
        }

        public void ToggleRight()
        {
            rightImage.enabled = !rightImage.enabled;
        }
    }
}