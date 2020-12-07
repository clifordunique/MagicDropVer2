namespace MagicDrop
{
    public enum DropClearMode
    {
        Line, Chain,
    }

    public enum DropAppearanceMode
    {
        Top, Bottom,
    }

    public enum DropClearTimingMode
    {
        Update, Fell,
    }

    public static class GameSettings
    {
        public static DropClearMode ClearMode = DropClearMode.Line;
        public static DropAppearanceMode AppearanceMode = DropAppearanceMode.Top;
        public static DropClearTimingMode ClearTimingMode = DropClearTimingMode.Update;
    }
}