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
                KnifeElement newKnife = Instantiate(knifeElementPrefab, knifeElementContent); // Tworzy instancj� prefaba i przypisuje j� pod podanego rodzica
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
    }
}
