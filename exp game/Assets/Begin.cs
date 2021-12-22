using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Begin : MonoBehaviour {
    
    int myInt = 6;
    
    void Start() {
        print(myInt);
        myInt++;
        print(myInt);
        myInt += 2;
        print(myInt);
    }

}