using UnityEngine;

public class Rickshaw : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector2.down * GameManager.instance.rickshawSpeed * Time.deltaTime);
    }
}
