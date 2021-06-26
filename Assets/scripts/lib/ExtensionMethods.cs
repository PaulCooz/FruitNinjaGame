using System.Collections.Generic;
using lib;
using UnityEngine;

[System.Serializable]
public static class ExtensionMethods
{
    public static T GetRandomObject<T>(this IEnumerable<ObjectAndChance<T>> ArrayOfObjects)
    {
        int SumOfChances = 0;
        foreach (var i in ArrayOfObjects)
        {
            SumOfChances += i.Chance;
        }

        var First = ArrayOfObjects.GetEnumerator();
        First.Reset();
        First.MoveNext();
        T Result = First.Current.Object;

        int CurrentChance = Random.Range(1, SumOfChances + 1);
        foreach (var i in ArrayOfObjects)
        {
            CurrentChance -= i.Chance;

            if (CurrentChance <= 0)
            {
                Result = i.Object;
                break;
            }
        }

        return Result;
    }
}
