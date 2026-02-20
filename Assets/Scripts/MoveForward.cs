using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 80.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }
}
