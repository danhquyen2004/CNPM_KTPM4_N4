using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public static int d_health ;
    public List<Image> healths = new List<Image>();
    public Sprite fullHealth;
    public Sprite emptyHealth;
    void Awake()
    {
        d_health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeHealth();
    }
    private void ChangeHealth()
    {
        foreach (Image health in healths)
        {
            health.sprite = emptyHealth;
        }
        for(int i = 0;i < d_health; i++)
        {
            healths[i].sprite = fullHealth;
        }
    }
}
