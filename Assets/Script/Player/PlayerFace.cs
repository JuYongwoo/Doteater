﻿using System.Collections;
using UnityEngine;

public class PlayerFace : MonoBehaviour
{
    [HideInInspector]
    public Animator Faceanim;

    // Start is called before the first frame update
    void Awake()
    {

        Faceanim = gameObject.GetComponent<Animator>();
        if (Faceanim == null)
            Faceanim = gameObject.AddComponent<Animator>();
        Faceanim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/Face");
        Faceanim.SetBool("Damaged", false);


        Player.facedamaged += changeFaceDamage;
    }
    IEnumerator ResetFace()
    {
        yield return new WaitForSeconds(0.75f);
        Faceanim.SetBool("Damaged", false);


    }
    public void changeFaceDamage()
    {
        Faceanim.SetBool("Damaged", true);
        StartCoroutine(ResetFace());

    }


}
