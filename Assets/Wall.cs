namespace Assets
{
    public class Wall
    {
        public int Number { get; set; }
        public int PrimaryTexture { get; set; }
        public int SecondaryTexture { get; set; } = -1;
        public UVL [] Uvls { get; set; }=new UVL[4];
    }
}
