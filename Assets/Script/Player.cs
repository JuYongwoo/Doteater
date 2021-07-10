using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float rotationSpeed = 360f;

    CharacterController charCtrl;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>(); //이 스크립트가 붙어있는 오브젝트의 자식 오브젝트에서 가져온다.
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 dir = new Vector3(
            Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (dir.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(
                transform.forward, dir,
                rotationSpeed * Time.deltaTime /
Vector3.Angle(transform.forward, dir)
                );
            transform.LookAt(transform.position + forward);
        }
        charCtrl.Move(dir * moveSpeed * Time.deltaTime);
        anim.SetFloat("Speed", charCtrl.velocity.magnitude); // Speed라는 이름의 float에 velocity.magnitude를 set한다.

        if (GameObject.FindGameObjectsWithTag("Dot").Length < 1)
            SceneManager.LoadScene("Win");
    }
    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Dot":
                Destroy(other.gameObject);
                break;
            case "Enemy":
                SceneManager.LoadScene("Lose");
                break;
        }
    }

}
