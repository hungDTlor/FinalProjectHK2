
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyAttacking : MonoBehaviour
{
    [SerializeField] Animator attackAnimator;
    [SerializeField] LayerMask playerMask;
    
    
    [SerializeField] private int numberAttackAnimation;
    
    [SerializeField] private int numOfAttacken;

    [SerializeField] public Transform startView;

    [SerializeField] public float radius;
    //public GameObject player;
    [Range(0, 360)]
    [SerializeField] public float viewAngle;
    
    public LayerMask obstructionMask;
    public bool canAttackPlayer;
    [HideInInspector] public Transform target;

    [SerializeField] public GameObject hitPoint;


    private void Awake()
    {
        //attackAnimator = GetComponent<Animator>();
       
        
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        TriggerAttack();
        hitPoint.SetActive(false);
        
    }
    // Update is called once per frame
    void Update()
    {

        TriggerAttack();
        hitPoint.SetActive(false);
        
        if (canAttackPlayer == true)
        {
            //Debug.Log("Start");
            
            
            StartAttack();
        }
        
        
        else if (canAttackPlayer == false)
        {
            // Debug.Log("Stop");
            
            StopAttack();

        }
        
        
    }



    public void TriggerAttack()
    {
        Collider[] viewCheck = Physics.OverlapSphere(startView.position, radius, playerMask);

        if (viewCheck.Length != 0)
        {
            Transform target = viewCheck[0].transform;
            Vector3 directionTarget = (target.position - startView.position).normalized;
            if (Vector3.Angle(transform.forward, directionTarget) < viewAngle / 2)
            {
                float distanceTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(startView.position, directionTarget, distanceTarget, obstructionMask))
                {
                    //target = hit.transform;
                    canAttackPlayer = true;
                }
                else
                {
                    canAttackPlayer = false;
                }
            }
            else
            {
                canAttackPlayer = false;
            }
        }
        else if (canAttackPlayer)
        {
            canAttackPlayer = false;
        }
    }
    
    public void StartAttack()
    {
        StartCoroutine(RandomAttack());
        PlayHitPoint();
        


    }

    public IEnumerator RandomAttack()
    {
        
        yield return new WaitForSeconds(0f);
        attackAnimator.SetBool("Attack", true);
        attackAnimator.SetInteger("AttackIndex", Random.Range(0, numberAttackAnimation));
        
        

    }
    public void StopAttack()
    {

        attackAnimator.SetBool("Attack", false);
        




    }


    public void PlayHitPoint()
    {

        hitPoint.SetActive(true);

    }






    public void StopHitPoint()
    {

        //attackAnimator.SetBool("Attack", false);
        hitPoint.SetActive(false);




    }

}
