using UnityEngine;
using TMPro;
using System.Collections;
public class PlayerMove : MonoBehaviour
{
    Vector3 checkpoint;
    Rigidbody rb;    
    public float speed = 7;
    public float speedBoost_1 = 1;
    public float speedBoost_2 = 1;
    public float jumpBoost_1 = 1;
    public float jumpBoost_2 = 1;
    public bool canJump = true;
    public GameObject winnerend;
    public TextMeshProUGUI winner;

    public PlayerMove player1;
    public PlayerMove player2;

    public bool isPlayer1;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1").GetComponent<PlayerMove>();
        Physics.gravity = new Vector3(0, -90, 0);
        checkpoint = transform.position;
        rb = GetComponent<Rigidbody>();

        try{
            player2 = GameObject.Find("Player2").GetComponent<PlayerMove>();
        }catch{
            Debug.Log("No Player 2");
        }
    }
    
    float hi;
    float vi;
    // Update is called once per frame
    void Update(){
        if(isPlayer1 && Input.GetKeyDown(KeyCode.Space) && canJump){
            canJump = false;
            rb.AddForce(Vector3.up * 15 * jumpBoost_1, ForceMode.Impulse);
        }
        if(!isPlayer1 && Input.GetKeyDown(KeyCode.RightControl) && canJump){
            canJump = false;
            rb.AddForce(Vector3.up * 15 * jumpBoost_2, ForceMode.Impulse);
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
        if(isPlayer1){
            rb.AddForce(transform.right * hi * speed * speedBoost_1);
            rb.AddForce(transform.forward * vi * speed * speedBoost_1);
            if(transform.position.y < -4f){
                transform.position = checkpoint;
            }
        }else{
            rb.AddForce(transform.right * hi * speed * speedBoost_2);
            rb.AddForce(transform.forward * vi * speed * speedBoost_2);
            if(transform.position.y < -4f){
                transform.position = checkpoint;
            }
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
            {
                winner.text = "Player 1 wins!";
                winnerend.SetActive(true);
            }
            else
            {
                winner.text = "Player 2 wins!";
                winnerend.SetActive(true);
            }

            Time.timeScale = 0; // Para o tempo
            
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Speed")){
            StartCoroutine(speedBoost());
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("JumpBoost")){
            StartCoroutine(jumpBoost());
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Stun")){
            StartCoroutine(stun());
            Destroy(other.gameObject);
        }
    }

    IEnumerator speedBoost(){
        if(isPlayer1){
            speedBoost_1 = 2;
            yield return new WaitForSeconds(5);
            speedBoost_1 = 1;
        }else{
            speedBoost_2 = 2;
            yield return new WaitForSeconds(5);
            speedBoost_2 = 1;
        }
    }

    IEnumerator jumpBoost(){
        if(isPlayer1){
            jumpBoost_1 = 4;
            yield return new WaitForSeconds(5);
            jumpBoost_1 = 1;
        }else{
            jumpBoost_2 = 4;
            yield return new WaitForSeconds(5);
            jumpBoost_2 = 1;
        }
    }

    IEnumerator stun(){
        if(isPlayer1){
            player2.speedBoost_2 = 0;
            yield return new WaitForSeconds(3);
            player2.speedBoost_2 = 1;
        }else{
            player1.speedBoost_1 = 0;
            yield return new WaitForSeconds(3);
            player1.speedBoost_1 = 1;
        }
    }
}
