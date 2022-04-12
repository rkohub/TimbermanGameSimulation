using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AxeScript : MonoBehaviour{
    // Start is called before the first frame update
    public GameObject Tree;
    private TreeBuilder TreeBuilder;
    public bool gameOver;

    public int score;
    public float elapsedTime;

    public Text scoreText;
    public Text timerText;

    //TODO

    void Start(){
        // System.out.println("TESTING");
        // Debug.Log("TESTING");
        this.gameObject.transform.position = new Vector3 (1,0,0);
        TreeBuilder = Tree.GetComponent<TreeBuilder>();
        // Debug.Log(TreeBuilder.testNum);
        gameOver = false;
        score = 0;
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update(){
        if(!gameOver){
            if (Input.GetKeyDown(KeyCode.F)||Input.GetKeyDown(KeyCode.D)){
                // Debug.Log("F");
                chopLeft();
            }
            if (Input.GetKeyDown(KeyCode.J)||Input.GetKeyDown(KeyCode.K)){
                // Debug.Log("J");
                chopRight();
            }
            if(TreeBuilder.tree[0] != 0 && this.gameObject.transform.position.x == Mathf.Sign(TreeBuilder.tree[0])){
                Debug.Log("GAME OVER");
                gameOver = true;
            }else{
                // Debug.Log("ALIVE");
            }
            if(score != 0){
                elapsedTime += Time.deltaTime;
            }

            scoreText.text = "Score: " + score;
            if(score < 100){
                timerText.text = "Time: " + Mathf.Round(elapsedTime * 100) / 100.0f;
            }
            // timerText.text = "Time: " + Mathf.Round(elapsedTime * 100) / 100.0f;
        }
    }

    void chopLeft(){
        if(TreeBuilder.tree[0] != 0 && Mathf.Sign(TreeBuilder.tree[0]) == -1){
            gameOver = true;
            Debug.Log("GAME OVER");
            this.gameObject.transform.position = new Vector3 (-1,0,0);
            return;
        }
        // Debug.Log("Left");
        this.gameObject.transform.position = new Vector3 (-1,0,0);
        TreeBuilder.shiftTree();
        score++;
    }

    void chopRight(){
        if(TreeBuilder.tree[0] != 0 && Mathf.Sign(TreeBuilder.tree[0]) == 1){
            gameOver = true;
            Debug.Log("GAME OVER");
            this.gameObject.transform.position = new Vector3 (1,0,0);
            return;
        }
        // Debug.Log("Right");
        this.gameObject.transform.position = new Vector3 (1,0,0);
        TreeBuilder.shiftTree();
        score++;
    }
}
