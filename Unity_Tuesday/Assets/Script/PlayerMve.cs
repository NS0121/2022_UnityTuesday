using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMve : MonoBehaviour
{
    [SerializeField]private Rigidbody rb = null;
    float moveX = 0f;
    float moveZ = 0f;
    bool isStop = false;
    Vector3 teleportPoint = new Vector3(0, 3, 0);
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        StartCoroutine(ChangeMve());
    }

    IEnumerator ChangeMve()
    {
        while (true)
        {
            if(isStop)
            {
                yield return new WaitForSeconds(0.1f);
                isStop = false;
            }
            moveX = Input.GetAxis("Horizontal");
            moveZ = Input.GetAxis("Vertical");
            rb.AddForce(moveX, moveZ, 0);
            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            rb.MovePosition(teleportPoint);
            isStop = true;
        }

    }
}
