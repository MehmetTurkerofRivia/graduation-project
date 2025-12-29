using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class CollectableObjects : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    public Material Lmaterial;
    public GameObject picFrame;
    public GameObject door;
    public Light directionalLight;
    public Material nightSkybox;
    public Color darkAmbient = Color.black;



    void Start()
    {
        ActivateRandomObject();
    }

    public void ActivateRandomObject()
    {
        if (objects.Count == 0)
        {
            picFrame.GetComponent<MeshRenderer>().material = Lmaterial;
            door.transform.Rotate(0f, -35f, 0f);
            directionalLight.intensity = 0.1f;
            RenderSettings.skybox = nightSkybox;
            DynamicGI.UpdateEnvironment();
            RenderSettings.ambientLight = darkAmbient;
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
