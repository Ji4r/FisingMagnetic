using System.Collections.Generic;
using UnityEngine;
namespace MagneticFishing
{
    public static class GeneratorIdProp
    {
        private static HashSet<int> uniqueIdProp = new HashSet<int>();
        private static int lastGeneratedId = -1;

        public static void GenererateIdSubject(GameObject newObject)
        {
            if (newObject == null)
                return;

            if (newObject.TryGetComponent<Subject>(out var subjectDescription))
            {
                int newId = lastGeneratedId + 1;

                while (uniqueIdProp.Contains(newId))
                {
                    newId++;
                }
                uniqueIdProp.Add(newId);
                lastGeneratedId = newId;
                subjectDescription.Id = newId;
            }
        }

        public static void ReleaseId(int id)
        {
            uniqueIdProp.Remove(id);
        }
    }
}
