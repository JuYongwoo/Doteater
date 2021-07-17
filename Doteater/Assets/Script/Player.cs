using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float rotationSpeed = 360f;
    public float hp = 100.0f;
    public float stamina = 100.0f;
    float nowtime = 0.0f;
    float thattime = 0.0f;
    float hitcooltime = 0.0f;
    float staminacooltime = 0.0f;
    public GameObject Faceobj;

    CharacterController charCtrl;
    Animator anim;
    Animator anim2;
    // Start is called before the first frame update
    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>(); //이 스크립트가 붙어있는 오브젝트의 자식 오브젝트에서 가져온다.
        anim2 = Faceobj.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(this.gameObject.name=="Player") {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (dir.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(transform.forward, dir,rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, dir));
            transform.LookAt(transform.position + forward);
        }
        charCtrl.Move(dir * moveSpeed * Time.deltaTime);
        anim.SetFloat("Speed", charCtrl.velocity.magnitude); // Speed라는 이름의 float에 velocity.magnitude를 set한다.

        if (GameObject.FindGameObjectsWithTag("Dot").Length < 1){
            SceneManager.LoadScene("Win");
        } else {
            GameObject.Find("Score").GetComponent<Text>().text=GameObject.FindGameObjectsWithTag("Dot").Length + "개 남음";
        }
    }

        if(Input.GetButton("Fire3") && stamina >0)
        {
            moveSpeed = 10;
            stamina -= Time.deltaTime * 30;
            staminacooltime = 0.0f;
        }
        else
        {
            staminacooltime += Time.deltaTime;
            moveSpeed = 5;
            if(staminacooltime>2)
            stamina += Time.deltaTime * 10;

            if (stamina > 100)
                stamina = 100;
        }
            nowtime += Time.deltaTime;

        if (nowtime - thattime > 1)
        {
            anim2.SetBool("Damaged", false);

        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Dot":
                Destroy(other.gameObject);
                break;
            case "Enemy":
                thattime = nowtime;
                hp -= 10;
                if(hp<0)
                {
                    SceneManager.LoadScene("Lose");
                }
                anim2.SetBool("Damaged", true);

                break;
        }
    }

}
