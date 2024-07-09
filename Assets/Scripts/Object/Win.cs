using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] ParticleSystem particelWinLeft;
    [SerializeField] ParticleSystem particelWinRight;
    [SerializeField] GameObject chestClose;
    [SerializeField] GameObject chestOpen;
    [SerializeField] ParticleSystem particelOpenChest;
    
    private Player _player;
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            Debug.LogWarning("xxx");           
            particelWinLeft.Play();
            particelWinRight.Play();
            _player = other.GetComponent<Player>();
            _player.animator.SetInteger("Jump", 1);
            UI.Instance.isWin = true;
            StartCoroutine(DelayTuroOffblock());
           
        }
    }

    IEnumerator DelayTuroOffblock()
    {
        yield return new WaitForSeconds(0.2f);
        _player.animator.SetInteger("Jump", 0);
        Debug.Log(_player.animator.GetInteger("Jump") +" trang thai");
         yield return new WaitForSeconds(0.2f);
        EventDispatcher.Instance.PostEvent(EventID.OnTurnOffAllBlock);
        Debug.Log(_player.animator.GetInteger("Jump") + " trang thai");
        _player.animator.SetInteger("Open", 1);
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
        _player.animator.SetInteger("Open", 0);
        yield return new WaitForSeconds(1f);
        UI.Instance.OnPopupWin();
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
