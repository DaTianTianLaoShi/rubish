using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using java.lang;

public class t1 : MonoBehaviour
{
    //StringBuffer sb;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject gm = new GameObject();
        CharacterController ss = gm.GetComponent<CharacterController>();
        float vectorx = Input.GetAxis("Horizontal");
        float vectory = Input.GetAxis("Vertical");
        vectorx = 0.1f;
        Vector3 v3 = new Vector3(vectorx, vectory, 0);
        //ss.Move(v3);
        //transform.localScale;
        RectTransform rect = new RectTransform();
        //v3= rect.transform.rotation;
        Quaternion quaternion = new Quaternion();
        quaternion = rect.rotation;
    }
}
