
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyAttacking : MonoBehaviour
{
    private Animator attackAnimator;
    [SerializeField] LayerMask playerMask;
    //[SerializeField] GameObject[] weapon;

    public CapsuleCollider triggerAttack;
    [SerializeField] private int numberAttack;
    public SphereCollider[] range;
    [SerializeField] private int numOfAttacken;
    bool isAttacking = false;

    private void Awake()
    {
        attackAnimator = GetComponentInChildren<Animator>();

        range = GetComponentInChildren<SphereCollider[]>();
        triggerAttack= GetComponent<CapsuleCollider>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isAttacking);
    }
    private void OnTriggerStay(Collider collision)
    {
        
        if (collision.CompareTag("Player") && isAttacking == false)
        {
   
           
            StartCoroutine(RandomAttack());
            

            if (!range[numOfAttacken].enabled)
            {
                range[numOfAttacken].gameObject.SetActive(true);
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopAttack();
            
        }
    }
    IEnumerator RandomAttack()
    {
        
        yield return new WaitForSeconds(0f);
        
        attackAnimator.SetInteger("attackIndex", Random.Range(0, numberAttack));
        attackAnimator.SetBool("attack", true);
        isAttacking = true;

    }

    public void StopAttack()
    {
        
        attackAnimator.SetBool("attack", false);
        if (range[numOfAttacken].enabled)
        {
            range[numOfAttacken].gameObject.SetActive(false);
        }
        isAttacking = false;
        
    }
}
