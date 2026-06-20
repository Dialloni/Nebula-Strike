using UnityEngine;

public class DestroyByBounder : MonoBehaviour
{
 private void OnTriggerExit(Collider other)
{
Destroy(other.gameObject);
}
}
