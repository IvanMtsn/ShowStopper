using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunBasic : MonoBehaviour
{
    public Animator GunAnimator;
    PlayerMove _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        GunAnimator.SetFloat("walkingSpeedX", _player.GetMovement().x);
        GunAnimator.SetFloat("walkingSpeedY", _player.GetMovement().y);
        GunAnimator.SetFloat("speed", _player.GetMovement().sqrMagnitude);
        Debug.Log(_player.GetMovement().sqrMagnitude);
        GunAnimator.SetBool("isGrounded", _player.characterController.isGrounded);
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        Debug.Log(GunAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name);
    }
    void Shoot()
    {
        if (GunAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Armature.002_ShootBasic")
        {
            GunAnimator.SetTrigger("shootBasicTrigger");
            //alles andere
        }
    }
    IEnumerator BOOM()
    {
        GunAnimator.SetTrigger("shootBasicTrigger");
        yield return new WaitForSeconds(0.5f);
    }
}
