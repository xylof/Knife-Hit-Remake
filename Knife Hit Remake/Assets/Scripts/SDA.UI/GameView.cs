using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SDA.UI
{
    public class GameView : BaseView
    {
        [SerializeField]
        private TextMeshProUGUI scoreInfo;

        [SerializeField]
        private KnifeElement knifeElementPrefab;

        [SerializeField]
        private RectTransform knifeElementContent;

        [SerializeField]
        private DotElement[] elements;

        [SerializeField]
        private TextMeshProUGUI stageText;

        private List<KnifeElement> spawnedElements = new List<KnifeElement>();

        private int knifeToDelete;

        public void UpdateScore(int points)
        {
            scoreInfo.text = points.ToString();
        }

        public void SpawnAmmo(int amount)
        {
            DespawnAmmo();

            for (int i = 0; i < amount; i++)
            {
                KnifeElement newKnife = Instantiate(knifeElementPrefab, knifeElementContent); // Tworzy instancjê prefaba i przypisuje j¹ pod podanego rodzica
                spawnedElements.Add(newKnife);
                newKnife.MarkAsUnlocked();
            }

            knifeToDelete = -1;
        }

        private void DespawnAmmo()
        {
            for (int i = spawnedElements.Count - 1; i >= 0; i--)
            {
                Destroy(spawnedElements[i].gameObject);
            }
            spawnedElements.Clear();
        }

        public void DecreaseAmmo()
        {
            knifeToDelete++;
            spawnedElements[knifeToDelete].MarkAsLocked();
        }

        public void UpdateStage(int currentStage)
        {
            if (currentStage == 0)
            {
                stageText.text = $"BOSS FIGHT";
                stageText.color = Color.red;

                for (int i = 0; i < elements.Length; i++)
                {
                    elements[i].gameObject.SetActive(false);
                }

                elements[elements.Length - 1].gameObject.SetActive(true);
            }
            else
            {
                if (currentStage == 1)
                {
                    for (int i = 0; i < elements.Length; i++)
                    {
                        elements[i].gameObject.SetActive(true);
                        elements[i].MarkAsLocked();
                    }

                    elements[elements.Length - 1].gameObject.SetActive(false);
                }

                elements[currentStage - 1].MarkAsUnlocked();
                stageText.text = $"STAGE {currentStage}";
                stageText.color = Color.white;
            }
        }
    }
}
