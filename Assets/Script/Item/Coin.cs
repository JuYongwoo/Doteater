using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {

        if (!other.CompareTag("Player")) return;

        PlaySoundDetached();
        InGameManager.coinget();

        gameObject.SetActive(false);
    }

    private void PlaySoundDetached()
    {
        AudioClip clip = Resources.Load<AudioClip>("coinsound");

        GameObject tempAudio = new GameObject("TempCoinSound");
        AudioSource source = tempAudio.AddComponent<AudioSource>();
        source.clip = clip;
        source.Play();

        Destroy(tempAudio, clip.length);
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward*Time.deltaTime*100);

    }
}