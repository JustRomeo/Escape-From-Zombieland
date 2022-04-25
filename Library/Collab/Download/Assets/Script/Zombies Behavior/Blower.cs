using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blower : MonoBehaviour {
    public int range = 5;
    public Transform target;
    public GameObject Blowup;
    private GameObject blowup;
    private GameObject[] ennemieslist;

    // Lib Function(s)
    float myAbs(float a) {return a > 0 ? a : -1 * a;}

    // Inherited Function(s)
    void Start() {
        ennemieslist = GameObject.FindGameObjectsWithTag("Zombie");
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update() {
        if (myAbs(transform.position.x - target.position.x) < range && myAbs(transform.position.y - target.position.y) < range) {
            blowup = (GameObject)Instantiate(Blowup, transform.position, Quaternion.Euler(0, 0, 0));
            for (int i = 0; i < ennemieslist.Length; i ++)
                if (myAbs(transform.position.x - ennemieslist[i].transform.position.x) < range && myAbs(transform.position.y - ennemieslist[i].transform.position.y) < range)
                    Destroy(ennemieslist[i]);
            Destroy(gameObject);
        }
    }
}
