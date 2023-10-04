using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scripts : MonoBehaviour
{

    private Rigidbody rb;
    public float hiz=1.5f;
    public Text can, sure,oyunSonuc;
    int canSayaci = 3;
    float zamanSayaci = 15;
    bool oyunDevam = true;
    public Button btn;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunDevam)
        {
            zamanSayaci -= Time.deltaTime;
            sure.text = (int)zamanSayaci + "";
        }
        if(zamanSayaci < 0)
        {
            oyunDevam = false;
            oyunSonuc.text = "Süreniz Bitti";
            oyunSonuc.color = Color.red;
            btn.gameObject.SetActive(true);
        }
        
    }


    void FixedUpdate()
    {
        if (oyunDevam) {
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        Vector3 kuvvet = new Vector3(yatay, 0, dikey);
        rb.AddForce(kuvvet*hiz*10);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    void OnCollisionEnter(Collision cls)
    {
        string objismi = cls.gameObject.name;
        if(objismi == "bitis")
        {
            Debug.Log("Oyun Tamamlandi");
            oyunSonuc.text = "Oyun Tamamlandi";
            oyunSonuc.color = Color.green;
            oyunDevam = false;
            btn.gameObject.SetActive(true);
        }else if(objismi != "genelZemin" && objismi != "labirentZemin")
        {
            canSayaci--;
            can.text = canSayaci.ToString();           
        }

        if (canSayaci <= 0)
        {
            oyunDevam = false;
            oyunSonuc.text = "Oyun Tamamlanamadý";
            oyunSonuc.color = Color.red;
            btn.gameObject.SetActive(true);
        }


    }

}
