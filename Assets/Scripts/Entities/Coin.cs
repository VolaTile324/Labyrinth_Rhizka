using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] Transform visual;
    [SerializeField] CoinData data;
    [SerializeField] BaseAnims anim;

    public int Value { get => data.value; }

    private void Start()
    {
        visual.GetComponent<MeshRenderer>().material = data.material;
        if (anim != null)
        {
            anim.Animate(visual);
        }
    }
}
