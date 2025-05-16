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
    }
}