using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarlingScript : MonoBehaviour
{
    public GameObject starling;
    public int row;
    public int number;
    private int count;
    private GameObject[] starlings;
    public GameObject parentStarling;
    private float speed;
    // private Vector3 direction;
    // private float x_speed;
    // private float y_speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1.0f,5.0f) * Time.deltaTime;
        count = 0;
        int birthCount = 1;
        if(number == row * 2 - 2 || number == row * 2 - 1){birthCount = 2;};

        if(row <= 20){
            while(count < birthCount){
                float x = -2.0f + 2.0f * count * 2;
                Vector3 position = new Vector3(transform.position.x + x,transform.position.y - 2.0f,0f);
                GameObject newStarling = Instantiate(starling,position,transform.rotation);
                newStarling.GetComponent<StarlingScript>().row = row + 1;
                newStarling.GetComponent<StarlingScript>().number = number + count * 2;
                newStarling.GetComponent<StarlingScript>().parentStarling = gameObject;
                count++;
            }
        }

        // StartCoroutine("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Move",0.5f);
    }

    private void Move(){
        transform.position = Vector3.MoveTowards(transform.position, parentStarling.transform.position,speed);
    }

    // IEnumerator Move(){
    //     while(true){
    //         transform.position = Vector3.MoveTowards(transform.position, parentStarling.transform.position,speed);
    //         yield return new WaitForSeconds(1.0f);
    //     }
    // }
}
