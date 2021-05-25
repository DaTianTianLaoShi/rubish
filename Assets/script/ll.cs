using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ll : MonoBehaviour
{
    
    string str = null;
    int a = 0;
    public Type t;
    // Start is called before the first frame update
    void Start()
    {
        string a =File.ReadAllText (Application.dataPath);
        Debug.Log(a);
        // transform.position;
        //Input.GetKeyDown(KeyCode.A);
    }

    // Update is called once per frame
    void Update() 
    {
        //if (Input.inputString.Length > 0) 
        //{
            
        //    Debug.Log(Input.inputString.Length);
        //    str = Input.inputString;
        //    //Debug.Log(str);
        //    try {  a = int.Parse(str); } 
        //    catch{  a = -1; }
        //    if (a == -1)
        //    {
        //        Debug.Log("类型转换失败");
        //    } else if ( a>=0||a<=9) 
        //    {
        //        Debug.Log(a);
        //        Debug.Log("类型转换成功");
        //    }
          GameObject obj = new GameObject();
        obj.transform.localScale = new Vector3();
        //    Slider slider = this.GetComponent<Slider>();
        //    Transform ts = GetComponent<Transform>();
        //    ts= ts.transform.Find("");
        //    ts.gameObject.SetActive(false);
        //    // List<GameObject> li = new List<GameObject>();
        //    //Text

        //    //cam. WorldToScreenPoint();
        //    Vector3 v1= Input.mousePosition;
        //    bool B_a = Input.GetMouseButtonDown(0);
        //    B_a = Input.GetMouseButton(1);
        //    Vector3 c;
        //    c = Vector3.left;
        //     c=ts.transform.forward;
            Debug.Log(Vector3.Angle(Vector3.up,Vector3.down));
           // Dropdown dp = new Dropdown();
      // Transform t = Transform();
       // t.position.Scale(new Vector3(0,0,0));
            
            //新生成一个物体，
            //执行的时候，asldjlpasjdplas
            
        }
    }
