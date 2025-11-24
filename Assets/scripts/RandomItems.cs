using UnityEngine;

public class RandomItem : MonoBehaviour
{
    [SerializeField] string[] Items;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) PrintRandomItem();
        if (Input.GetKeyDown(KeyCode.Escape)) PrintAllItems();
    }

    private void PrintRandomItem()
    {
        int i = Random.Range(0, Items.Length);
        Debug.Log(Items[i]);
    }

    private void PrintAllItems()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            Debug.Log(Items[i]);
        }
    }
}
