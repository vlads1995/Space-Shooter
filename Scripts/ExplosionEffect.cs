using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 3f);
    }
}
