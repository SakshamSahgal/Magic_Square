using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Threading;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class text : MonoBehaviour
{
    public GameObject CreateButton;
    public GameObject PlusButton;
    public GameObject MinusButton;
    public bool credits_Active = false;
    public GameObject Credits;
    public Vector2 Startingpoint;
    public Text textelement2;
    public Text textelement1;
    public Text Sum;
    public int N = 3;
    public GameObject texttoinstantiate; //jisko instantiate krna h
    public GameObject [] cubearray;
    public Vector3 itslocation;
    public Vector2 BlockedPositions1;
    public Vector2 BlockedPositions2;
    public Vector2 BlockedPositions3;
    public Vector2 BlockedPositions4;
    public Vector2[] alreadyused;
    public float i;
    public float j;
    public int Countit = 0;
    int count = 1;
    public Vector3 camerapos;
    public GameObject MyCamera;
    public AudioSource Puksound;
    public AudioSource Deletesound;
    // List<int> size = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        //loop_completed = true;
        Initiliser();
    }
    // Update is called once per frame
    void Update()
    {

        //Initiliser();
        
        //  TextMesh textobject = GameObject.Find("block text(Clone)").GetComponent<TextMesh>();
        //  textobject.text = "new";
    }
 
    public void Initiliser() 
    {
        Startingpoint.x = (N + 1)/2;
        Startingpoint.y = N;

        BlockedPositions1.x = N + 1;
        BlockedPositions1.y = N + 1;

        BlockedPositions2.x = N + 1;
        BlockedPositions2.y = 0;

        BlockedPositions3.x = 0;
        BlockedPositions3.y = 0;

        BlockedPositions4.x = 0;
        BlockedPositions4.y = N+1;

        i = Startingpoint.x;
        j = Startingpoint.y;
        Countit = 0;
        count = 1;
        Array.Resize<GameObject>(ref cubearray, N * N);
        Array.Resize<Vector2>(ref alreadyused, N * N);
        
        camerapos.x = (N+1) / 2;
        camerapos.y = (N+1) / 2;
        camerapos.z = 2 - N;
        camerareset();
    }
    public void ArrayResetter() 
    {
        for (int a = 0; a < N*N; a++)
        {
            alreadyused[a].x = 0;
            alreadyused[a].y = 0;
        }
    }
  
    
        public void creditsload() 
    {
        if (credits_Active == true) 
        {
            credits_Active = false;
            Credits.SetActive(false);
        }
       else if (credits_Active == false)
        {
            credits_Active = true;
            Credits.SetActive(true);
        }

    }
    public void Deleteblocks() 
    {
        Deletesound.Play();
        for (int a = 0; a <N*N; a++)
        {
            GameObject clone = cubearray[a] as GameObject;
            Destroy(clone);
        }
    }

    public void Buttonfunction() 
    {
       
        Deleteblocks();
        N = N + 2;
        Countit = 0;
        textelement1.text = N.ToString();
        textelement2.text = N.ToString();
        UpdateArray();
        Initiliser();
        ArrayResetter();
        camerareset();
        CreateButton.SetActive(true);
    }

    public void Buttonfunction2()
    {
        
        if (N >= 3)
        {
            Deleteblocks();
            N = N - 2;
            Countit = 0;
            textelement1.text = N.ToString();
            textelement2.text = N.ToString();
            UpdateArray();
            Initiliser();
            ArrayResetter();
            camerareset();
            CreateButton.SetActive(true);
        }
       
    }
    public void UpdateArray() 
    {
        Array.Resize<Vector2>(ref alreadyused,N*N);
        Array.Resize<GameObject>(ref cubearray, N*N);
    }
    public void Logic() 
    {
        StartCoroutine("Displayer");
    }
    public void instantiator(float inputx, float inputy)
    {
        itslocation.x = inputx;
        itslocation.y = inputy;
        itslocation.z = 3;
        GameObject temp = Instantiate(texttoinstantiate, itslocation, transform.rotation) as GameObject;
        temp.GetComponent<TextMesh>().text = (count).ToString();
        cubearray[count - 1] = temp as GameObject;
        count++;
        // GameObject temp = Instantiate(texttoinstantiate, itslocation, transform.rotation).gameObject;
        //   arr[i] = temp;

        //  Instantiate(texttoinstantiate, itslocation, transform.rotation);
        // itslocation.x += 1;
    }

    public void camerareset() 
    {
        MyCamera.GetComponent<Transform>().position = camerapos;
    }

    IEnumerator Displayer()
    {
        CreateButton.SetActive(false);
        PlusButton.SetActive(false);
        MinusButton.SetActive(false);
            for (int b = 0; b < N * N; b++)
            {
                yield return new WaitForSeconds(0.2f);
                if (i == BlockedPositions1.x && j == BlockedPositions1.y)
                {
                    i = i - 1;
                    j = j - 2;
                    Debug.Log("blocked position detected");
                }
                if (i == BlockedPositions2.x && j == BlockedPositions2.y)
                {
                    i = i - 1;
                    j = j - 2;
                    Debug.Log("blocked position detected");
                }
                if (i == BlockedPositions3.x && j == BlockedPositions3.y)
                {
                    i = i - 1;
                    j = j - 2;
                    Debug.Log("blocked position detected");
                }
                if (i == BlockedPositions4.x && j == BlockedPositions4.y)
                {
                    i = i - 1;
                    j = j - 2;
                    Debug.Log("blocked position detected");
                }

                for (int a = 0; a < Countit; a++)
                {
                    Debug.Log("yes it entered");

                    if (i == alreadyused[a].x && j == alreadyused[a].y)
                    {
                        i = i - 1;
                        j = j - 2;
                        Debug.Log("already used detected");
                        break;
                    }
                }

                if (i > N)
                {
                    i = i - N;
                }

                if (j > N)
                {
                    j = j - N;
                }

                // Debug.Log(i);
                //  Debug.Log(j);
                alreadyused[Countit] = new Vector2(i, j);
                Puksound.Play();
                instantiator(i, j);
                i += 1;
                j += 1;
                //alreadyused = new Vector2 [] { new Vector2(i,j) };

                Countit++;
           
        }
            Sum.text = (((N * N * N) + N) / 2).ToString();
        PlusButton.SetActive(true);
        MinusButton.SetActive(true);
    }
        
    }
        

