﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Starflow
{
    public class GameObject
    {
        public bool enabled;
        public string name;
        public Transform transform;

        public List<Component> components { get; private set; }

        public T GetComponent<T>() where T : Component, new()
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].GetType() == typeof(T))
                {
                    try
                    {
                        return (T)(Component)(object)components[i];
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError(ex);
                    }
                }
            }

            return null;
        }

        public void RemoveComponent<T>(T componentClass) where T : Component // ill fix later
        {
            for (int i = 0; i < components.Count; i++)
            {
                Component c = components[i];
                if (componentClass == c)
                {
                    components.RemoveAt(i);
                    return;
                }
            }
        }

        public T AddComponent<T>() where T : Component, new()
        {
            T t = new T();
            t.gameObject = this;
            if (t.GetType().IsSubclassOf(typeof(MonoBehaviour)))
            {
                MonoBehaviour b = (MonoBehaviour)(object)t;
                if (GameManager.currentScene != null)
                    b.Start();
                GameManager.Components.Add(b);
            }

            components.Add(t);
            return t;
        }

        public T AddComponent<T>(T type) where T : Component, new()
        {
            T t = new T();
            t.gameObject = this;
            if (t.GetType().IsSubclassOf(typeof(MonoBehaviour)))
            {
                MonoBehaviour b = (MonoBehaviour)(object)t;
                if (GameManager.currentScene != null)
                    b.Start();
                GameManager.Components.Add(b);
            }

            components.Add(t);
            return t;
        }

        public GameObject(string name = "GameObject")
        {
            this.name = name;
            transform = new Transform()
            {
                position = new Vector2(0, 0),
                rotation = 0f,
                scale = new Vector2(1, 1)
            };
            transform.gameObject = this;
            components = new List<Component>();
            if (GameManager.currentScene != null)
            GameManager.currentScene.gameObjects.Add(this);
            enabled = true;
        }
    }
}
