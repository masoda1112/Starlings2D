using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStarlingScript : MonoBehaviour
{
    public GameObject starling;
    private Vector3 direction;
    private float x_speed;
    private float y_speed;
    public int row;
    public int number;
    private int count;
    
    // Start is called before the first frame update
    void Start()
    {
        number = 1;
        row = 1;
        count = 0;
        while(count < 3){
            float x = -2.0f + 2.0f * (float)count;
            Vector3 position = new Vector3(transform.position.x + x, transform.position.y + -1.0f, 0f);
            GameObject newStarling = Instantiate(starling, position, transform.rotation);
            newStarling.GetComponent<StarlingScript>().row = row + 1;
            newStarling.GetComponent<StarlingScript>().number = count + 1;
            newStarling.GetComponent<StarlingScript>().parentStarling = gameObject;
            count++;
        }
        StartCoroutine("Move");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction;
    }

    IEnumerator Move(){
        while(true){
            int x_plusMinus = 1;
            int y_plusMinus = 1;
            int x_random = Random.Range(0,2);
            int y_random = Random.Range(0,2);
            if(x_random == 0) x_plusMinus = -1;
            if(y_random == 0) y_plusMinus = -1;
            x_speed = (float)x_plusMinus * Random.Range(10.0f,15.0f) * Time.deltaTime;
            y_speed = (float)y_plusMinus * Random.Range(10.0f,15.0f) * Time.deltaTime;
            direction = new Vector3(x_speed,y_speed,0f);
            yield return new WaitForSeconds(3);
        }
    }
}
