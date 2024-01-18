public abstract class PowerUp : AbstractItem{

    public bool pEnabled = false;

    public void Enable(){
        pEnabled = true;
        Use();
    }
    public void Disable(){
        pEnabled = false;
        Use();
    }

}