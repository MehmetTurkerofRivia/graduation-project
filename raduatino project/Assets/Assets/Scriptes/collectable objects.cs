using System.Collections.Generic;
using UnityEngine;

public class CollectableObjects : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    public Material Lmaterial;
    public GameObject picFrame;
    public GameObject door;
    public GameObject clown;

    void Start()
    {
        ActivateRandomObject();
    }

    public void ActivateRandomObject()
    {
        if (objects.Count == 0)
        {
            picFrame.GetComponent<MeshRenderer>().material = Lmaterial;
            door.transform.Rotate(0f, 35f, 0f);
            clown.transform.rotation = Quaternion.Lerp(
            door.transform.rotation,
            Quaternion.Euler(0f, 35f, 0f),
            Time.deltaTime
);
        }

        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }

        int randomIndex = Random.Range(0, objects.Count);
        objects[randomIndex].SetActive(true);
    }

    public void RemoveObject(GameObject obj)
    {
        if (objects.Contains(obj))
        {
            objects.Remove(obj);
        }
    }
}
