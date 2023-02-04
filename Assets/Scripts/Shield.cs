using System.Collections;
using UnityEngine;


public class Shield : MonoBehaviour
{
    public float m_blockVal;  
    private Vector3 _shieldSpriteSize;
    [SerializeField] private float _shieldRegenCooldown = 2.5f; // it takes 2.5 seconds for the regeneration to start
    private bool _beenHit = false;
    private bool _regenTick = true;
    
    public float m_blockRegenAmount = 1f; //effects size regen directly. 10% of this value.

    private Coroutine _currentlyRunning;
    private Vector3 _originalShieldSize;

    [SerializeField]
    private bool m_ShieldPress = false;

    public SpriteRenderer shield;
    [SerializeField]
    private GameObject m_shield;
    private void Awake() {
        _shieldSpriteSize = m_shield.transform.localScale;
    }

    private void Start()
    {
        m_blockVal = 300;
        _regenTick = true;
        _originalShieldSize = m_shield.transform.localScale;
    }
        private void Update()
    {
        if (m_ShieldPress)
            shield.enabled = true;
        else
            shield.enabled = false;


    }


    private void LateUpdate() {        

        if(m_blockVal < 300 && !_beenHit && _regenTick)
        {
            m_blockVal += m_blockRegenAmount / 100f;
            float _sizeRegenAmount = m_blockRegenAmount / 100f;
            _shieldSpriteSize += new Vector3 (_sizeRegenAmount, _sizeRegenAmount, _sizeRegenAmount);
            _regenTick = false;
            StartCoroutine(RegenTickTimer());            
        }
        else if(m_blockVal >= 300 || _shieldSpriteSize.x > _originalShieldSize.x)
        {
            m_blockVal = 300;
            _shieldSpriteSize = _originalShieldSize;
        }
        else if(m_blockVal <= 0 && _beenHit)
        {
            _shieldSpriteSize = Vector3.zero;
            m_blockVal = 0;
        }
        GetComponentInChildren<ShieldObj>().gameObject.transform.localScale = _shieldSpriteSize;
    }

    private void TakeHit(int attackDmg)
    {
        m_blockVal -= attackDmg;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.gameObject.CompareTag("Enemy") && m_ShieldPress)
        {
            _beenHit = true;
            int dmg = collision.gameObject.GetComponent<DamageDealer>().damage;
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
        yield return new WaitForSeconds(0.1f);
        _regenTick = true;
    }

    public void CheckShieldPress(bool shieldPress)
    {
        m_ShieldPress = shieldPress;

    }
}
