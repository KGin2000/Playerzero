using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : SingletonMonobehaviour<AnimatorController>
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    public IEnumerator UseDiggingToolDown()
    {
        //Print the time of when the function is first called.
        Debug.Log("True");
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        anim.SetBool("UseDiggingToolDown", true);
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(0.5f);

        //After we have waited 5 seconds print the time again.
        Debug.Log("False");
        anim.SetBool("UseDiggingToolDown", false);
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    public IEnumerator UseDiggingToolUp()
    {
        anim.SetBool("UseDiggingToolUp", true);
        yield return new WaitForSeconds(0.5f);

        anim.SetBool("UseDiggingToolUp", false);
    }

    public IEnumerator UseDiggingToolLeft()
    {
        anim.SetBool("UseDiggingToolLeft", true);
        yield return new WaitForSeconds(0.5f);

        anim.SetBool("UseDiggingToolLeft", false);
    }

    public IEnumerator UseDiggingToolRight()
    {
        anim.SetBool("UseDiggingToolRight", true);
        yield return new WaitForSeconds(0.5f);

        anim.SetBool("UseDiggingToolRight", false);
    }

    public IEnumerator UseLiftingToolUp()
    {
        anim.SetBool("UseLiftingToolUp", true);
        yield return new WaitForSeconds(0.5f);

        anim.SetBool("UseLiftingToolUp", false);
    }

    public IEnumerator UseLiftingToolDown()
    {
        anim.SetBool("UseLiftingToolDown", true);
        yield return new WaitForSeconds(0.5f);

        anim.SetBool("UseLiftingToolDown", false);
    }

    public IEnumerator UseLiftingToolLeft()
    {
        anim.SetBool("UseLiftingToolLeft", true);
        yield return new WaitForSeconds(0.5f);

        anim.SetBool("UseLiftingToolLeft", false);
    }

    public IEnumerator UseLiftingToolRight()
    {
        anim.SetBool("UseLiftingToolRight", true);
        yield return new WaitForSeconds(0.5f);

        anim.SetBool("UseLiftingToolRight", false);
    }

    public IEnumerator UseChoppingToolUp()
    {
        anim.SetBool("UseChoppingToolUp", true);
        yield return new WaitForSeconds(0.5f);

        anim.SetBool("UseChoppingToolUp", false);
    }

    public IEnumerator UseChoppingToolDown()
    {
        anim.SetBool("UseChoppingToolDown", true);
        yield return new WaitForSeconds(0.5f);

        anim.SetBool("UseChoppingToolDown", false);
    }

    public IEnumerator UseChoppingToolLeft()
    {
        anim.SetBool("UseChoppingToolLeft", true);
        yield return new WaitForSeconds(0.5f);

        anim.SetBool("UseChoppingToolLeft", false);
    }

    public IEnumerator UseChoppingToolRight()
    {
        anim.SetBool("UseChoppingToolRight", true);
        yield return new WaitForSeconds(0.5f);

        anim.SetBool("UseChoppingToolRight", false);
    }

}
