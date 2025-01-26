using UnityEngine;

public class SyncedAnimation : MonoBehaviour
{

    //The animator controller attached to this GameObject
    Animator animator;

    //Records the animation state or animation that the Animator is currently in
    public AnimatorStateInfo animatorStateInfo;

    //Used to address the current state within the Animator using the Play() function
    public int currentState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Load the animator attached to this object
        animator = GetComponent<Animator>();

        //Get the info about the current animator state
        animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        //Convert the current state name to an integer hash for identification
        currentState = animatorStateInfo.fullPathHash;
    }

    // Update is called once per frame
    void Update()
    {
        //NOP
    }
}
