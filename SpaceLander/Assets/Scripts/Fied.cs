using UnityEngine;

public class Fied : MonoBehaviour
{
    public GameObject fan;
    
    void OnTriggerStay2D(Collider2D other)
    {
        float width = GetComponent<BoxCollider2D>().size.x;
        GetComponent<AreaEffector2D>().forceMagnitude = fan.transform.position.x - other.transform.position.x - width < 0 ?
            fan.transform.position.x - other.transform.position.x - width : 0;
    }
}