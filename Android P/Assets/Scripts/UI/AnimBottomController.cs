using UnityEngine;
using UnityEngine.UI;

public class AnimBottomController : MonoBehaviour
{
    private GameObject anim;
    private Image img;
    [SerializeField] private Slider ultimateBar;

    private void Start()
    {
        img = GetComponent<Image>();
        anim = gameObject.transform.GetChild(0).gameObject;
        anim.SetActive(false);
    }

    private void Update()
    {
        if (ultimateBar.value >= 1f)
        {
            anim.SetActive(true);
            img.enabled = false;
        }
        else
        {
            anim.SetActive(false);
            img.enabled = true;
        }
    }
}
