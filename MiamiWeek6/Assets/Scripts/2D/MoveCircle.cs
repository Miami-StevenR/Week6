using UnityEngine;
using UnityEngine.EventSystems;

public class MoveCircle : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Rigidbody2D rigidbody;
    [SerializeField]
    private MeshRenderer meshRenderer;

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Pointer Clicked");
        var randomVector2Force = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
        rigidbody.AddForce(randomVector2Force, ForceMode2D.Impulse);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ColorChangeTrigger"))
        {
            meshRenderer.material.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        }
    }
}
