using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;

  public float moveSpeed = 40f;

  public Transform shottingOffset;

  private bool shootDelay;
    void Update()
    {
      // Move --------------------------------
      float axis = Input.GetAxis("Horizontal");

      Vector3 movement = new Vector3(moveSpeed * axis, 0f, 0f);

      movement *= Time.deltaTime;
      
      transform.Translate(movement);
      
      // Shoot -------------------------------
      
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        //Debug.Log("Bang!");

        Destroy(shot, 10f);

      }
    }
}
