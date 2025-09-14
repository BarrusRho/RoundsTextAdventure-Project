namespace RoundsTextAdventure
{
    public static class AudioPlayer
    {
        private static AudioService AudioService => ServiceLocator.Get<AudioService>();

        public static void Click() => AudioService.PlayAudioClip(AudioTag.Click);
        public static void Confirm() => AudioService.PlayAudioClip(AudioTag.Confirm);
        public static void NewGameStart() => AudioService.PlayAudioClip(AudioTag.NewGameStart);
        public static void ButtonPress() => AudioService.PlayAudioClip(AudioTag.ButtonPress);
    }
}
