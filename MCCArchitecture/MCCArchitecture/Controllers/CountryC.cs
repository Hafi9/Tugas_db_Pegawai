using MCCArchitecture.Models;
using MCCArchitecture.Views;
using System;

namespace MCCArchitecture.Controllers
{
    public class CountryC
    {
        private Country _countryModel;
        private VCountry _countryView;

        public CountryC(Country countryModel, VCountry countryView)
        {
            _countryModel = countryModel;
            _countryView = countryView;
        }

        public void GetAll()
        {
            var result = _countryModel.GetAll();
            if (result.Count == 0)
            {
                _countryView.DataEmpty();
            }
            else
            {
                _countryView.GetAll(result);
            }
        }

        public void Insert()
        {
            var country = _countryView.InsertMenu();

            var result = _countryModel.Insert(country);
            switch (result)
            {
                case -1:
                    _countryView.Error();
                    break;
                case 0:
                    _countryView.Failure();
                    break;
                default:
                    _countryView.Success();
                    break;
            }
        }

        public void Update()
        {
            var country = _countryView.UpdateMenu();
            var result = _countryModel.Update(country);

            switch (result)
            {
                case -1:
                    _countryView.Error();
                    break;
                case 0:
                    _countryView.Failure();
                    break;
                default:
                    _countryView.Success();
                    break;
            }
        }

        public void SearchById()
        {
            string id = _countryView.GetCountryId();
            var result = _countryModel.GetById(id);
            if (result == null)
            {
                _countryView.CountryNotFound();
            }
            else
            {
                _countryView.GetById(result);
            }
        }

        public void Delete()
        {
            string id = _countryView.GetCountryId();
            var result = _countryModel.Delete(id);
            switch (result)
            {
                case -1:
                    _countryView.Error();
                    break;
                case 0:
                    _countryView.Failure();
                    break;
                default:
                    _countryView.Success();
                    break;
            }
        }
    }
}
