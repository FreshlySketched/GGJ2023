using UnityEngine;

public class Shield : MonoBehaviour
{
    public int BlockValue { get; private set; }    

    private void Start() {
        BlockValue = 100;        
    }

    private void ReduceShield(int attackDmg)
    {
        BlockValue -= attackDmg;
    }

    private void ShrinkShieldSprite()
    {
        
    }




}
