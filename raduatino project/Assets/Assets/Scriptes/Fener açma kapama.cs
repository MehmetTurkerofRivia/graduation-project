using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    [Header("Opsiyonel: Light component (eğer manuel atarsan, otomatik aramaya gerek kalmaz)")]
    public Light flashlight;                 // Eğer inspector'dan atarsan, otomatik arama yapılmaz
    [Header("Opsiyonel: Fener modelini show/hide etmek istersen bağla")]
    public GameObject flashlightModel;       // Modeli açıp kapatmak istersen bağla

    void Awake()
    {
        // Eğer inspector'da atanmamışsa GameObject veya çocuklarında Light arar
        if (flashlight == null)
        {
            flashlight = GetComponent<Light>();
            if (flashlight == null)
                flashlight = GetComponentInChildren<Light>();
        }

        if (flashlight == null)
        {
            Debug.LogWarning("[FlashlightToggle] Herhangi bir Light bulunamadı. Bu script'i ışığın olduğu objeye veya onun child'ına ekle, ya da inspector'dan atan.");
        }
    }

    void Update()
    {
        // F tuşuna basıldığında toggle yap
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFlashlight();
        }
    }

    public void ToggleFlashlight()
    {
        if (flashlight != null)
        {
            flashlight.enabled = !flashlight.enabled;
        }

        if (flashlightModel != null)
        {
            flashlightModel.SetActive(flashlight != null ? flashlight.enabled : !flashlightModel.activeSelf);
        }
    }

    // İstersen başka script'lerden aç/kapat fonksiyonunu çağırmak için:
    public void SetFlashlight(bool on)
    {
        if (flashlight != null) flashlight.enabled = on;
        if (flashlightModel != null) flashlightModel.SetActive(on);
    }
}
