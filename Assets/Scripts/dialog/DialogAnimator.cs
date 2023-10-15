using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogAnimator : MonoBehaviour
{
    public Animator startAnim;
    public DialogMeneger dm;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            startAnim.SetBool("startOpen", true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent <PlayerController>())
        {
            startAnim.SetBool("startOpen", false);
            dm.EndDialog();
        }
        
    }

}
