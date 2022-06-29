using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public Animator anim;

    public Vector3 moveDirection;

    public float moveSpeed = 10f;   
    public float rotateSpeed = 10;
    private float moveX;
    private float moveY;

    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        MovePlayer();           
    }
    private void LateUpdate()
    {
        RotatePlayer();
    }
    public void SetString()
    {
        Debug.Log("Event Called");
       // GetComponent<Animator>().enabled = false;
    }
    public void MovePlayer()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxis("Vertical");
        if (moveY < 0)
        {
            moveSpeed = 2f;
            SetRunBackward();
        }
        else if (moveY > 0)
        {            
            moveSpeed += 0.06f;
            if(moveSpeed<4)
            {
                SetWalk();
            }
            else
            {
                moveSpeed = 6f;
                SetRun();
            }           
        }
        else
        {
            moveSpeed = moveY;
            anim.SetFloat("Speed", 0f,0.3f,Time.deltaTime);           
        }
        transform.position += transform.forward * Time.deltaTime * moveSpeed * moveY;     
    }
    public void RotatePlayer()
    {
        if (moveX>0)
        {           
            Vector3 toRotate = new Vector3(0, rotateSpeed*Time.deltaTime, 0);
            transform.Rotate(toRotate);
        }
        else if(moveX<0)
        {
            Vector3 toRotate = new Vector3(0, -rotateSpeed*Time.deltaTime, 0);
            transform.Rotate(toRotate);
        }
    }   
    public void SetWalk()
    {      
        anim.SetFloat("Speed",0.5f);
    }
    public void SetRun()
    {
        anim.SetFloat("Speed", 1f,0.5f,Time.deltaTime);
    }
    public void SetRunBackward()
    {
        anim.SetFloat("Speed", -0.2f);
    }
}
