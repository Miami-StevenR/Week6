using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveBall : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidbody;
    [SerializeField]
    private Camera gameCamera;
    [SerializeField]
    private MeshRenderer meshRenderer;

    private InputAction click;

    void Awake()
    {
        click = new InputAction(binding: "<Mouse>/leftButton");
        click.performed += ctx => {
            RaycastHit hit;
            Vector3 coor = Mouse.current.position.ReadValue();
            if (Physics.Raycast(gameCamera.ScreenPointToRay(coor), out hit))
            {
                hit.collider.SendMessage("OnMouseDown", SendMessageOptions.DontRequireReceiver);
            }
        };
        click.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        var randomVector3Force = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
        rigidbody.AddForce(randomVector3Force, ForceMode.Impulse);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ColorChangeTrigger"))
        {
            meshRenderer.material.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        }
    }
}
