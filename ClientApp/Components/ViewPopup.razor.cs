using Microsoft.AspNetCore.Components;
using Shared;

namespace ClientApp.Components
{
    public partial class ViewPopup
    {
        [Parameter]
        public OrderDto Order { get; set; }

        private OrderDto _order;

        protected override void OnParametersSet()
        {
            _order = Order;
        }
        public void Close() {
            _order = null;
        }
    }
}
