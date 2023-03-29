using ClientApp.Helper;
using Microsoft.AspNetCore.Components;

namespace ClientApp.Shared
{
    public partial class MainLayout
    {
        [Inject]
        public ApplicationState AppState { get; set; }


        
    }
}
