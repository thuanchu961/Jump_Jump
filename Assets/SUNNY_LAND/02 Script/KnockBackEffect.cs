using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackEffect : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigi;
    [SerializeField] private float  KBForce;
    [SerializeField] private float  KBDuration;   
    [SerializeField] private bool   isKnockBack;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (isKnockBack) return;

            // Tính toán hướng knockback (ngược với hướng va chạm)
            Vector2 knockBackDirection = (transform.position - collision.transform.position).normalized;

            Knockback(knockBackDirection);
        }
    }
    void Knockback(Vector2 direction)
    {
        // Tắt Gravity Scale để tránh ảnh hưởng từ trọng lực
        rigi.gravityScale = 0f;
        isKnockBack = true;

        // Áp dụng lực đẩy lùi
        rigi.AddForce(direction * KBForce, ForceMode2D.Impulse);

        // Kích hoạt coroutine để khôi phục trạng thái ban đầu sau khoảng thời gian knockbackDuration
        StartCoroutine(ResetKnockback());
    }

    IEnumerator ResetKnockback()
    {
        yield return new WaitForSeconds(KBDuration);

        // Bật lại Gravity Scale
        rigi.gravityScale = 1f;
        isKnockBack = false;
    }
}
