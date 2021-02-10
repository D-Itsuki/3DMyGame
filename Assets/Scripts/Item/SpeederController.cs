using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class SpeederController : ItemBase
{
    [SerializeField] Vector3 itemBox;
    FPSController a;

    public override void Use()
    {
        Debug.Log("Item Use");
        a.speedUp();
        a.items.Remove(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.transform.position = itemBox;
            a =  other.GetComponent<FPSController>();
            a.items.Add(this);
            Debug.Log("Item Added");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
