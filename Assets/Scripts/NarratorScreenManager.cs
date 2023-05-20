using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BingoFriends
{
    public class NarratorScreenManager : MonoBehaviour
    {
        [SerializeField] private Cell cellPrefab;
        [SerializeField] private Cell currentCell;
        [SerializeField] private Transform cellsParent;
        [SerializeField] private TextMeshProUGUI generatedNumbersText;

        private List<int> generatedNumbers = new List<int>();
        private List<GameObject> instatiatedPrefabs = new List<GameObject>();
        private string firstPart;

        private void Start()
        {
            firstPart = generatedNumbersText.text;

            generatedNumbersText.text = firstPart + " " + 0.ToString();
        }

        public void Restart()
        {
            foreach (GameObject instatiatedPrefab in instatiatedPrefabs)
            {
                Destroy(instatiatedPrefab);
            }

            currentCell.SetText(string.Empty);
            generatedNumbers.Clear();
            instatiatedPrefabs.Clear();
            generatedNumbersText.text = firstPart + " " + generatedNumbers.Count.ToString();
        }

        public void GenerateNewNumber()
        {
            if (generatedNumbers.Count >= 75)
            {
                return;
            }

            var randomNumber = Random.Range(1, 76);

            while (generatedNumbers.Contains(randomNumber))
            {
                randomNumber = Random.Range(1, 76);
            }

            generatedNumbers.Add(randomNumber);
            currentCell.SetText(randomNumber.ToString());

            generatedNumbersText.text = firstPart + " " + generatedNumbers.Count.ToString();

            var cell = Instantiate(cellPrefab, cellsParent);

            cell.transform.SetAsFirstSibling();
            cell.SetText(randomNumber.ToString());
            instatiatedPrefabs.Add(cell.gameObject);
        }
    }
}