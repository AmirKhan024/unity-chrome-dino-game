using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSprite : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;
    public int frame;
    
    void Awake(){
        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    void OnEnable(){
        Invoke(nameof(Animate),0f);
    }
    void OnDisable(){
        CancelInvoke();
    }
    void Start()
    {
        
    }

    void Animate(){
        frame++;
        if(frame>=sprites.Length){
            frame=0;
        }
        spriteRenderer.sprite=sprites[frame];

        Invoke(nameof(Animate), 1f/GameManager.Instance.gameSpeed);
    }
    void Update()
    {
        
    }
}
