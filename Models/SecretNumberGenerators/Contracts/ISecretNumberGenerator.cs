namespace GuessNumberGame.Models.SecretNumberGenerators.Contracts
{
    public interface ISecretNumberGenerator
    {
        int Generate(int minValue, int maxValue);
    }
}
