using ClientApp.Services;
using Domain.Model;
using Microsoft.AspNetCore.Components;
using Shared;

namespace ClientApp.Pages
{
    public partial class OrdersOverviewMud
    {
        [Inject]
        public IOrderDataService? OrderDataService { get; set; }


        private bool dense = false;
        private bool hover = true;
        private bool striped = false;
        private bool bordered = false;
        private string searchString1 = "";
        private OrderDto selectedItem1 = null;
        private HashSet<OrderDto> selectedItems = new HashSet<OrderDto>();

        private IEnumerable<OrderDto> Elements = new List<OrderDto>();
        private IEnumerable<OrderDto> AllElements = new List<OrderDto>();

        private OrderStatus? _orderStatus;

        public OrderStatus? currentOrderStatus
        {
            get { return _orderStatus; }
            set { _orderStatus = value;
                UpdateFilters();
            }
        }



        private DateTime? _dateFrom;
        public DateTime? DateFrom
        {
            get { return _dateFrom; }
            set { 
                _dateFrom = value;
                UpdateFilters();
            }
        }

        private DateTime? _dateTo;
        public DateTime? DateTo
        {
            get { return _dateTo; }
            set
            {
                _dateTo = value;
                UpdateFilters();
            }
        }

        private void UpdateFilters()
        {
            Elements = AllElements;
            FilterByDate();
            FilterByStatus();

        }

        private void ResetFilters()
        {
            searchString1 = "";
            currentOrderStatus = OrderStatus.None;
            DateFrom = null;
            DateTo = null;
            Elements = AllElements;
        
        }

        private void FilterByDate()
        {
            if (_dateFrom != null)
            {
                Elements = Elements.Where(x => x.CreateDate > _dateFrom).ToList();
            }
            if (_dateTo != null)
            {
                Elements = Elements.Where(x => x.CreateDate < _dateTo).ToList();
            }
        }
        private void FilterByStatus() {

            if (currentOrderStatus != OrderStatus.None)
            {
                Elements = Elements.Where(x => x.Status == currentOrderStatus);
            }

        }

        protected override async Task OnInitializedAsync()
        {
            currentOrderStatus = OrderStatus.None;
            Elements = (await OrderDataService.GetAllOrders()).ToList();
            AllElements = Elements;
        }

        private bool FilterFunc1(OrderDto element) => FilterFunc(element, searchString1);

        private bool FilterFunc(OrderDto element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.ClientName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.AdditionalInfo.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private void ShowBtnPress(int nr)
        {
            OrderDto tmpPerson = Elements.First(f => f.OrderId == nr);
            tmpPerson.ShowDetails = !tmpPerson.ShowDetails;
        }
    }

}