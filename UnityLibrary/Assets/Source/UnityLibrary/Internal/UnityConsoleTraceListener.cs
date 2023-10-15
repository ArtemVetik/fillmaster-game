using System.Diagnostics;

namespace AV.FillMaster.UnityLibrary
{
    internal class UnityConsoleTraceListener : TraceListener
    {
        public override void Write(string message)
        {
            UnityEngine.Debug.Log(message);
        }

        public override void WriteLine(string message)
        {
            UnityEngine.Debug.Log(message);
        }
    }
}
