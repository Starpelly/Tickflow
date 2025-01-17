﻿namespace Starflow
{
    public abstract class MonoBehaviour : Component
    {
        /// <summary>
        /// Awake is called when the script instance is being loaded. (This is before Start)
        /// </summary>
        public virtual void Awake() {}
        /// <summary>
        /// Start is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        public virtual void Start() { }
        /// <summary>
        /// EarlyUpdate is called before all Update functions have been called.
        /// </summary>
        public virtual void EarlyUpdate() { }
        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        public virtual void Update() { }
        /// <summary>
        /// LateUpdate is called after all Update functions have been called, if the MonoBehaviour is enabled.
        /// </summary>
        public virtual void LateUpdate() { }
    }
}
