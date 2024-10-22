using UnityEngine;
using TMPro;

public class OpenDoor : MonoBehaviour
{
    public Animator anim;
    public AudioSource audioSource;
    private bool doorState;
    public TMP_Text text;

    void Update()
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "door")
            {    
                if (doorState == false)
                {
 
                    if (Input.GetMouseButtonDown(0))
                    {
                        anim.Play("openAnim");
                        audioSource.Play();
                        doorState = true;
                    }
                }
               if (doorState == true)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        anim.Play("closeAnim");
                        audioSource.Play();
                        doorState = false;
                    }
                }
            }
        }
    }
}
