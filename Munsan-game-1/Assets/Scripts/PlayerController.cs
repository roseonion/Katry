using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public GameManager gManager;
    public Animator anim;

    private float v, h, speed = 3.0F, RunSpeed = 5f, rotateSpeed = 3.0F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", v);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = RunSpeed;
            anim.SetBool("Run", true);
        }
        else
        {
            speed = 3f;
            anim.SetBool("Run", false);
        }

        CharacterController controller = GetComponent<CharacterController>();
        transform.Rotate(0, h * rotateSpeed, 0);

        /*
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * v;
        controller.SimpleMove(forward * curSpeed);
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Key")
        {
            gManager.keyCountPlayer += 1;
        }
        if(other.tag == "door")
        {
            if(gManager.keyCountPlayer >= 4)
            {
                gManager.EndScreen = true;
            }
            else
            {
                gManager.UiText.text = "아직 열쇠" + (4 - gManager.keyCountPlayer) + "개가 부족 합니다";
            }
        }
    }
}
