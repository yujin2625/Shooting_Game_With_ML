using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject playerCameraRoot;
    [SerializeField]
    private float delay;
    private Vector3 bulletDirec;

    public void Start()
    {
    }

    public void FireBullet()
    {
        Invoke(nameof(FireDelay), delay);
    }

    void FireDelay()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position;
        bulletDirec = playerCameraRoot.transform.position - Camera.main.transform.position;
        bullet.GetComponent<Rigidbody>().AddForce(bulletDirec, ForceMode.Impulse);
    }

}
