using UnityEngine;

namespace MagneticFishing
{
    public class Energy : MonoBehaviour
    {
        [SerializeField] private float maxEnergy = 100;
        [SerializeField, Tooltip("Расход энергии")] private float energyConsumption;
        private float currentEnergy;

        public float EnergyConsumptionAtTime { get { return energyConsumption; } }

        private void Start()
        {
            currentEnergy = maxEnergy;
        }

        public bool EnergyConsumption(float useUpEnergy)
        {
            currentEnergy -= useUpEnergy;
            if (currentEnergy <= 0)
            {
                currentEnergy = 0;
                return true;
            }
            EventBusGame.ChangeFieldsEnergy?.Invoke(currentEnergy, maxEnergy);
            return false;
        }

        public void EnergyRecovery(float addEnergy)
        {
            if (currentEnergy + addEnergy > maxEnergy)
            {
                currentEnergy = maxEnergy;
                return;
            }
            currentEnergy += addEnergy;
        }
    }
}
