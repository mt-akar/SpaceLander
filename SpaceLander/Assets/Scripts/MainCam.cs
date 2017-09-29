using UnityEngine;

public class MainCam : MonoBehaviour
{
    public GameObject background;
    public GameObject ufo;
    public GameObject plat;
    private float asp = 16f / 9;

    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void Awake()
    {
        Camera.main.aspect = asp;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        //transform.position = new Vector3(ufo.transform.position.x, ufo.transform.position.y, transform.position.z);
        GetComponent<Camera>().orthographicSize = 1.5f;
        /*
        transform.position = new Vector3((plat.transform.position.x + ufo.transform.position.x) / 2, (plat.transform.position.y + ufo.transform.position.y) / 2, transform.position.z);
        GetComponent<Camera>().orthographicSize = Mathf.Max(Mathf.Abs(plat.transform.position.y - ufo.transform.position.y) * .6f,
            Mathf.Abs(plat.transform.position.x - ufo.transform.position.x) * .3375f, 1.25f);
            */

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        background.transform.position = new Vector3(transform.position.x / 2, transform.position.y / 2, 10);
    }
}

