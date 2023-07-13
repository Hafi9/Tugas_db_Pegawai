using System;
using System.Collections.Generic;
using MCCArchitecture.Models;
using MCCArchitecture.Views;

namespace MCCArchitecture.Controllers
{
    public class HistoryC
    {
        private History _historyModel;
        private VHistory _historyView;

        public HistoryC(History historyModel, VHistory historyView)
        {
            _historyModel = historyModel;
            _historyView = historyView;
        }

        public void GetAll()
        {
            var result = _historyModel.GetAll();
            if (result.Count == 0)
            {
                _historyView.DataEmpty();
            }
            else
            {
                _historyView.GetAll(result);
            }
        }

        public void Insert()
        {
            var history = _historyView.AddHistoryMenu();

            var result = _historyModel.Insert(history);
            switch (result)
            {
                case -1:
                    _historyView.Error();
                    break;
                case 0:
                    _historyView.Failure();
                    break;
                default:
                    _historyView.Success();
                    break;
            }
        }

        public void Update()
        {
            var history = _historyView.UpdateHistoryMenu();
            var result = _historyModel.Update(history);

            switch (result)
            {
                case -1:
                    _historyView.Error();
                    break;
                case 0:
                    _historyView.Failure();
                    break;
                default:
                    _historyView.Success();
                    break;
            }
        }

        public void SearchById()
        {
            DateTime startDate = _historyView.GetStartDate();
            int employeeId = _historyView.GetEmployeeId();

            var result = _historyModel.GetById(startDate, employeeId);
            if (result == null)
            {
                _historyView.HistoryNotFound();
            }
            else
            {
                _historyView.GetById(result);
            }
        }

        public void Delete()
        {
            DateTime startDate = _historyView.GetStartDate();
            int employeeId = _historyView.GetEmployeeId();

            var result = _historyModel.Delete(startDate, employeeId);
            switch (result)
            {
                case -1:
                    _historyView.Error();
                    break;
                case 0:
                    _historyView.Failure();
                    break;
                default:
                    _historyView.Success();
                    break;
            }
        }
    }
}
