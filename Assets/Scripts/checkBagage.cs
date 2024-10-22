using UnityEngine;
using TMPro;

public class checkBagage : MonoBehaviour
{
    public int boxCount = 0;
    public int statueCount = 0;
    public int bankCount = 0;
    public TMP_Text text;
    void Update()
    {
        text.text = $"Boxes: {boxCount}\nStatues: {statueCount}\nPiggy banks: {bankCount}";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("box"))
        {
            boxCount++;
        }
        if (other.CompareTag("statue"))
        {
            statueCount++;
        }
        if (other.CompareTag("piggy_bank"))
        {
            bankCount++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("box"))
        {
            boxCount--;
        }
        if (other.CompareTag("statue"))
        {
            statueCount--;
        }
        if (other.CompareTag("piggy_bank"))
        {
            bankCount--;
        }
    }
}
