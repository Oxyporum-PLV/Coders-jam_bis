﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Capsule Instantiation")]
    [SerializeField] private GameObject CapsulColor = null;
    [SerializeField] private float MinDurationInstantiation = 5f;
    [SerializeField] private float MaxDurationInstantiation = 10f;
    private float currentDurationInstantiation;
    private float delay = 0f;


    [Header("Corner Zone")]
    [SerializeField] private Transform RightTop = null;
    [SerializeField] private Transform LeftBot = null;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentDurationInstantiation = Random.Range(MinDurationInstantiation, MaxDurationInstantiation);
    }


    void Update()
    {
        InstantiateObjestInZone();
    }

    private void InstantiateObjestInZone()
    {
        delay += Time.deltaTime;
        if (delay >= currentDurationInstantiation)
        {
            float randomX = Random.Range(LeftBot.transform.position.x, RightTop.transform.position.x);
            float randomY = Random.Range(LeftBot.transform.position.y, RightTop.transform.position.y);
            Instantiate(CapsulColor, new Vector3(randomX, randomY, 0f), Quaternion.identity);

            currentDurationInstantiation = Random.Range(MinDurationInstantiation, MaxDurationInstantiation);
            delay = 0f;
        }
    }

}