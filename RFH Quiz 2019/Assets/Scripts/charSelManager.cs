using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class charSelManager : MonoBehaviour {

    private int charID;
	
    [SerializeField]
    private Toggle christian;

    [SerializeField]
    private Toggle hindu;

    [SerializeField]
    private Toggle sikh;

    [SerializeField]
    private Toggle muslim;

    [SerializeField]
    private Toggle buddhist;

    [SerializeField]
    private Toggle jew;

    [SerializeField]
    private GameObject button;

	void Awake()
	{
		charID = 0;
	}
    void Start()
    {
            button.SetActive(false);
    }

    public void ToggleSel()
    {
        if (christian.isOn == true)
        {
            charID = 0;
        }
        else if (hindu.isOn == true)
        {
            charID = 1;
        }
        else if (sikh.isOn == true)
        {
            charID = 2;
        }
        else if (muslim.isOn == true)
        {
            charID = 3;
        }
        else if (buddhist.isOn == true)
        {
            charID = 4;
        }
        else if (jew.isOn == true)
        {
            charID = 5;
        }
        Debug.Log(charID);

        button.SetActive(true);
    }
	
	public void StartGameScene()
	{
		CharacterID.Id = charID;
		print(charID);
		SceneManager.LoadScene("Main");
	}
	
	
}
