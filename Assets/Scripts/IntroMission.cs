using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroMission : MonoBehaviour {

	public GameObject player;
	public GameObject playerIntro;
	public GameObject heightBall;
	public GameObject blackBar;
	public GameObject gameUI;
	public Camera introCamera;
	public Text introText;
	public Text missionNameText;

	void Start()
	{
		StartCoroutine("StartIntro");
		PlayerPrefs.SetString("player", "orange");
	}

    void Update()
    {
        if (Input.anyKey) {
            StopCoroutine("StartIntro");
            CleanupIntro();
        }
    }

	IEnumerator StartIntro()
    {
        yield return new WaitForSeconds(1f);
        missionNameText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        introText.text = "I know a place on the edge of the Red Light District where we can lay low,";
        yield return new WaitForSeconds(5f);
        introText.text = "but my hands are all messed up so you better drive, brother.";
        yield return new WaitForSeconds(4f);
        missionNameText.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        CleanupIntro();
    }

    private void CleanupIntro()
    {
        introText.text = "";
        heightBall.gameObject.SetActive(false);
        playerIntro.gameObject.SetActive(false);
        blackBar.gameObject.SetActive(false);
        introCamera.gameObject.SetActive(false);
        introText.gameObject.SetActive(false);
        player.gameObject.SetActive(true);
        gameUI.gameObject.SetActive(true);
    }
}
