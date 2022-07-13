using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playershooting : MonoBehaviour
{
    // Start is called before the first frame update
    public int damagePerShot = 20;                  // The damage inflicted by each bullet.
    public float timeBetweenBullets = 0.15f;        // The time between each shot.
    float range = 1000f;                      // The distance the gun can fire.
    public int startammo = 30;
    private int currentammo;
    private bool isfireing;
    private bool isreloading;
    public float reloadtime = 1f;
    public Animator anim;
    public GameObject impactpartical;
    public GameObject coin;
    float timer;                                    // A timer to determine when to fire.
    Ray shootRay;                                   // A ray from the gun end forwards.
    RaycastHit shootHit;                            // A raycast hit to get information about what was
    int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
    ParticleSystem gunParticles;                    // Reference to the particle system.
   // LineRenderer gunLine;                           // Reference to the line renderer.
    AudioSource gunAudio;                           // Reference to the audio source.
   // public GameObject manager2;
   

    // float effectsDisplayTime = 0.2f;                                                  //  Light gunLight;                                 // Reference to the light component.
    // float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.

    void Start()
    {
        currentammo = startammo;
    }



    void Awake()
    {
        // Create a layer mask for the Shootable layer.
        shootableMask = LayerMask.GetMask("shootable");

        // Set up the references.
        gunParticles = GetComponent<ParticleSystem>();
      //  gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
       // gunLight = GetComponent<Light>();
    }


     void OnEnable()
    {
        isreloading = false;
        anim.SetBool("reloading", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isreloading)
        {
            return;
        }
        reloadmanager.reload = currentammo;
        timer += Time.deltaTime;
        if (currentammo <= 0)
        {
            StartCoroutine(reload());
            return;
        }

        // If the Fire1 button is being press and it's time to fire...
        if (isfireing && timer >= timeBetweenBullets)
        {
            // ... shoot the gun.
            Shoot();
        }

        // If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...

    }

    public void pointerdown()
    {
        isfireing = true;
    }

    public void pointerup()
    {
        isfireing = false;
    }

    IEnumerator reload()
    {
        isreloading = true;
        anim.SetBool("reloading", true);
        yield return new WaitForSeconds(reloadtime - 0.25f);
        anim.SetBool("reloading", false);
        yield return new WaitForSeconds( 0.25f);
        currentammo = startammo;
        isreloading = false;
    }

    void Shoot()
    {
        // Reset the timer.
        timer = 0f;
        currentammo--;


        // Play the gun shot audioclip.
        gunAudio.Play();
       


        // Enable the light.
      //  gunLight.enabled = true;

        // Stop the particles from playing if they were, then start the particles.
        gunParticles.Stop();
        gunParticles.Play();

        // Enable the line renderer and set it's first position to be the end of the gun.
       // gunLine.enabled = true;
      //  gunLine.SetPosition(0, transform.position);

        // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

       // if (scoremanager.score >= 500)
       // {
       //     manager2.SetActive(true);
           // CancelInvoke();
       // }

        // Perform the raycast against gameobjects on the shootable layer and if it hits something...
        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            // Try and find an EnemyHealth script on the gameobject hit.
            enemyhealth enemyHealth = shootHit.collider.GetComponent<enemyhealth>();

            // If the EnemyHealth component exist...
            if (enemyHealth != null)
            {
                // ... the enemy should take damage.
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);

                if (enemyHealth.currentHealth <= 0)
                {
                    int rand = Random.Range(0, 60);
                    if(rand == 1)
                    {
                        var coindestroy = Instantiate(coin, shootHit.point, Quaternion.LookRotation(shootHit.normal));
                        Destroy(coindestroy, 10f);
                    }
                   
                }
               

            }

            if (shootHit.collider.tag.Equals("twitenemy"))
            {
                enemyhealth enemybosshealth = shootHit.collider.GetComponent<enemyhealth>();

                if (enemyHealth.currentHealth <= 0)
                {
                    int rand = Random.Range(1, 2);
                    if (rand == 1)
                    {
                        Vector3 b = shootHit.point;
                        b.y = -11;
                        var coindestroy = Instantiate(coin, b , Quaternion.LookRotation(shootHit.normal));
                        Destroy(coindestroy, 10f);
                    }

                }

            }

            // Set the second position of the line renderer to the point the raycast hit.
            // gunLine.SetPosition(1, shootHit.point);
            if(enemyHealth == null)
            {
                GameObject impactgo = Instantiate(impactpartical, shootHit.point, Quaternion.LookRotation(shootHit.normal));
                Destroy(impactgo, 2f);
            }
          
        }
        // If the raycast didn't hit anything on the shootable layer...
       
    }

    
}
