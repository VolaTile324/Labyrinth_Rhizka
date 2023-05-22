using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Coin Data", menuName = "Custom Assets/Game Objects/Coin")]

public class CoinData : ScriptableObject
{
    public Material material;
    public Material invisMaterial;
}
