using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using ModestTree.Util;

#if !NOT_UNITY3D
using UnityEngine.SceneManagement;
using UnityEngine;
#endif

namespace Zenject.Internal
{
    public class ZenUtilInternal
    {
        // Due to the way that Unity overrides the Equals operator,
        // normal null checks such as (x == null) do not always work as
        // expected
        // In those cases you can use this function which will also
        // work with non-unity objects
        public static bool IsNull(System.Object obj)
        {
            return obj == null || obj.Equals(null);
        }

        public static bool AreFunctionsEqual(Delegate left, Delegate right)
        {
            return left.Target == right.Target && left.Method() == right.Method();
        }

#if !NOT_UNITY3D
        public static IEnumerable<SceneContext> GetAllSceneContexts()
        {
            foreach (var scene in UnityUtil.AllLoadedScenes)
            {
                var contexts = scene.GetRootGameObjects()
                    .SelectMany(root => root.GetComponentsInChildren<SceneContext>()).ToList();

                if (contexts.IsEmpty())
                {
                    continue;
                }

                Assert.That(contexts.Count == 1,
                    "Found multiple scene contexts in scene '{0}'", scene.name);

                yield return contexts[0];
            }
        }

        // NOTE: This method will not return components that are within a GameObjectContext
        public static IEnumerable<Component> GetInjectableComponentsBottomUp(
            GameObject gameObject, bool recursive)
        {
            var context = gameObject.GetComponent<GameObjectContext>();

            if (context != null)
            {
                yield return context;
                yield break;
            }

            if (recursive)
            {
                foreach (Transform child in gameObject.transform)
                {
                    foreach (var component in GetInjectableComponentsBottomUp(child.gameObject, recursive))
                    {
                        yield return component;
                    }
                }
            }

            foreach (var component in gameObject.GetComponents<Component>())
            {
                yield return component;
            }
        }
#endif
    }
}
