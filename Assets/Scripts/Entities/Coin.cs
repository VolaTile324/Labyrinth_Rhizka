using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] Transform visual;
    [SerializeField] AudioSource pickupSound;
    [SerializeField] CoinData data;
    [SerializeField] BaseAnims anim;
    [SerializeField] CustomEvent customEvent;

    bool isCollected;

    private void Start()
    {
        visual.GetComponent<MeshRenderer>().material = data.material;
        if (anim != null)
        {
            anim.Animate(visual);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        OnTriggerEnter(other.collider);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            customEvent.OnInvoked.Invoke();
            visual.GetComponent<MeshRenderer>().material = data.invisMaterial;
            if (isCollected == false)
            {
                pickupSound.Play();
                isCollected = true;
            }
        }
    }

    public void AlreadyCollected()
    {
        visual.GetComponent<MeshRenderer>().material = data.invisMaterial;
        isCollected = true;
    }
}
