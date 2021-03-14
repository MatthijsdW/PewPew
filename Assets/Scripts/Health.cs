using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class Health : MonoBehaviour
{
    float barDisplay;

    private float currentHealth;
    public float maxHealth = 100;

    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Image[] images = GetComponentsInChildren<Image>();
        healthBar = images.FirstOrDefault(x => x.name == "HealthBar");
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            currentHealth -= 10;
            if (currentHealth <= 0)
                Destroy(gameObject);
        }
    }
}
