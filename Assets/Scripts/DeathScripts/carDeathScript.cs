using UnityEngine;

public class carDeathScript : DeathScript
{
    public override void killMe(){
        Time.timeScale = 0;
    }
}
