using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawline : MonoBehaviour
{
   
        public Texture2D brush;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {  //点击鼠标 移动鼠标 开始涂色
                Ray lRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit lHit;
                Vector3 vector2 = new Vector3(0, 0, 0);
                if (Physics.Raycast(lRay, out lHit, 100f))
                {
                    //MeshCollider meshCollider = lHit.transform.GetComponent<MeshCollider>();
                    MeshRenderer lRender = lHit.transform.GetComponent<MeshRenderer>();
                    if (lRender)
                    {
                        Texture2D lTexture = lRender.sharedMaterial.mainTexture as Texture2D;
                       // Texture2D lTexture = lRender.material.mainTexture as Texture2D;
                        Vector2 pixelUV = lHit.textureCoord;
                        pixelUV.x *= lTexture.width;
                        pixelUV.y *= lTexture.height;//得到射线点在2d纹理图片上的坐标
                        Debug.Log(pixelUV);
                        Draw(pixelUV, lTexture);
                        Debug.Log("检测到物体");
                    }
                    else
                    {
                        SkinnedMeshRenderer render = lHit.transform.GetComponent<SkinnedMeshRenderer>();
                        Texture2D lTexture = render.sharedMaterial.mainTexture as Texture2D;
                        Vector2 pixelUV = lHit.textureCoord;
                        pixelUV.x *= lTexture.width;
                        pixelUV.y *= lTexture.height;
                        Draw(pixelUV, lTexture);
                    
                    }

                }
            }

        }
        public void Draw(Vector2 pPoint, Texture2D pTexture)
        {


            Rect lRect = new Rect(0, 0, pTexture.width, pTexture.height);
            pPoint -= new Vector2(brush.width / 2, brush.height / 2);
            Debug.Log(pPoint.ToString());
            int lX = Mathf.FloorToInt(pPoint.x);
            int lY = Mathf.FloorToInt(pPoint.y);
            for (int i = 0; i < brush.width; i++)
            {   //Brush 是画笔的纹理 （Texture2D）
                for (int j = 0; j < brush.height; j++)
                {
                    Vector2 lPosition = new Vector2(lX + i, lY + j);
                    if (lRect.Contains(lPosition) && brush.GetPixel(i, j).a > 0.8f)
                    {
                        pTexture.SetPixel(lX + i, lY + j, Color.red);
                    }
                }
            }
            pTexture.Apply();
        }
}

