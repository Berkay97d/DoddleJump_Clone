using System.Runtime.InteropServices;

public static class KaracaAPI
{
    private static int ms_GameScore;
    
    
#if UNITY_WEBGL && !UNITY_EDITOR
            [DllImport("__Internal")]
            private static extern int ReturnScore(int x);
#endif
    
    public static void SetGameScore(int score)
    {
        ms_GameScore = score;
        
#if UNITY_WEBGL && !UNITY_EDITOR
            ReturnScore(ms_GameScore);
#endif
    }
    
    public static int GetGameScore()
    {
        return ms_GameScore;
    }
}