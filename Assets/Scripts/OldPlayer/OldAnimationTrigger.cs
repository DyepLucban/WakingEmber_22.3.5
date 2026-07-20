using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldAnimationTrigger : MonoBehaviour
{
    private OldPlayer player => GetComponentInParent<OldPlayer>();

    public void oldAnimationTrigger() => player.oldAnimationTrigger();

    public void attackTrigger()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(player.attackChecker.position, player.attackCheckerRadius);
    }
}
