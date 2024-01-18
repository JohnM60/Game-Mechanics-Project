public class Tank : PowerUp{
    public float healthMultiplier = 1.75f;

    public override void Use(){

        float oldMaxHealth = GlobalState.Get().GetMaxHealth();
        float newMaxHealth = GlobalState.Get().GetMaxHealth() * healthMultiplier;
        if(pEnabled){
            GlobalState.Get().SetMaxHealth(newMaxHealth);
            GlobalState.Get().SetPlayerHealth(GlobalState.Get().GetPlayerHealth() + (newMaxHealth-oldMaxHealth));

        }else{
            GlobalState.Get().SetSpeed(GlobalState.Get().GetSpeed() / healthMultiplier);

            if(GlobalState.Get().GetPlayerHealth() > GlobalState.Get().GetMaxHealth()){
                GlobalState.Get().SetPlayerHealth(GlobalState.Get().GetMaxHealth());
            }
        }
    }

}