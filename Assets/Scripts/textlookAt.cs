using UnityEngine;

public class textlookAt : MonoBehaviour
{
    public GameObject target;
    void Update()
    {
        Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        Quaternion rotationAdjustment = Quaternion.Euler(0, 180, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation * rotationAdjustment, Time.deltaTime * 5f);
    }
}
