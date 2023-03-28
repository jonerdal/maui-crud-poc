using System.ComponentModel;

namespace MauiFrontendApplication.Models
{
    //Suffix model to avoid mixup with Maui sensor class Location
    public class LocationModel : INotifyPropertyChanged

    {
        private string _description;
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description
        {
            get => _description;
            set
            {
                if (Description == null || !_description.Equals(value))
                {
                    _description = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
                }
}
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

