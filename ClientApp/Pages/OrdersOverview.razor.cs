using ClientApp.Helper;
using ClientApp.Services;
using Domain.Model;
using Microsoft.AspNetCore.Components;
using Shared;

namespace ClientApp.Pages
{
    public partial class OrdersOverview
    {
        [Inject]
        public IOrderDataService? OrderDataService { get; set; }
        [Inject]
        public ApplicationState ApplicationState { get; set; }

        public List<OrderDto> AllOrders { get; set; } = default!;
        public List<OrderDto> FilteredOrders { get; set; } = default!;
        public List<OrderDto> Orders { get; set; } = default!;
        
        private OrderDto? _selectedOrder;
        private string Title = "Orders overview";

        public OrderFilter Filter { get; set; } = new OrderFilter() { DateFrom = null, DateTo = null, Statuses = Enumerable.Empty<OrderStatus>() };
        
        private OrderStatus _currentStatus;
        public OrderStatus currentStatus
        {
            get => _currentStatus;
            set {
                _currentStatus = value;
                AutoFilter();
                //AddFilterStatus();
            }
        }        
        

        public int PageNumber { get; set; } = 1;
        const int Offset = 10;
        public int NumberOfOrders;

        protected override async Task OnInitializedAsync()
        {
            AllOrders = (await OrderDataService.GetAllOrders()).ToList();
            FilteredOrders = AllOrders.Skip((PageNumber-1)*Offset).Take(Offset).ToList();
            Orders = FilteredOrders;
            NumberOfOrders = AllOrders.Count;
            ApplicationState.NewOrders = AllOrders.Where(x => x.Status == OrderStatus.New).Count();
        }

        public void ShowViewPopup(OrderDto selectedOrder) { 
            _selectedOrder = selectedOrder;
        }

        public void PreviousPage()
        {
            if ((PageNumber-1) >= 1)
            {
                PageNumber--;
                Orders = FilteredOrders.Skip((PageNumber - 1) * Offset).Take(Offset).ToList();
            }
        }

        public void NextPage()
        {
            if (PageNumber <= FilteredOrders.Count/Offset)
            {
                UpdateFilter();
                PageNumber++;
                Orders = FilteredOrders.Skip((PageNumber - 1) * Offset).Take(Offset).ToList();
            }
        }


        public void AutoFilter() {
            AddFilterStatus();
            UpdateFilter();
        }

        public void AddFilterStatus()
        {
            if (!Filter.Statuses.Contains(_currentStatus))
            {
                Filter.Statuses = Filter.Statuses.Concat(new[] { _currentStatus });
            }
        }

        public void UpdateFilter()
        {
            FilteredOrders = AllOrders;
            FilerByDate();
            FilterByStatus();
            Orders = FilteredOrders.Skip((PageNumber - 1) * Offset).Take(Offset).ToList();
        }

        private void FilterByStatus()
        {
            if (Filter.Statuses.Any())
            {
                if (!Filter.Statuses.Contains(OrderStatus.None))
                    FilteredOrders = FilteredOrders.Where(x => Filter.Statuses.Contains(x.Status)).ToList();
            }
        }

        private void FilerByDate()
        {
            if (Filter.DateFrom != null)
            {
                FilteredOrders = FilteredOrders.Where(x => x.CreateDate > Filter.DateFrom).ToList();
            }

            if (Filter.DateTo != null)
            {
                FilteredOrders = FilteredOrders.Where(x => x.CreateDate < Filter.DateTo).ToList();
            }
        }

        public void ResetFilter()
        {
            PageNumber = 1;
            Filter.DateFrom = null;
            Filter.DateTo = null;
            Filter.Statuses = Enumerable.Empty<OrderStatus>();
            Orders = AllOrders.Skip((PageNumber - 1) * Offset).Take(Offset).ToList();
        }


    }
}
