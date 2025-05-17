using Code.Infrastructure.UIManagement;

namespace Code.UI
{
    public class LevelUpWindow : WindowBase
    {
        public override bool IsUserCanClose => false;

        private void OnPlayerLevelUp()
        {
            OnOpen();
        }
        
        //TODO: Upon opening, choose 3 abilities (from the ones that could be obtained) and instantiate them.
        
        //TODO: Close upon ability selection.
    }
}