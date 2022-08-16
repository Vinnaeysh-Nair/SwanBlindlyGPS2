using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Joint : MonoBehaviour
{
    [SerializeField] Rigidbody playerRb;
    [SerializeField] Rigidbody boxRb;
    //[SerializeField] Collider collider;
    [SerializeField] GameObject canvas;
    [SerializeField] float radius;
    [SerializeField] Transform player;
    [SerializeField] Button attachButton;
    [SerializeField] Button detachButton;

    void Awake()
    {

    }

    void Start()
    {
        canvas.SetActive(false);
        attachButton.onClick.AddListener(Attach);
        detachButton.onClick.AddListener(Detach);
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if(distance <= radius)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.transform.tag == "Box")
                    {
                        canvas.SetActive(true);
                    }
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "MC_01")
        {
            Update();
        }
    }

    public void Attach()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        canvas.SetActive(false);
        boxRb.constraints = RigidbodyConstraints.None;
        boxRb.constraints = RigidbodyConstraints.FreezeRotation;

        if(distance <= radius)
        {
            GetComponent<FixedJoint>().connectedBody = playerRb;
        }
    }

    public void Detach()
    {
        canvas.SetActive(false);
        boxRb.constraints = RigidbodyConstraints.FreezePosition;
        boxRb.constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<FixedJoint>().connectedBody = null;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}