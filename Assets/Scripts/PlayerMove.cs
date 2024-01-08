using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 checkpoint;
    Rigidbody rb;    
    public float speed = 7;
    public bool canJump = true;
    
    public bool isPlayer1;
    // Start is called before the first frame update
    void Start()
    {
        
        Physics.gravity *= 3;
        checkpoint = transform.position;
        rb = GetComponent<Rigidbody>();
    }
    
    float hi;
    float vi;
    // Update is called once per frame
    void Update(){
        if(isPlayer1 && Input.GetKeyDown(KeyCode.Space) && canJump){
            canJump = false;
            rb.AddForce(Vector3.up * 15, ForceMode.Impulse);
        }
        if(!isPlayer1 && Input.GetKeyDown(KeyCode.RightControl) && canJump){
            canJump = false;
            rb.AddForce(Vector3.up * 15, ForceMode.Impulse);
        }
        if(isPlayer1){
            if(Input.GetKey(KeyCode.W)){
                hi = -1;
            }
            else if(Input.GetKey(KeyCode.S)){
                hi = 1;
            }
            else{
                hi = 0;
            }
        
        }else{
            if(Input.GetKey(KeyCode.UpArrow)){
                hi = -1;
            }
            else if(Input.GetKey(KeyCode.DownArrow)){
                hi = 1;
            }
            else{
                hi = 0;
            }
        }

        if(isPlayer1){
            if(Input.GetKey(KeyCode.D)){
                vi = 1;
            }
            else if(Input.GetKey(KeyCode.A)){
                vi = -1;
            }
            else{
                vi = 0;
            }
        
        }else{
            if(Input.GetKey(KeyCode.RightArrow)){
                vi = 1;
            }
            else if(Input.GetKey(KeyCode.LeftArrow)){
                vi = -1;
            }
            else{
                vi = 0;
            }
        }
    }
    void FixedUpdate()
    {
        rb.AddForce(transform.right * hi * speed);
        rb.AddForce(transform.forward * vi * speed);
        if(transform.position.y < -4f){
            transform.position = checkpoint;
        }
    }

    public void SetCheckpoint(Vector3 cp){
        checkpoint = cp;
    }

    private void OnCollisionEnter(Collision other) {
        if(!other.gameObject.CompareTag("Wall")){
            canJump = true;
        }
        if(other.gameObject.CompareTag("Respawn")){
            SetCheckpoint(other.gameObject.transform.position + new Vector3(0,2,0));
            Debug.Log("checkpoint set");
        }
        if(other.gameObject.CompareTag("Finish")){
            if(isPlayer1)
                Debug.Log("Player 1 wins");
            else
                Debug.Log("Player 2 wins");

            Time.timeScale = 0; // Para o tempo
            
        }
    }
}
