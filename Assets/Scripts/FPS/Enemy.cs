using UnityEngine;

namespace FPS
{
    public class Enemy : MonoBehaviour
    {
        public Transform target;

        [Header("Attributes")]
    
        public float range;
        public float fireRate = 1f;
        private float fireRateCount;
        public int startHealth = 100;
        private int currentHealth;

        [Header("Setup Fields")]
    
        public string targetTag = "Player";
        public Transform enemyRotation;

        public GameObject bulletPrefab;
        public Transform firePoint;

        private Animator animator;
    
        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating(nameof(TargetInRange), 0f, 1f);
            currentHealth = startHealth;

            animator = GetComponentInChildren<Animator>();
        }

        private void TargetInRange()
        {
            var targets = GameObject.FindGameObjectWithTag(targetTag);
            var distanceToTarget = Vector3.Distance(transform.position, targets.transform.position);

            if (targets != null && distanceToTarget <= range)
            {
                target = targets.transform;
            }
            else
            {
                target = null;
            }
        }
    
        // Update is called once per frame
        void Update()
        {
            if (target == null)
                return;

            // Enemy lock on target
            var turnSpeed = 10f; 
            var directions = target.position - transform.position;
            var look = Quaternion.LookRotation(directions);
            var rotations = Quaternion.Lerp(enemyRotation.rotation, look, Time.deltaTime * turnSpeed).eulerAngles;
            enemyRotation.rotation = Quaternion.Euler(0f, rotations.y, 0f);
            animator.SetFloat("Speed", 0);
        
            if (fireRateCount <= 0f)
            {
                Shoot();
                fireRateCount = 1f / fireRate;
            }
            fireRateCount -= Time.deltaTime;
        }

        void Shoot()
        {
            animator.SetFloat("Speed", 1);
        
            var bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            var bullet = bulletGO.GetComponent<Bullet>();

            if (bullet != null)
                bullet.Chase(target);
        
        }

        public void Damage(Transform enemy)
        {
            var e = enemy.GetComponent<Enemy>();

            if (e != null)
            {
                e.TakeDamage(20);
            }
        }
    
        void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
                Die();
        }

        void Die()
        {
            Destroy(gameObject);
        }
    
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}
