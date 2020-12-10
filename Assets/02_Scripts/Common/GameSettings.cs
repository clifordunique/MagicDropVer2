namespace MagicDrop
{
    public enum DropClearRule
    {
        Line, Chain,
    }

    public enum DropCreateMode
    {
        Top, Bottom,
    }

    public enum DropClearTiming
    {
        Always, Dropped,
    }

    public static class GameSettings
    {
        public static DropClearRule ClearRule = DropClearRule.Chain;
        public static DropCreateMode CreateMode = DropCreateMode.Top;
        public static DropClearTiming ClearTiming = DropClearTiming.Always;
    }
}