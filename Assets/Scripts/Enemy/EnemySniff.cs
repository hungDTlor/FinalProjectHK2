using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySniff : MonoBehaviour
{
    [SerializeField] public Transform zombieTransform;

    [SerializeField] public float radius;
    public GameObject player;
    
    [SerializeField] LayerMask playerMask;
    //spublic LayerMask obstructionMask;
    public bool findPlayer;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vision();
    }

    private void Vision()
    {
        Collider[] viewCheck = Physics.OverlapSphere(zombieTransform.position, radius, playerMask);

        if (viewCheck.Length != 0)
        {
            findPlayer = true;
        }
        else if (findPlayer)
        {
            findPlayer = false;
        }
    }

}
