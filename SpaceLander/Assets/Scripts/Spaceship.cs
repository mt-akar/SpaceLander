using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spaceship : MonoBehaviour
{

    public static float thrustForce = 1.25f;
    public GameObject el, er;
    public Text mainText;
    public GameObject tex;
    public GameObject plat;


    private ParticleSystem particleLeft, particleRight;

    private Rigidbody2D rig;
    private bool gameEnded = false;
    private bool rescuePowerUsed = false;

    private void Awake()
    {
        Time.timeScale = 1f;
        mainText.text = "";
        rig = GetComponent<Rigidbody2D>();
        particleLeft = el.GetComponent<ParticleSystem>();
        particleRight = er.GetComponent<ParticleSystem>();
        particleLeft.Stop();
        particleRight.Stop();
    }

    void Update()
    {
        if (Input.anyKeyDown && gameEnded)
        {
            SceneManager.LoadScene("First");
        }
        if (Input.GetKeyDown(KeyCode.S) && !rescuePowerUsed)
        {
            rescuePowerUsed = !rescuePowerUsed;
            transform.Rotate(new Vector3(0, 0, -transform.rotation.eulerAngles.z));
            rig.velocity = new Vector2(0, 0);
            rig.angularVelocity = 0;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rig.AddRelativeForce(Vector3.up * thrustForce);
            rig.AddTorque(-0.025f, ForceMode2D.Force);
            particleLeft.Emit(3);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rig.AddRelativeForce(Vector3.up * thrustForce);
            rig.AddTorque(0.025f, ForceMode2D.Force);
            particleRight.Emit(3);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.layer == 8)
        {
            mainText.text = "Game Over";
            finish(false);
        }
        else if (col.gameObject.layer == 9 && (transform.rotation.eulerAngles.z < 45 || transform.rotation.eulerAngles.z > 315))
        {
            mainText.text = "Good Job";
            finish(true);
        }
        else if (col.gameObject.layer == 9)
        {
            mainText.text = "Not Good Enough";
            finish(false);
        }
    }

    public void finish(bool won)
    {
        tex.SetActive(true);
        gameEnded = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        if (won)
        {
            transform.Rotate(new Vector3(0, 0, -transform.rotation.eulerAngles.z));
            rig.velocity = new Vector2(0, 0);
            rig.angularVelocity = 0;
            //transform.Translate(plat.transform.position.x - transform.position.x, 0, 0);
            transform.position = new Vector2(plat.transform.position.x, transform.position.y);
        }
    }

}
