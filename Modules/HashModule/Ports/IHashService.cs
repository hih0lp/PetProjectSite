namespace PetProjectC_NeuroWeb.Modules.HashModule.Ports
{
    public interface IHashService
    {
        public byte[] GenerateHashedPassword(string password, byte[] salt);
    }
}
