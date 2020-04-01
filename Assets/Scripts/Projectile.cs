using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    [SerializeField] float speed = 1f;
    [SerializeField] float rotationAngle = 360f;
    [SerializeField] int damage = 20;

    GameObject projectileParent;
    // Start is called before the first frame update
    void Start()
    {
        CreateProjecitleParent();
    }

    private void CreateProjecitleParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
        transform.parent = projectileParent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -rotationAngle * Time.deltaTime));
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
    }

    public void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var attacker = otherCollider.GetComponent<Attacker>();
        var health = otherCollider.GetComponent<Health>();
        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
