using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomenager : MonoBehaviour
{
    public AudioClip fIt, music;
    public AudioSource audioScr;
    bool fou = false;

    // Start is called before the first frame update
    void Start()
    {
        audioScr.PlayOneShot(music);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0f, 0.5f, 0f);
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void QuitGame()
	{
        Application.Quit();
        Debug.Log("Quit");
    }

	private void OnCollisionEnter(Collision collision)
	{
        Debug.Log(collision.collider.name);
		if (collision.collider.name == "FPPlayer")
		{
			if (fou == false)
			{
                audioScr.PlayOneShot(fIt);
                Invoke("QuitGame", 0.5f);
                fou = true;
            }
        }
    }
}
