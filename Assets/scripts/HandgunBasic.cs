using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunBasic : MonoBehaviour
{
    public Animator GunAnimator;
    PlayerMove _player;
    bool _readyToShoot = true;
    float _shootDelay = 0.55f;
    float _lastShootTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<PlayerMove>();
    }

    void Update()
    {
        #region Shoot and Delay
        if ((Input.GetButtonDown("Fire1") || Input.GetButton("Fire1")) && _readyToShoot)
        {
            Shoot();
            _lastShootTime = Time.time;
            _readyToShoot = false;
        }

        if (!_readyToShoot && Time.time - _lastShootTime >= _shootDelay)
        {
            _readyToShoot = true;
        }
        #endregion

        #region Animators
        GunAnimator.SetFloat("walkingSpeedX", _player.GetMovement().x);
        GunAnimator.SetFloat("walkingSpeedY", _player.GetMovement().y);
        GunAnimator.SetFloat("speed", _player.GetMovement().sqrMagnitude);
        GunAnimator.SetBool("isGrounded", _player.characterController.isGrounded);
        #endregion
    }

    void Shoot()
    {
        GunAnimator.SetBool("isShooting", true);
        GunAnimator.SetTrigger("shootBasicTrigger");
        StartCoroutine(EndShot());
    }

    IEnumerator EndShot()
    {
        yield return new WaitForSeconds(0.4f);
        GunAnimator.ResetTrigger("shootBasicTrigger");
        GunAnimator.SetBool("isShooting", false);
    }
}
