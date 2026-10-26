// Compatibility surface consumed by the unchanged Doozy BBUIButton plugin.
// Its legacy member spelling is part of that external contract.
public sealed class SoundManager
{
    private static readonly SoundManager s_Instance = new SoundManager();
    public static SoundManager instance => s_Instance;
    public void PlaySound_Click() => PlayClickInternal();
    private void PlayClickInternal()
    {
        var audio = Rush.Chocology.Audio.SoundManager.Instance;
        if (audio != null) audio.PlaySoundClick();
    }
}