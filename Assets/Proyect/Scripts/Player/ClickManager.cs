using UnityEngine;
using UnityEngine.InputSystem;

public class ClickManager : MonoBehaviour
{
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Click en: " + hit.collider.name);

                Comment comment = hit.collider.GetComponent<Comment>();

                if (comment != null)
                {
                    comment.Select();
                }
            }
        }
    }
}