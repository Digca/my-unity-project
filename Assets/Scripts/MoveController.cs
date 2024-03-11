using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector2(moveInput, 0f);
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}