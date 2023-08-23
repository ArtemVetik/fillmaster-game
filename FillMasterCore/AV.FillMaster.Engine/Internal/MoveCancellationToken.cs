namespace AV.FillMaster.FillEngine
{
    internal struct MoveCancellationToken
    {
        public bool Cancelled { get; private set; }

        public void Cancel()
        {
            Cancelled = true;
        }
    }
}
