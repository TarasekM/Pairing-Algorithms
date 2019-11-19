namespace PairingAlgorithms.Systems
{
    public class PairingFactory
    {

        public enum PairingSystems
        {
            RoundRobin,
            PlayOff,
            Swiss,
        }

        public static Pairing GetPairing(PairingSystems System)
        {
            switch (System)
            {
                case PairingSystems.RoundRobin:
                    return new RoundRobin();
                case PairingSystems.PlayOff:
                    return new PlayOff();
                case PairingSystems.Swiss:
                    return new Swiss();
                default:
                    return new RoundRobin();
            }
        }
    }
}
