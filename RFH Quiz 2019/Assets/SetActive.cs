using UnityEngine.UI;
using UnityEngine;

public class SetActive : MonoBehaviour {

    public Sprite activeSprite;
    public Sprite inactiveSprite;
    public bool isActive = false;

   void SetActiveSprite() {
        if (isActive == true)
        {
            this.GetComponent<SpriteRenderer>().sprite = activeSprite;
        }
        else {
            this.GetComponent<SpriteRenderer>().sprite = inactiveSprite;
        }

    }

    void ActiveToggle()
    {
        isActive = true;
    }

    private void Update ()
    {
        SetActiveSprite();
        Debug.Log(isActive);
    }



}
