using System.Collections;
using UnityEngine;


public class Shield : MonoBehaviour
{
    public int _blockVal;  
    private Vector3 _shieldSpriteSize;
    [SerializeField] private float _shieldRegenCooldown = 2.5f; // it takes 2.5 seconds for the regeneration to start
    private bool _beenHit = false;
    private bool _regenTick = true;
    [SerializeField]private int _blockRegenAmount = 5; //effects size regen directly. 10% of this value.

    private Coroutine _currentlyRunning;
    private Vector3 _originalShieldSize;

    private void Awake() {
        _shieldSpriteSize = GetComponentInChildren<ShieldObj>().gameObject.transform.localScale;
    }

    private void Start() {
        _blockVal = 100;        
        _regenTick = true;
        _originalShieldSize = GetComponentInChildren<ShieldObj>().gameObject.transform.localScale;          
    }

    private void LateUpdate() {        

        if(_blockVal < 100 && !_beenHit && _regenTick)
        {
            _blockVal += _blockRegenAmount;
            float _sizeRegenAmount = _blockRegenAmount/100f;
            _shieldSpriteSize += new Vector3 (_sizeRegenAmount, _sizeRegenAmount, _sizeRegenAmount);
            _regenTick = false;
            StartCoroutine(RegenTickTimer());            
        }
        else if(_blockVal >= 100 || _shieldSpriteSize.x > _originalShieldSize.x)
        {
            _blockVal = 100;
            _shieldSpriteSize = _originalShieldSize;
        }
        else if(_blockVal <= 0 && _beenHit)
        {
            _shieldSpriteSize = Vector3.zero;
            _blockVal = 0;
        }
        GetComponentInChildren<ShieldObj>().gameObject.transform.localScale = _shieldSpriteSize;
    }

    private void TakeHit(int attackDmg)
    {
        _blockVal -= attackDmg;
        float reductionValue = attackDmg/100f * _originalShieldSize.x;
        ReduceShieldSize(reductionValue);       
    }

    private void ReduceShieldSize(float reductionValue)
    {
        if(_currentlyRunning != null)
            {StopCoroutine(_currentlyRunning);}
            
        _shieldSpriteSize.x -= reductionValue;
        _shieldSpriteSize.y -= reductionValue;        
        _currentlyRunning = StartCoroutine(RegenCooldown());                  
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Enemy"))
        {
            _beenHit = true;
            int dmg = other.gameObject.GetComponent<DamageDealer>().damage;
            TakeHit(dmg);
        }        
    }

    IEnumerator RegenCooldown()
    {
        yield return new WaitForSeconds(_shieldRegenCooldown);
        _beenHit = false;
    }

    IEnumerator RegenTickTimer()
    {
        yield return new WaitForSeconds(1);
        _regenTick = true;
    }
}