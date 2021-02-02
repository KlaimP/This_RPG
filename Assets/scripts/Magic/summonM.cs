using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summonM : MonoBehaviour
{
    public float offset;
    public GameObject buttons;
    public GameObject magic;
    public Transform ShotPoint;
    public Transform player;
    public float x,y, x1,y1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        x = ShotPoint.transform.localPosition.x;
        y = ShotPoint.transform.localPosition.y;

        if (Input.GetKey(KeyCode.V))
        {
            buttons.SetActive(true);
        }else{
            buttons.SetActive(false);
        }
    }

    public void MagicSummon_Click()
    {
        if(y<0 && x==0)
        {
        ShotPoint.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
        else if(y>0 && x==0)
        {
        ShotPoint.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (x<0 && y==0)
        {
        ShotPoint.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        else if (x>0 && y==0)
        {
        ShotPoint.rotation = Quaternion.Euler(0f, 0f, 270f);
        }
        Instantiate(magic, ShotPoint.position, ShotPoint.rotation);
    }
}
