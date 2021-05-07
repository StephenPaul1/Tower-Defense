using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;

    [Header("General")]

    public float range = 15f;

    [Header ("Use Bullets (Defaults")]
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public GameObject bulletPrefab;


    [Header("Use Laser")]
    public bool useLaser = false;
    public int damgeOverTime = 30;
    public float slowPct = .5f;
    public LineRenderer lineRenderer;
    // DONT DO public ParticleSystem impactEffect;
    // DONT DO public Light impaceLight;


    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";
    public Transform PartToRoate;
    public float turnSpeed = 10;
    
    public Transform firePoint;



    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;

            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
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
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)

                {
                    lineRenderer.enabled = false;
                    // DONT DO impactEffect.Stop();
                    // DONT DO impacetLifht.enabled = false;
                }
                    
            }
            return;
        }

        LockOnTarget();

        if (useLaser)
        {

            Laser();

        }

        else
        {

            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;

            }
            fireCountdown -= Time.deltaTime;
        }


        
    }

    void LockOnTarget()
    {
        //Target Lock on

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(PartToRoate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        PartToRoate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    }

    void Laser()
    {
        target.GetComponent<Enemy>().TakeDamage(damgeOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPct);

        //targetEnemy.TakeDamage(damgeOverTime * Time.deltaTime);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            // DONT DO impactEffetc.Play();
            //DONT DO impaceLiggt.enabled = true;
        }
            

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        //DONT DO vectror3 dir = firePoint.posituin - target.position;
        //DONT DO impactEffect.transform.postiuin - target.position + dir.normalised * .5f;
        // DONT DO impactEffect.transfor.roation = Quaternion.LookToation(dir);


    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
