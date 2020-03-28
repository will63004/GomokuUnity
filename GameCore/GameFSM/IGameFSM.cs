using System.Threading.Tasks;

namespace GameCore.GameFSM
{
    public interface IGameFSM
    {
        Task ChangeFSMAsync(eGameFSM to);
    }
}