using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    
    private void Awake(){
        meshRenderer=GetComponent<MeshRenderer>();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = GameManager.Instance.gameSpeed/transform.localScale.x;
        meshRenderer.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
    }
}
