using System.Collections.Generic;
using System.Collections.ObjectModel;
using TapAndHoldToMultiSelect.Models;
using Xamarin.Forms;

namespace TapAndHoldToMultiSelect.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public Command<DemoModel> ItemLongPressed { get; }
        public ObservableCollection<DemoModel> DemoItems { get; set; } = new();

        private SelectionMode _selectionMode = SelectionMode.None;
        public SelectionMode SelectionMode
        {
            get => _selectionMode;
            set
            {
                _selectionMode = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<object> _selectedItems;
        public ObservableCollection<object> SelectedItems
        {
            get => _selectedItems;
            set
            {
                _selectedItems = value;
                OnPropertyChanged();
            }
        }

        private int _selectedItemsCount;
        public int SelectedItemsCount
        {
            get => _selectedItemsCount;
            set
            {
                _selectedItemsCount = value;
                OnPropertyChanged();
            }
        }


        public Command SelectionChanged { get; }
        public Command CancelCommand { get; }
        public HomeViewModel()
        {
            DemoItems.Add(new() { Id = 1, Name = "Prayag" });
            DemoItems.Add(new() { Id = 2, Name = "Deepak" });
            DemoItems.Add(new() { Id = 3, Name = "Sunil" });
            DemoItems.Add(new() { Id = 4, Name = "Ajay" });
            DemoItems.Add(new() { Id = 5, Name = "Sarfraz" });
            DemoItems.Add(new() { Id = 6, Name = "Amit" });
            DemoItems.Add(new() { Id = 7, Name = "Akshil" });
            ItemLongPressed = new(ItemTapCommandMethod);
            SelectionChanged = new(SelectionChangedMethod);
            CancelCommand = new(CancelCommandMethod, () => SelectionMode == SelectionMode.Multiple);
        }

        private void ItemTapCommandMethod(DemoModel demoModel)
        {
            try
            {
                if (SelectionMode == SelectionMode.None)
                {
                    SelectionMode = SelectionMode.Multiple;
                    SelectedItems = new ObservableCollection<object>() { demoModel };
                }
                else if (SelectionMode == SelectionMode.Multiple)
                    SelectedItems.Add(demoModel);
            }
            catch (System.Exception exc)
            {

            }
        }
        private void SelectionChangedMethod()
        {
            SelectedItemsCount = SelectedItems is null ? 0 : SelectedItems.Count;
            if (SelectedItemsCount == 0)
                SelectionMode = SelectionMode.None;
            CancelCommand.ChangeCanExecute();
        }
        private void CancelCommandMethod()
        {
            SelectedItems = null;
            SelectionMode = SelectionMode.None;
        }
    }
}