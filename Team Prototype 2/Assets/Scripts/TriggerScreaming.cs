using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerScreaming : MonoBehaviour
{
    Slider slider;
    AudioSource audioSource;
    public GameObject cop;
    public Animator robo;
    float timer = 10f;
    public string roboEmote = "happy";
    public SwitchView switchView;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0 && slider.value != slider.maxValue)
        {
            timer = 1f;
            slider.value -= 5;
        }
        if(slider.value >= slider.maxValue && roboEmote != "supermad")
        {
            roboEmote = "supermad";
            robo.SetBool("supermad", true);
            audioSource.Play();
            cop.SetActive(true);
            if (!switchView.frontView.activeInHierarchy)
            {
                switchView.SwitchViews();
            }
        }
        if(slider.maxValue > slider.value && slider.value >= 100 && roboEmote != "mad")
        {
            robo.SetTrigger("mad");
            roboEmote = "mad";
        }
        if(slider.value < 100 && roboEmote != "happy")
        {
            robo.SetTrigger("happy");
            roboEmote = "happy";
        }
    }
}
