#if !NOT_UNITY3D

using System;
using System.Collections.Generic;
using ModestTree;
using ModestTree.Util;
using UnityEngine;

namespace Zenject
{
    public abstract class MonoKernel : MonoBehaviour
    {
        [InjectLocal]
        TickableManager _tickableManager = null;

        [InjectLocal]
        InitializableManager _initializableManager = null;

        [InjectLocal]
        DisposableManager _disposablesManager = null;

        bool _isDestroyed;

        public virtual void Start()
        {
            _initializableManager.Initialize();
        }

        protected bool IsDestroyed
        {
            get
            {
                return _isDestroyed;
            }
        }

        public virtual void Update()
        {
            // Don't spam the log every frame if initialization fails and leaves it as null
            if (_tickableManager != null)
            {
                _tickableManager.Update();
            }
        }

        public virtual void FixedUpdate()
        {
            // Don't spam the log every frame if initialization fails and leaves it as null
            if (_tickableManager != null)
            {
                _tickableManager.FixedUpdate();
            }
        }

        public virtual void LateUpdate()
        {
            // Don't spam the log every frame if initialization fails and leaves it as null
            if (_tickableManager != null)
            {
                _tickableManager.LateUpdate();
            }
        }

        public virtual void OnDestroy()
        {
            // _disposablesManager can be null if we get destroyed before the Start event
            if (_disposablesManager != null)
            {
                Assert.That(!_isDestroyed);
                _isDestroyed = true;

                _disposablesManager.Dispose();
                _disposablesManager.LateDispose();
            }
        }
    }
}

#endif
