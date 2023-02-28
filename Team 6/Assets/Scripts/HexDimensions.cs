

public static class HexDimensions
{
	
	private static readonly float WIDTH_MULTIPLIER = Mathf.Sqrt(3) / 2;
	public static readonly float radius = 1f;
	
	private static int offset;// = Random.Range(0, 200);
	
	public static HexDimensions()
	{
		offset = Random.Range(0,200);
	}
	
	public static float HexHeight()
    {
        return radius * 2;
    }

    public static float HexWidth()
    {
        return WIDTH_MULTIPLIER * HexHeight();
    }

    public static float HexVerticalSpacing()
    {
        return HexHeight() * 0.75f;
    }

    public static float HexHorizontalSpacing()
    {
        return HexWidth();
    }
	
	
}