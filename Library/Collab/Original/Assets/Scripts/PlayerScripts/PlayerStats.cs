using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour {
    private float lasthit;
    public float _Speed = 5f;
    public float _Damage = 1f;
    public float timeimmunity;
    public float _Agility = 30f;
    public float _Health = 100f;
    public float _Endurance = 2f;
    public float _Maxhealth = 100f;
    private PlayerStats playerStats;
    [HideInInspector] public int _pvekills;

    void Start() {
        lasthit = 0;
        _pvekills = 0;
        // ResetStats();
        // _Speed = PlayerPrefs.GetFloat("Speed");
        // _Health = PlayerPrefs.GetFloat("Health");
        // _Damage = PlayerPrefs.GetFloat("Damage");
        // playerStats = GetComponent<PlayerStats>();
        // _Agility = PlayerPrefs.GetFloat("Agility");
        // _Endurance = PlayerPrefs.GetFloat("Endurance");
        // _Maxhealth = PlayerPrefs.GetFloat("MaxHealth");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("RESET");
            ResetStats();
        }
        _Speed = PlayerPrefs.GetFloat("Speed");
        _Health = PlayerPrefs.GetFloat("Health");
        _Damage = PlayerPrefs.GetFloat("Damage");
        _Agility = PlayerPrefs.GetFloat("Agility");
        _Endurance = PlayerPrefs.GetFloat("Endurance");
        _Maxhealth = PlayerPrefs.GetFloat("MaxHealth");
    }

    public static void ResetStats() {
        PlayerPrefs.SetFloat("MaxHealth", 100f);
        PlayerPrefs.SetFloat("Health", 100f);
        PlayerPrefs.SetFloat("Damage", 1f);
        PlayerPrefs.SetFloat("Endurance", 2f);
        PlayerPrefs.SetFloat("Agility", 30f);
        PlayerPrefs.SetFloat("Speed", 5f);
    }

    public void AddMaxHealth(float maxhealth) {
        float temp = PlayerPrefs.GetFloat("MaxHealth");
        PlayerPrefs.SetFloat("MaxHealth", temp + maxhealth);
    }

    public void AddHealth(float health) {
        float temp = PlayerPrefs.GetFloat("Health");
        if (health < 0)
            SoundManager.PlaySound(SoundManager.Sound.PlayerHit);
        if (temp + health >= _Maxhealth)
            PlayerPrefs.SetFloat("Health", _Maxhealth);
        else
            PlayerPrefs.SetFloat("Health", temp + health);
    }

    public void AddDamage(float Damage) {
        float temp = PlayerPrefs.GetFloat("Damage");
        PlayerPrefs.SetFloat("Damage", temp + Damage);
    }

    public void AddEndurance(float Endurance) {
        float temp = PlayerPrefs.GetFloat("Endurance");
        PlayerPrefs.SetFloat("Endurance", temp + Endurance);
    }

    public void AddAgility(float Agility) {
        float temp = PlayerPrefs.GetFloat("Agility");
        PlayerPrefs.SetFloat("Agility", temp + Agility);
    }

    public void AddSpeed(float Speed) {
        float temp = PlayerPrefs.GetFloat("Speed");
        PlayerPrefs.SetFloat("Speed", temp + Speed);
    }

    public void AddSPowerUp(PowerUp up) {
        AddMaxHealth(up.MaxHealth);
        AddHealth(up.Health);
        AddDamage(up.Damage);
        AddEndurance(up.Endurance);
        AddAgility(up.Agility);
        AddSpeed(up.Speed);
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag == "Zombie" && Time.realtimeSinceStartup - lasthit > 1) {
            AddHealth(-10f);
            lasthit = Time.realtimeSinceStartup;
        }
    }
}
