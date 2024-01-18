using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : PowerUp{

    void Update(){
        Ticket.isMagnet = pEnabled;
    }

    public override void Use(){}
}
