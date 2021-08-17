using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFirework : MonoBehaviour
{
    public GameObject firework;
    public GameObject leftUpObj;
    public GameObject rightDownObj;
    private Vector2 leftUp;
    private Vector2 rightDown;
    private List<GameObject> fireworks;
    public int maxNum = 5;
    // Start is called before the first frame update
    void Start()
    {
        leftUp = new Vector2(leftUpObj.transform.position.x, leftUpObj.transform.position.y);
        rightDown = new Vector2(rightDownObj.transform.position.x, rightDownObj.transform.position.y);
        InvokeRepeating("generateFirework", 0, 0.5f);
        InvokeRepeating("destroyObj", 3, 0.5f);
        fireworks = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void generateFirework()
    {
        GameObject o = Instantiate(firework);
        float x = Random.Range(leftUp.x, rightDown.x);
        float y = Random.Range(rightDown.y,leftUp.y);
        //Debug.Log("x:"+x+",y:"+ y);
        o.transform.position = new Vector2(x,y);
        fireworks.Add(o);
        Debug.Log(fireworks.Count);
    }

    private void destroyObj()
    {
        GameObject o = fireworks[0];
        fireworks.RemoveAt(0);
        Destroy(o);
    }
}
