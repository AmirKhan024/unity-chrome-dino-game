using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    public float initailGameSpeed=5f;
    public float gameSpeedIncrease=0.1f;

    public Player player;
    public Spawner spawner;
    public float gameSpeed {get; private set;}
    public TextMeshProUGUI gameOverText;
    public Button retryButton;
    private void Awake(){
        if(Instance == null){
            Instance = this;
        }else{
            DestroyImmediate(gameObject);
        }
    }
    private void OnDestroy(){
        if(Instance == this){
            Instance=null;
        }
    }

    public void GameOver(){
        gameSpeed=0f;
        enabled=false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);

        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        player=FindObjectOfType<Player>();
        spawner=FindObjectOfType<Spawner>();
        NewGame();
    }
    public void NewGame(){

        Obstacle[] obstacles=FindObjectsOfType<Obstacle>();
        foreach( var obstacle in obstacles){
            Destroy(obstacle.gameObject);
        }

        gameSpeed=initailGameSpeed;
        enabled=true;
        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);

        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        gameSpeed += gameSpeedIncrease*Time.deltaTime;
    }
}
