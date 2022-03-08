using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDestroyed(Enemy enemy);
    public event EnemyDestroyed OnEnemyDestroyed;
    
    public int pointValue = 10;
    
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
      //Debug.Log("Ouch!");
      OnEnemyDestroyed?.Invoke(this);
      Destroy(this.gameObject);
    }
}