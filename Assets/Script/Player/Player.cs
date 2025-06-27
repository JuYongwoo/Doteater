using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEditor.Animations;

public class Player : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 5f;
    [SerializeField]
    float rotationSpeed = 360f;
    public float hp = 100.0f;
    public float stamina = 100.0f;
    float nowtime = 0.0f;
    float thattime = 0.0f;
    float sprinttime2 = 0.0f;
    bool sprinting = false;
    float sprintcooling = 3.0f;
    [SerializeField]
    float sprintcooltime = 3.0f;
    float staminacooltime = 0.0f;
    [SerializeField]
    AudioClip hitvoice;
    [SerializeField]
    AudioClip dashvoice;
    [SerializeField]
    AudioClip coinsound;
    AudioSource voice;


    CharacterController charCtrl;
    Animator anim;
    public Animator Faceanim;
    Animator Enemyanim;





    static public event Action<float> refreshHPBar;
    static public event Action<float> refreshStaminaBar;

    // Start is called before the first frame update
    void Awake()
    {
        charCtrl = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>(); //이 스크립트가 붙어있는 오브젝트의 자식 오브젝트에서 가져온다.

        Faceanim = gameObject.GetComponent<Animator>();
        if (Faceanim == null)
            Faceanim = gameObject.AddComponent<Animator>();
        Faceanim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/Face");
        if (Resources.Load<RuntimeAnimatorController>("Animations/Face") == null) Debug.Log("SAFSADSDASADFDS");
        Faceanim.SetBool("Damaged", false);
        voice = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(this.gameObject.name=="Player") {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (dir.sqrMagnitude > 0.001f)
        {
            Vector3 forward = Vector3.Slerp(transform.forward, dir,rotationSpeed * Time.deltaTime  / Vector3.Angle(transform.forward, dir));
            transform.LookAt(transform.position + forward * 2);
        }
        charCtrl.SimpleMove(dir * moveSpeed * 50 * Time.deltaTime);
        anim.SetFloat("Speed", charCtrl.velocity.magnitude); // Speed라는 이름의 float에 velocity.magnitude를 set한다.


    }
        //Shift키를 누를 경우
        if(Input.GetKey(KeyCode.LeftShift) && stamina >0)
        {
                moveSpeed = 10;
                stamina -= Time.deltaTime * 20;
                staminacooltime = 0.0f;
        }
        else
        {
            //Shift키를 누르지 않을시
            moveSpeed = 5;
            staminacooltime += Time.deltaTime;
            if(staminacooltime>1)
            stamina += Time.deltaTime * 10;
        }

        //맞는 딜레이
        if (nowtime - thattime > 1)
        {
            Faceanim.SetBool("Damaged", false);

        }


        //Ctrl키를 누를 경우
        if (Input.GetKeyDown(KeyCode.LeftControl) && sprintcooling > sprintcooltime && stamina >30)
        {
            sprinttime2 = nowtime+0.3f;
            sprinting = true;

            stamina -= 30;
            staminacooltime = 0.0f;
            sprintcooling = 0;

        }
        else
        {
            sprintcooling += Time.deltaTime;

        }

        if(sprinttime2>nowtime && sprinting)
        {
            voice.clip = dashvoice;
            voice.Play();
            anim.SetBool("Sprint", true);
            Faceanim.SetBool("Rushing", true);
            Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            charCtrl.Move(dir * 8 * Time.deltaTime);
        }
        else
        {
            sprinting = false;
        }


        //스프린트 모션 복구 딜레이
        if (sprinttime2<nowtime)
        {
            anim.SetBool("Sprint", false);
            Faceanim.SetBool("Rushing", false);
        }


        if (stamina > 100)
            stamina = 100;
        if (stamina < 0)
            stamina = 0;

        nowtime += Time.deltaTime; //nowtime은 게임 시작 경과시간




        refreshStaminaBar(stamina);

    }

    public void getDamaged()
    {

        hp -= 10;
        if (hp < 0)
        {
            ManagerObject.Scene.LoadScene(Define.Scene.Lose);
        }
        Faceanim.SetBool("Damaged", true);

        refreshHPBar(hp);
    }


}
