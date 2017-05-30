using UnityEngine;

public class EnemyController : MonoBehaviour {

    private GameObject target;
    private float speed = 4.5f;

    private EnemyLauncher enemyLauncher;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player");
        transform.LookAt(target.transform.position);

        enemyLauncher = GameObject.Find("EnemyLauncher").GetComponent<EnemyLauncher>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            enemyLauncher.enemies.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Dead Player");
        }
    }
}
