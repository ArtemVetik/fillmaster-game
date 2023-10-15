namespace AV.FillMaster.UnityLibrary
{
    internal struct PollButton
    {
        private bool _clicked;

        public void Click() => _clicked = true;
        public bool Poll() => _clicked && !(_clicked = false);
    }

    internal struct PollButton<T>
    {
        private bool _clicked;
        private T _value;

        public void Click(T value)
        {
            _clicked = true;
            _value = value;
        }

        public bool Poll(out T value)
        {
            value = _value;
            return _clicked && !(_clicked = false);
        }
    }
}
