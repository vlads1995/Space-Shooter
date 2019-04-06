using UnityEngine;

public class Laser : MonoBehaviour
{
    private const float Speed = 10.0f;

    private void Update()
    {      
        transform.Translate(Vector3.up * Speed *  Time.deltaTime);
        if (transform.position.y > 6.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
