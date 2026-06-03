using UnityEngine;

public class ClothingItem : MonoBehaviour
{
    public ClothingData data;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerClothingController player =
                other.GetComponent<PlayerClothingController>();

            if (player != null)
            {
                player.EquipClothing(data);
            }

            Destroy(gameObject); // 取ったら消える
        }
    }
}
