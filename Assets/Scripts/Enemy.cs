using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDestroyed(Enemy enemy);
    public event EnemyDestroyed OnEnemyDestroyed;
    
    public int pointValue = 10;

    public Sprite[] sprites;
    public float aniTime = 1.0f;

    private SpriteRenderer spr;
    private int aniFrame;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.aniTime, this.aniTime);
    }

    private void AnimateSprite()
    {
        aniFrame++;

        if (aniFrame >= this.sprites.Length)
        {
            aniFrame = 0;
        }

        spr.sprite = this.sprites[aniFrame];
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
      //Debug.Log("Ouch!");
      OnEnemyDestroyed?.Invoke(this);
      Destroy(this.gameObject);
    }
}