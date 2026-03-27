using UnityEngine;

public class StunPowerUp : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemyobj in enemies)
            {
                Enemy enemy = enemyobj.GetComponent<Enemy>();
                enemy.Stun();
            }
            Destroy(this.gameObject);
        }
    }
}
