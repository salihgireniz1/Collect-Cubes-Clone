using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollector
{
    /// <summary>
    /// Initialize all the methods to collect a coin completely.
    /// </summary>
    /// <param name="collectedObject">
    /// The coin object to collect, the one that player collided.
    /// </param>
    void Collect(GameObject collectedObject);

    /// <summary>
    /// Initialize processes to handle the amount of collected coin.
    /// </summary>
    /// <param name="collectedObject">
    /// The coin object to collect,  the one that player collided.
    /// </param>
    /// <returns>Determined value of coin that is collected.</returns>
    int HandleCollectionAmount(GameObject collectedObject);

    /// <summary>
    /// Initialize processes to save collected amount to PlayerPrefs.
    /// </summary>
    /// <param name="amount">Value that is collected and going to be saved.</param>
    void HandleCollectionData(int amount);
}