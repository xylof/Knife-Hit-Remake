using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Generation
{
    public class LevelGenerator : MonoBehaviour
    {
        [Header("Shield")]
        [SerializeField]
        private Transform shieldPos;

        [SerializeField]
        private BaseShield[] simpleShields;

        [SerializeField]
        private BaseShield[] bossShields;

        [SerializeField]
        private Transform shieldRoot;

        [Header("Knife")]
        [SerializeField]
        private Transform knifePos;

        [SerializeField]
        private Knife knifePrefab;

        [SerializeField]
        private Transform knifeRoot;

        public BaseShield SpawnShield(StageType stageType)
        {
            BaseShield shieldToSpawn = default; // przypisuje zmiennej domyœln¹ wartoœæ, któr¹ kompilator ustali na bazie typu (0 dla inta, null dla zmiennej referencyjnej, itd.)

            if (stageType == StageType.Normal)
            {
                var randomIndex = Random.Range(0, simpleShields.Length);
                shieldToSpawn = simpleShields[randomIndex];
            }
            else
            {
                var randomIndex = Random.Range(0, bossShields.Length);
                shieldToSpawn = bossShields[randomIndex];
            }

            var shieldObj = Instantiate(shieldToSpawn, shieldPos.position, shieldPos.rotation);

            shieldObj.transform.SetParent(shieldRoot);

            return shieldObj;
        }

        public Knife SpawnKnife()
        {
            var knifeObj = Instantiate(knifePrefab, knifePos.position, knifePos.rotation);

            knifeObj.transform.SetParent(knifeRoot);

            return knifeObj;
        }
    } 
}
