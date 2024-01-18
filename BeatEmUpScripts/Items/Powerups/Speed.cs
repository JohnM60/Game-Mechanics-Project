using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : PowerUp{
    public float speedMulti = 1.50f;

    public override void Use(){
        if(pEnabled){
            GlobalState.Get().SetSpeed(GlobalState.Get().GetSpeed() * speedMulti);
        }else{
            GlobalState.Get().SetSpeed(GlobalState.Get().GetSpeed() / speedMulti);
        }
    }

}
