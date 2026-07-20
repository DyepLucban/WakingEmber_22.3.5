using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    #region Facing Direction
    public bool isFacingRight = true;
    public float facingDir { get; private set; } = 1;
    #endregion

    #region Components
    public Animator animator { get; private set; }
    public Rigidbody2D rb { get; private set; }
    #endregion

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    public void setVelocity(float _xVelocity, float _yVelocity) => rb.linearVelocity = new Vector2(_xVelocity, _yVelocity);
    public void setVelocityToZero() => rb.linearVelocity = Vector2.zero;
    public void Flip(float _movingDir)
    {
        if (isFacingRight && _movingDir < 0f || !isFacingRight && _movingDir > 0f)
        {
            facingDir = _movingDir * -1f;
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
