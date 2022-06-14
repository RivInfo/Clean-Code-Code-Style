public class PairMethods
{
    private bool _enable;

    public void StartEffectsAnimation()
    {
        _enable = true;

        _effects.StartEnableAnimation();
    }

    public void FreePool()
    {
        _enable = false;

        _pool.Free(this);
    }
}