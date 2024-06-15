using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController character;
    public Vector3 direction;
    public float gravity=9.8f*2f;
    public float jumpforce=8f;
    void Start()
    {
        
    }
    void Awake(){
        character=GetComponent<CharacterController>();
    }
    void OnEnable(){
        direction =  Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        direction += Vector3.down * gravity * Time.deltaTime;
        if(character.isGrounded){
            direction=Vector3.down;
            if(Input.GetButton("Jump")){
                direction = Vector3.up * jumpforce;
            }
        }
        character.Move(direction*Time.deltaTime);
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("obstacle")){
            GameManager.Instance.GameOver();
        }
    }
}
