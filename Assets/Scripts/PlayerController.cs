using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Touch touch;

    [Range(5,30)]
    [SerializeField] private int speed;

    private Rigidbody rgb;

    public int ForwardSpeed;
    // [SerializeField] private GameObject Camera;

    [SerializeField] private GameObject LimitForwed;
    [SerializeField] private GameObject LimitBack;

    [SerializeField] private GameObject[] Ýtems;

    [SerializeField] private CamerShake camerShake;
    [SerializeField] private UIManager uIManager;

    private bool fýrstTouchcontrol = false;
    private bool speedballforward = false;

    private void Start()
    {
        rgb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {    
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    if (fýrstTouchcontrol == false)
                    {
                        Variables.FirstTouch = 1;
                        uIManager.FirstTouchDedication();
                        fýrstTouchcontrol = true;
                    }
                }            
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    rgb.velocity = new Vector3(touch.deltaPosition.x * speed * Time.deltaTime,
                                         transform.position.y,
                                         touch.deltaPosition.y * speed * Time.deltaTime);
                    if (fýrstTouchcontrol == false)
                    {
                        Variables.FirstTouch = 1;
                        uIManager.FirstTouchDedication();
                        fýrstTouchcontrol = true;
                    }
                }            
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                rgb.velocity = Vector3.zero;
            }
            else if (touch.phase == TouchPhase.Stationary)
            {
                rgb.velocity = Vector3.zero;
            }
        }      
    }
    public void Update()
    {
        if (Variables.FirstTouch == 1 && speedballforward == false)
        {
            transform.position += new Vector3(0, 0, ForwardSpeed * Time.deltaTime);
            LimitForwed.transform.position += new Vector3(0, 0, ForwardSpeed * Time.deltaTime);
            LimitBack.transform.position += new Vector3(0, 0, ForwardSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision Other)
    {
        if (Other.gameObject.CompareTag("Enemy"))
        {
            uIManager.StartCoroutine("WhiteEffect");
            camerShake.CameraShakeCall();
            gameObject.transform.GetChild(0).gameObject.SetActive(false);

            foreach (GameObject item in Ýtems)
            {
                item.GetComponent<CapsuleCollider>().enabled = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
            }
            StartCoroutine(TimeScaleContorl());
        }     
    }

    public IEnumerator TimeScaleContorl()
    {
        speedballforward = true;
        yield return new WaitForSecondsRealtime(0.4f);
        Time.timeScale = 0.4f;
        yield return new WaitForSecondsRealtime(0.5f);
        uIManager.RestartButton();
        rgb.velocity = Vector3.zero;
    }
}
