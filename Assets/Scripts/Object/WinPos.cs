using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPos : MonoBehaviour
{
    [SerializeField] ParticleSystem particelWinLeft;
    [SerializeField] ParticleSystem particelWinRight;
    [SerializeField] GameObject chestClose;
    [SerializeField] GameObject chestOpen;
    [SerializeField] ParticleSystem particelOpenChest;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {         
            particelWinLeft.Play();
            particelWinRight.Play();
            Player.Instance.animator.SetInteger("Jump", 1);
            GameManager.Instance.isWin = true;
            StartCoroutine(DelayTuroOffblock());
           
        }
    }

    IEnumerator DelayTuroOffblock()
    {
        yield return new WaitForSeconds(0.2f);
        Player.Instance.animator.SetInteger("Jump", 0);
         yield return new WaitForSeconds(0.2f);
        EventDispatcher.Instance.PostEvent(EventID.OnTurnOffAllBlock);
        Player.Instance.animator.SetInteger("Open", 1);
        StartCoroutine(OpenChest());
    }
    IEnumerator OpenChest()
    {
        yield return new WaitForSeconds(0.6f);
        OnChest();
        StartCoroutine(CloseChest());
    }
    IEnumerator CloseChest()
    {
        yield return new WaitForSeconds(0.5f);
        OffChest();
        Player.Instance.animator.SetInteger("Open", 0);
        yield return new WaitForSeconds(1f);
        GameManager.ChangeState(GameState.WinGame);
    }
    private void OnChest()
    {
        chestOpen.SetActive(true);
        chestClose.SetActive(false);
        particelOpenChest.Play();
    }
    private void OffChest()
    {
        chestClose.SetActive(true);
        chestOpen.SetActive(false);
        particelWinRight.Stop();
        particelWinLeft.Stop();
        particelOpenChest.Stop();
    }
}
