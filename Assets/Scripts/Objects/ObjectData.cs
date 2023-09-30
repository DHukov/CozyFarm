﻿using UnityEngine;

public abstract class ObjectData : ScriptableObject
{
    [SerializeField] public Sprite image;
    [SerializeField] public string objectName;
    public TypeObject typeObject;
    [SerializeField] public string description;
    public GameObject prefab;
    [field: SerializeField] public int ObjectCost { get; private set; }

}