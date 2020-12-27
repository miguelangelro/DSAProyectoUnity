using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;

    public Gradient gradient;
    public Image fill;
    public GameObject player;
    PlayerMovement jug;
    void Start()
    {
        
        //slider = GameObject.Find("HealthBar").GetComponent<Slider>();
        //fill = GameObject.Find("Fill").GetComponent<Image>();

        player = GameObject.Find("Player(Clone)");
        jug = player.GetComponent<PlayerMovement>();
        SetMaxHealth(jug.maxHealth);



    }

    void Update()
    {
        SetHealth(jug.currentHealth);
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);

    }
    

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);

    }
}
