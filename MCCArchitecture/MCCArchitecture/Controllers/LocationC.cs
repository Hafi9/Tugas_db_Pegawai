using MCCArchitecture.Models;
using MCCArchitecture.Views;
using System;

namespace MCCArchitecture.Controllers
{
    public class LocationC
    {
        private Location _locationModel;
        private VLocation _locationView;

        public LocationC(Location locationModel, VLocation locationView)
        {
            _locationModel = locationModel;
            _locationView = locationView;
        }

        public void GetAll()
        {
            var result = _locationModel.GetAll();
            if (result.Count == 0)
            {
                _locationView.DataEmpty();
            }
            else
            {
                _locationView.GetAll(result);
            }
        }

        public void Insert()
        {
            var location = _locationView.InsertMenu();

            var result = _locationModel.Insert(location);
            switch (result)
            {
                case -1:
                    _locationView.Error();
                    break;
                case 0:
                    _locationView.Failure();
                    break;
                default:
                    _locationView.Success();
                    break;
            }
        }

        public void Update()
        {
            var location = _locationView.UpdateMenu();
            var result = _locationModel.Update(location);

            switch (result)
            {
                case -1:
                    _locationView.Error();
                    break;
                case 0:
                    _locationView.Failure();
                    break;
                default:
                    _locationView.Success();
                    break;
            }
        }

        public void SearchById()
        {
            int id = _locationView.GetLocationId();
            var result = _locationModel.GetById(id);
            if (result == null)
            {
                _locationView.LocationNotFound();
            }
            else
            {
                _locationView.GetById(result);
            }
        }

        public void Delete()
        {
            int id = _locationView.GetLocationId();
            var result = _locationModel.Delete(id);
            switch (result)
            {
                case -1:
                    _locationView.Error();
                    break;
                case 0:
                    _locationView.Failure();
                    break;
                default:
                    _locationView.Success();
                    break;
            }
        }
    }
}
