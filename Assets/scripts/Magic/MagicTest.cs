using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTest : MonoBehaviour
{
    public float speed=2f;
    public LayerMask enemy;
    public float attackRange;
    public Transform attackPos;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed *Time.deltaTime);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, attackRange, enemy);
        if(hitInfo.collider != null){
            if (hitInfo.collider.CompareTag("Enemy")){
                hitInfo.collider.GetComponent<EnemyControl>().TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
