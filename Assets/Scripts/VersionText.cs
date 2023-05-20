using UnityEngine;
using TMPro;

namespace BingoFriends.Tools
{
    public class VersionText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        private void Start()
        {
            text.text = "Version: " + Application.version;
        }
    }
}
