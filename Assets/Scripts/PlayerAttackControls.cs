using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackControls : MonoBehaviour
{
    private PlayerMoveControls moveControls;
    private GatherInput gI;
    private Animator anim;

    public PolygonCollider2D polyCol;
    public AudioSource source;
    public bool attackStarted = false;
    void Start()
    {
        moveControls = GetComponent<PlayerMoveControls>();
        gI = GetComponent<GatherInput>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (gI.tryAttack)
        {
            if (attackStarted || moveControls.hasControl == false || moveControls.knockBack || moveControls.onLadders)
                return;
            anim.SetBool("Attack", true);
            attackStarted = true;
        }
    }

    public void ActivateAttack()
    {
        polyCol.enabled = true;
        source.Play();
    }

    public void ResetAttack()
    {
        anim.SetBool("Attack", false);
        gI.tryAttack = false;
        attackStarted = false;
        polyCol.enabled = false;
        source.Stop();
    }
}
