using AV.FillMaster.Application;
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AV.FillMaster.UnityLibrary
{
    /// <summary>
    /// Entry point for wiring up the engine and executing main loop.
    /// </summary>
    public static class Program
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static async void Main()
        {
#if UNITY_EDITOR
            if (SceneManager.GetActiveScene().name.StartsWith("InitTestScene"))
                return;
#elif UNITY_INCLUDE_TESTS
            return;
#endif

#if UNITY_EDITOR
            AsyncOperation sceneLoadingOperation = SceneManager.LoadSceneAsync(0);
            while (!sceneLoadingOperation.isDone)
                await Task.Yield();
#endif

#if UNITY_EDITOR || !UNITY_WEBGL
            Trace.Listeners.Add(new UnityConsoleTraceListener());
#endif

            bool quitting = false;
            UnityEngine.Application.quitting += () => { quitting = true; };

            Stopwatch stopwatch = new();
            stopwatch.Start();

            var clientApplication = new ClientApplication(
                new UnityInfrastructureLibrary(),
                new UnityInputLibrary(),
                new UnityUserInterfaceLibrary()
            );

            while (!quitting)
            {
                clientApplication.ExecuteFrame(stopwatch.ElapsedMilliseconds);
                await Task.Yield();
            }
        }
    }
}
