using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float lookSpeed;

    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    public float bulletSpeed;
    public GameObject bulletPrefab;
    private Vector3 bulletOffset = new Vector3(0, 0.9f, 0.8f);

    // Update is called once per frame
    void Update () {

        ShootBullet();
        RotateCharacter();
		
	}

    private void RotateCharacter()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * lookSpeed * Input.GetAxis("Horizontal"));
    }

    private void ShootBullet()
    {
        Vector3 direction = transform.forward;
        Vector3 worldOffset = transform.rotation * bulletOffset;
        Vector3 spawnPosition = transform.position + worldOffset;
        GameObject bullet;

        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            bullet = Instantiate(bulletPrefab, spawnPosition, transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
            Destroy(bullet, 6.0f);
        }

    }

}
