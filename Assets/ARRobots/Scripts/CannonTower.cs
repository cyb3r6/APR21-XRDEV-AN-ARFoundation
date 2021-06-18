using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : MonoBehaviour
{
    public float shootingForce = 100f;
    public float turnSpeed = 40f;
    public GameObject cannonBallPrefab;
    public Transform spawnPoint;

    
    void OnEnable()
    {
        InvokeRepeating("ShootAtPlayer", 3f, 4f);
    }

    private void Update()
    {
        if (!GameManager.instance.RobotPlayer())
        {
            return;
        }
        else
        {
            Vector3 targetDirection = GameManager.instance.RobotPlayer().transform.position - transform.position;
            Vector3 direction = Vector3.RotateTowards(transform.forward, targetDirection, Time.deltaTime * turnSpeed, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    private void ShootAtPlayer()
    {
        if (GameManager.instance.RobotPlayer())
        {
            GameObject cannonball = Instantiate(cannonBallPrefab, spawnPoint.position, spawnPoint.rotation);
            cannonball.GetComponent<Rigidbody>().AddForce(cannonball.transform.forward * shootingForce);

            Destroy(cannonball, 3f);
        }
    }
}
