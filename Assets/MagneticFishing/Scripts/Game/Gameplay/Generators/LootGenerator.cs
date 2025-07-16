using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace MagneticFishing
{
    public class LootGenerator : MonoBehaviour
    {
        [SerializeField] private Transform panelSpawn;
        [SerializeField] private ushort minGenerateLoot = 0;
        [SerializeField] private ushort maxGenerateLoot = 4;
        [SerializeField] private bool[] spawnPositionsIsBusy;

        public GameObject[] allLoot;   
        public RectTransform[] spawnPositions;
        public List<GameObject> droppedOutLoot { get; private set; } = new List<GameObject>();

        private Dictionary<GameObject, Subject> descriptionList;
        private Dictionary<int, ILootGenerationStrategy> generationStrategies;

        private void Start()
        {
            InitializedStrategies();
            descriptionList = new Dictionary<GameObject, Subject>(0);
            for (int i = 0; i < allLoot.Length; i++)
            {
                descriptionList.Add(allLoot[i], allLoot[i].gameObject.GetComponent<Subject>());
            }

            spawnPositionsIsBusy = new bool[spawnPositions.Length];
        }

        private void InitializedStrategies()
        {
            generationStrategies = new Dictionary<int, ILootGenerationStrategy>
            {
                [0] = null,
                [1] = new AllLootStrategy(),
                [2] = new ExcludeBigStrategy(),
                [3] = new ExcludeBigAndAverageStrategy(),
                [4] = new OnlySmallAndMoreThanSmallStrategy(),
            };
        }

        public void GenarateLoot()
        {
            ClearArray();
            int countGenarateLoot = CountSpawnLoot();

            Dictionary<GameObject, Subject> prop = new Dictionary<GameObject, Subject>();

            if (generationStrategies.TryGetValue(countGenarateLoot, out var strategy) && strategy != null)
            {
                prop = strategy.FilterLoot(descriptionList);
            }           

            var asList = prop.ToList();

            for (int i = 0; i < countGenarateLoot; i++)
            {
                var newObject = Instantiate(asList[Random.Range(0, asList.Count)].Key);
                droppedOutLoot.Add(newObject);
                GeneratorIdProp.GenererateIdSubject(newObject);
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

        private int CountSpawnLoot() => Random.Range(minGenerateLoot, maxGenerateLoot);

        private void ClearArray()
        {
            for (int i = 0; i < spawnPositionsIsBusy.Length; i++)
            {
                spawnPositionsIsBusy[i] = false;
            }

            foreach (var obj in spawnPositions)
            {
                for (int j = 0; j < obj.childCount; j++)
                {
                    Destroy(obj.GetChild(j).gameObject);
                }
            }

            droppedOutLoot.Clear();
        }

        public bool DeleteItemFromArray()
        {
            if (droppedOutLoot.Count > 0)
            {
                droppedOutLoot.RemoveAt(droppedOutLoot.Count - 1);

                if (droppedOutLoot.Count == 0)
                    return false;
                else
                    return true;
            }
            else
            {
                return false;
            }

        }
    }
}
