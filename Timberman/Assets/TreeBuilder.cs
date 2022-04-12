using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBuilder : MonoBehaviour{
    // Start is called before the first frame update

    public GameObject Trunk;
    public GameObject Branch;

    public int newestL;
    public int newestR;

    // public int testNum = 3423423;

    public int[] tree = new int[10];

    void Start(){
        newestL = 0;
        newestR = 0;
        tree[0] = 0;
        tree[1] = 0;
        tree[2] = 0;
        tree[3] = -1;
        for(int i=4; i<10; i++){

            newestR--;
            newestL--;
            if(tree[i-1] != 0){
                tree[i] = 0;
            }else if(newestL < 2){
                tree[i] = -1;
                newestL = 9;
            }else if(newestR < 2){
                tree[i] = 1;
                newestR = 9;
            }else{
                tree[i] = Random.Range(-3,4);
                if(tree[i]<0){
                    newestL = 9;
                }
                if(tree[i]>0){
                    newestR = 9;
                }
            }
        }
        /*
        for(int i=0; i<10; i++){
            Debug.Log(tree[i]);
        }
        //*/
        drawTree();
    }

    // Update is called once per frame
    void Update(){
        
        if (Input.GetKeyDown(KeyCode.Q)){
            shiftTree();
        }
        // Debug.Log(this.gameObject.transform.childCount > 0);

        //Debug.Log("NewestL: " + newestL);
        //Debug.Log("NewestR: " + newestR);
    }

    void drawTree(){
        // Debug.Log("DRAW");
        // while(this.gameObject.transform.childCount > 0){
        if(this.gameObject.transform.childCount > 0){
            // Debug.Log("LOOP");
            for(int i=0; i<this.gameObject.transform.childCount; i++){
                // Debug.Log(this.gameObject.transform.childCount > 0);
                // this.gameObject.transform.GetChild(0).gameObject.destroy;
                // Debug.Log(this.gameObject.transform.GetChild(i).gameObject);
                Destroy(this.gameObject.transform.GetChild(i).gameObject);
            }
        }
        //*
        for(int i=0; i < 10; i++){
            Instantiate(Trunk,new Vector3 (0,i,0), Quaternion.identity, this.gameObject.transform);
            if(tree[i] != 0){
                Instantiate(Branch, new Vector3 (Mathf.Sign(tree[i]),i,0), Quaternion.identity, this.gameObject.transform);
            }
            
        }
        //*/
    }

    public void shiftTree(){
        // Debug.Log("SHIFT");
        for(int i=0; i < 9; i++){
            tree[i] = tree[i+1];
        }
        newestR--;
        newestL--;
        if(tree[8] != 0){
                tree[9] = 0;
        }else if(newestL < 2){
            tree[9] = -1;
            newestL = 9;
        }else if(newestR < 2){
            tree[9] = 1;
            newestR = 9;
        }else{
            tree[9] = Random.Range(-3,4);
            if(tree[9]<0){
                newestL = 9;
            }
            if(tree[9]>0){
                newestR = 9;
            }
        }
        drawTree();
    }
}
