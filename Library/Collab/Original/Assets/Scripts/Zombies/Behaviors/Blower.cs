using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blower : MonoBehaviour {
    public int range = 5;
    public Transform target;
    public GameObject Blowup;
    private GameObject blowup;
    private GameObject[] ennemieslist;

    // Inherited Function(s)
    void Start() {
        ennemieslist = GameObject.FindGameObjectsWithTag("Zombie");
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update() {
        float playerdistance = Vector3.Distance(transform.position, target.transform.position);

        if (playerdistance < range) {
            blowup = (GameObject)Instantiate(Blowup, transform.position, Quaternion.Euler(0, 0, 0));
            for (int i = 0; i < ennemieslist.Length; i ++) {
                float _ennemidistance = Vector3.Distance(transform.position, ennemieslist[i].transform.position);

                if (_ennemidistance < range)
                    Destroy(ennemieslist[i]);
            }
            Destroy(gameObject);
        }
    }
}
