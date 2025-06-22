using System.Collections.Generic;
using UnityEngine;

namespace MagneticFishing
{
    public class LootGenerator : MonoBehaviour
    {
        [SerializeField] private Transform panelSpawn;
        [SerializeField] private ushort minGenerateLoot = 0;
        [SerializeField] private ushort maxGenerateLoot = 4;

        public GameObject[] AllLoot;
        public RectTransform[] spawnPositions;
        [SerializeField] private bool[] spawnPositionsIsBusy;
        public List<GameObject> droppedOutLoot { get; private set; } = new List<GameObject>();


        private void Start()
        {
            spawnPositionsIsBusy = new bool[spawnPositions.Length];
        }

        public void GenarateLoot()
        {
            ClearArray();

            int coundGenarateLoot = Random.Range(minGenerateLoot, maxGenerateLoot);
            Debug.Log(coundGenarateLoot);

            for (int i = 0; i < coundGenarateLoot; i++)
            {
                var newObject = Instantiate(AllLoot[Random.Range(0, AllLoot.Length)]);
                droppedOutLoot.Add(newObject);
            }

            for (int i = 0; i < droppedOutLoot.Count; i++)
            {
                for (int j = 0; j < spawnPositions.Length; j++)
                {
                    if (spawnPositionsIsBusy[j])
                        continue;

                    spawnPositionsIsBusy[j] = true;
                    droppedOutLoot[i].transform.SetParent(spawnPositions[j].transform, false);
                    droppedOutLoot[i].transform.localPosition = Vector3.zero;
                    break;
                }
            }
        }

        private void ClearArray()
        {
            for (int i = 0; i < spawnPositionsIsBusy.Length; i++)
            {
                spawnPositionsIsBusy[i] = false;
            }

            foreach (var obj in spawnPositions)
            {
                for(int j = 0;j < obj.childCount; j++)
                {
                    Destroy(obj.GetChild(j).gameObject);
                }
            }

            droppedOutLoot.Clear();
        }
    }
}
