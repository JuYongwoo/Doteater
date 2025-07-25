﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public bool canWarp = true;


    private const float movespeedconst = 5f;
    private float movespeedbonus = 0f;
    private const float rotationSpeed = 360f;
    private float hp = 100.0f;
    private float stamina = 100.0f;
    private bool issprinting = false;
    private bool issprintready = true;

    [SerializeField]
    private AudioClip hitvoice;
    [SerializeField]
    private AudioClip dashvoice;
    [SerializeField]
    private AudioClip coinsound;
    private AudioSource voice;


    private CharacterController charCtrl;
    private Animator anim;
    static public event Action facedamaged;

    static public event Action<float> refreshHPBar;
    static public event Action<float> refreshStaminaBar;

    // Start is called before the first frame update
    void Awake()
    {
        charCtrl = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>(); //이 스크립트가 붙어있는 오브젝트의 자식 오브젝트에서 가져온다.

        voice = GetComponent<AudioSource>();

        canWarp = true;
        Teleport.warpOn += setWarpAble;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (dir.sqrMagnitude > 0.001f)
        {
            Vector3 forward = Vector3.Slerp(transform.forward, dir,rotationSpeed * Time.deltaTime  / Vector3.Angle(transform.forward, dir));
            transform.LookAt(transform.position + forward * 2);
        }
        anim.SetFloat("Speed", charCtrl.velocity.magnitude); // Speed라는 이름의 float에 velocity.magnitude를 set한다.

        charactermove(dir);

        if (Input.GetKeyDown(KeyCode.LeftControl) && issprintready && !issprinting && stamina > 30)
        {
            charactersprint();
        }

        refreshStaminaBar(stamina);

    }

    private void setWarpAble(bool OnOff)
    {
        canWarp = OnOff;
    }

    private void charactermove(Vector3 dir)
    {
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            charCtrl.SimpleMove(dir * (movespeedconst + movespeedbonus) * 2 * 50 * Time.deltaTime);
            stamina -= Time.deltaTime * 20;
        }
        else
        {
            charCtrl.SimpleMove(dir * (movespeedconst + movespeedbonus) * 50 * Time.deltaTime);
            if (stamina < 100) stamina += Time.deltaTime * 10;
        }

    }

    private void charactersprint() {

            stamina -= 30;
            issprintready = false;
            anim.SetBool("Sprint", true);

            voice.clip = dashvoice;
            voice.Play();

            movespeedbonus = 3f;

            StartCoroutine(notsprint()); //sprint
            StartCoroutine(readytosprint());

    }

    public void getDamaged()
    {

        hp -= 10;
        if (hp < 0)
        {
            SceneManager.LoadScene("Lose");
        }
        facedamaged?.Invoke();
        refreshHPBar(hp);
    }

    IEnumerator notsprint()
    {
        yield return new WaitForSeconds(1);
        anim.SetBool("Sprint", false);
        issprinting = false;
        movespeedbonus = 0f;


    }

    IEnumerator readytosprint()
    {
        yield return new WaitForSeconds(3);
        issprintready = true;
    }


}
