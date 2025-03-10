using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [Header("SFX")]
    public AudioClip ShootAudio;
    public AudioClip StepAudio;
    public AudioClip DeathAudio;
    AudioSource PlayerAudio;
    public Animator anim;
    public float Hitpoint;
    private bool isWalking = false;

    void Start()
    {
        PlayerAudio = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerGetHit(100f);
        }

        // Check for player input to determine if the character is walking.
        float moveInput = Input.GetAxis("Horizontal") + Input.GetAxis("Vertical");
        if (Mathf.Abs(moveInput) > 0)
        {
            anim.SetBool("Walk", true);
        }
        

    }

    public void PlayerGetHit(float damage)
    {
        Debug.Log("Player Receive Damage -> " + damage);
        Hitpoint = Hitpoint - damage;
        anim.SetTrigger("GetHit");
        if (Hitpoint <= 0)
        {
            PlayerAudio.clip = DeathAudio;
            PlayerAudio.Play();
            anim.SetBool("Death", true);
        }
    }

    public void step()
    {
        Debug.Log("Step");
        PlayerAudio.clip = StepAudio;
        PlayerAudio.Play();
    }
}
