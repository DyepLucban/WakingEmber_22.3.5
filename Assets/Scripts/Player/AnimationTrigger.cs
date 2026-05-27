using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>();

    public void animationTrigger() => player.animationTrigger();

    public void attackTrigger()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(player.attackChecker.position, player.attackCheckerRadius);
    }
}
